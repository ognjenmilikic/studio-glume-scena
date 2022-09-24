import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { Subscription } from 'rxjs';
import { Lokacija } from '../models/lokacija.model';
import { LokacijaService } from '../services/lokacija.service';

@Component({
  selector: 'app-kontakt',
  templateUrl: './kontakt.component.html',
  styleUrls: ['./kontakt.component.scss']
})
export class KontaktComponent implements OnInit, OnDestroy {

  sveLokacije: Lokacija[] = [];
  ucitajLokacijeSub: Subscription;

  constructor(private lokacijaService: LokacijaService, private sanitizer: DomSanitizer, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.ucitajLokacije();
  }

  ucitajLokacije(): void {
    this.ucitajLokacijeSub = this.lokacijaService.vratiSveLokacije().subscribe(
      res => {
        this.sveLokacije = res;
        this.sveLokacije?.forEach(l => {
          l.mapaSafeSource = this.sanitizer.bypassSecurityTrustResourceUrl(l.mapaSource);
        })
      },
      error => {
        this.snackBar.open("Došlo je do greške prilikom učitavanja lokacija", null, { duration: 5000, panelClass: ['error-snackbar']})
      }
    )
  }

  ngOnDestroy(): void {
    if(!!this.ucitajLokacijeSub) { this.ucitajLokacijeSub.unsubscribe() };
  }
}
