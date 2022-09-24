import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer } from '@angular/platform-browser';
import { Subscription } from 'rxjs';
import { Ucenik } from 'src/app/models/ucenik.model';
import { JwtService } from 'src/app/services/jwt.service';
import { UcenikService } from 'src/app/services/ucenik.service';

@Component({
  selector: 'app-ucenik-panel-home',
  templateUrl: './ucenik-panel-home.component.html',
  styleUrls: ['./ucenik-panel-home.component.scss']
})
export class UcenikPanelHomeComponent implements OnInit {

  loading: boolean = true;
  ucenik: Ucenik;
  vratiUcenikaSub: Subscription;

  constructor(private ucenikService: UcenikService, private jwtService: JwtService, private snack: MatSnackBar, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.ucitajStranicu();
  }

  ucitajStranicu(): void {
    let idKorisnika = Number.parseInt(this.jwtService.vratiIdKorisnika());

    this.vratiUcenikaSub = this.ucenikService.vratiUcenikaZaIdKorisnika(idKorisnika).subscribe(
      res => {
        this.ucenik = res;
        this.ucenik.grupa.lokacija.mapaSafeSource = this.sanitizer.bypassSecurityTrustResourceUrl(this.ucenik.grupa.lokacija.mapaSource);
        this.loading = false;
      },
      error => {
        this.snack.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
        this.loading = false;
      }
    )
  }

  ngOnDestroy(): void {
    if(!!this.vratiUcenikaSub) { this.vratiUcenikaSub.unsubscribe() }
  }
}
