import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { PromenaLozinkeRequest } from '../models/promenaLozinkeRequest.model';
import { JwtService } from '../services/jwt.service';
import { KorisnikService } from '../services/korisnik.service';

@Component({
  selector: 'app-promena-lozinke-dialog',
  templateUrl: './promena-lozinke-dialog.component.html',
  styleUrls: ['./promena-lozinke-dialog.component.scss']
})
export class PromenaLozinkeDialogComponent implements OnInit, OnDestroy {

  promenaLozinkeForm: FormGroup;
  staraLozinkaVidljiva: boolean = false;
  novaLozinkaVidljiva: boolean = false;
  promenaLozinkeSub: Subscription;

  constructor(private dialogRef: MatDialogRef<PromenaLozinkeDialogComponent>, private korisnikService: KorisnikService,
    private jwtService: JwtService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.promenaLozinkeForm = new FormGroup({
      staraLozinka: new FormControl("", [Validators.required, Validators.minLength(8)]),
      novaLozinka: new FormControl("", [Validators.required, Validators.minLength(8)])
    })
  }

  promeniVidljivostStareLozinke(): void {
    this.staraLozinkaVidljiva = !this.staraLozinkaVidljiva;
  }

  promeniVidljivostNoveLozinke(): void {
    this.novaLozinkaVidljiva = !this.novaLozinkaVidljiva;
  }

  promeniLozinku(): void {
    let promenaLozinkeRequest: PromenaLozinkeRequest = {
      korisnikId : Number.parseInt(this.jwtService.vratiIdKorisnika()),
      staraLozinka : this.promenaLozinkeForm.controls.staraLozinka.value,
      novaLozinka : this.promenaLozinkeForm.controls.novaLozinka.value
    }
    this.promenaLozinkeSub = this.korisnikService.promeniLozinku(promenaLozinkeRequest).subscribe(
      res => {
        this.snackBar.open("Uspešno ste promenili lozinku", null, { duration: 5000, panelClass: ['success-snackbar']})
        this.close();
      },
      error => {
        this.snackBar.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
      }
    )
  }

  close(): void {
    this.dialogRef.close();
  }

  ngOnDestroy(): void {
    if(!!this.promenaLozinkeSub) { this.promenaLozinkeSub.unsubscribe() }
  }
}
