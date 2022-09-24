import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer } from '@angular/platform-browser';
import { Subscription } from 'rxjs';
import { Grupa } from 'src/app/models/grupa.model';
import { GrupaService } from 'src/app/services/grupa.service';
import { JwtService } from 'src/app/services/jwt.service';
import { UceniciCrudComponent } from 'src/app/shared/ucenici-crud/ucenici-crud.component';
import { ZadajNoviZadatakDialogComponent } from '../zadaj-novi-zadatak-dialog/zadaj-novi-zadatak-dialog.component';

@Component({
  selector: 'app-profesor-panel-home',
  templateUrl: './profesor-panel-home.component.html',
  styleUrls: ['./profesor-panel-home.component.scss']
})
export class ProfesorPanelHomeComponent implements OnInit, OnDestroy {

  @ViewChild('uceniciCrud') uceniciCrud: UceniciCrudComponent;
  loading: boolean = true;
  grupe: Grupa[] = [];
  vratiGrupeSub: Subscription;

  constructor(private grupaService: GrupaService, private jwtService: JwtService, private snack: MatSnackBar,
    private sanitizer: DomSanitizer, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.ucitajStranicu();
  }

  ucitajStranicu(): void {
    let idKorisnika = Number.parseInt(this.jwtService.vratiIdKorisnika());

    this.vratiGrupeSub = this.grupaService.vratiGrupeZaProfesora(idKorisnika).subscribe(
      res => {
        this.grupe = res;

        this.grupe?.forEach(g => {
          g.lokacija.mapaSafeSource = this.sanitizer.bypassSecurityTrustResourceUrl(g.lokacija.mapaSource);
        })
        this.loading = false;
      },
      error => {
        this.snack.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
        this.loading = false;
      }
    )
  }

  zadajNoviZadatak(grupa: Grupa){
    let dialogRef = this.dialog.open(ZadajNoviZadatakDialogComponent, { data: { grupa: grupa } });
    dialogRef.afterClosed().subscribe(
      res => {
        if(!!res) {
          this.ucitajStranicu();
        }
      }
    );
  }

  ngOnDestroy(): void {
    if(!!this.vratiGrupeSub) { this.vratiGrupeSub.unsubscribe() }
  }
}
