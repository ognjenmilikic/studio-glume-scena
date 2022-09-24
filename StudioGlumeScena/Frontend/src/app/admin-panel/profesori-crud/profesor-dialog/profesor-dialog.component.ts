import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Grupa } from 'src/app/models/grupa.model';
import { Profesor } from 'src/app/models/profesor.model';
import { ProfesorService } from 'src/app/services/profesor.service';

@Component({
  selector: 'app-profesor-dialog',
  templateUrl: './profesor-dialog.component.html',
  styleUrls: ['./profesor-dialog.component.scss']
})
export class ProfesorDialogComponent implements OnInit, OnDestroy {

  profesor: Profesor | null;
  pregled: boolean = false;
  profesorForm: FormGroup;
  naslov: string = "";
  sacuvajProfesoraSub: Subscription;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private dialogRef: MatDialogRef<ProfesorDialogComponent>,
  private profesorService: ProfesorService, private snack: MatSnackBar) {
    this.profesor = data.profesor;
    this.pregled = data.pregled;

    if(!!!this.profesor) {
      this.naslov = "Evidentiranje profesora";
    }
    else {
      this.naslov = this.pregled ? "Pregled profesora" : "Izmena profesora";
    }
  }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.profesorForm = new FormGroup({
      id: new FormControl({ value: this.profesor?.id, disabled: this.pregled }),
      ime: new FormControl({ value: this.profesor?.ime, disabled: this.pregled }, [Validators.required]),
      prezime: new FormControl({ value: this.profesor?.prezime, disabled: this.pregled }, [Validators.required]),
      brojTelefona: new FormControl({ value: this.profesor?.brojTelefona, disabled: this.pregled }, [Validators.required, Validators.pattern('^(06|\\+3816|003816)[0-9]{7,9}$')]),
      adresa: new FormControl({ value: this.profesor?.adresa, disabled: this.pregled }, [Validators.required]),
      email: new FormControl({ value: this.profesor?.email, disabled: this.pregled }, [Validators.required, Validators.email]),
    })
  }

  sacuvaj(): void {
    if(!!!this.profesor) {
      this.profesor = {
        id : 0,
        ime : this.profesorForm.controls.ime.value,
        prezime : this.profesorForm.controls.prezime.value,
        brojTelefona : this.profesorForm.controls.brojTelefona.value,
        adresa : this.profesorForm.controls.adresa.value,
        email : this.profesorForm.controls.email.value,
        korisnikId : 0,
        korisnik : null
      }
    }
    else {
      this.profesor.ime = this.profesorForm.controls.ime.value;
      this.profesor.prezime = this.profesorForm.controls.prezime.value;
      this.profesor.brojTelefona = this.profesorForm.controls.brojTelefona.value;
      this.profesor.adresa = this.profesorForm.controls.adresa.value;
      this.profesor.email = this.profesorForm.controls.email.value;
    }

    this.sacuvajProfesoraSub = this.profesorService.sacuvajProfesora(this.profesor).subscribe(
      res => {
        this.snack.open("Uspešno ste sačuvali profesora", null, { duration: 5000, panelClass: ['success-snackbar']})
        this.dialogRef.close(res);
      },
      error => {
        this.snack.open("Došlo je do greške prilikom čuvanja profesora", null, { duration: 5000, panelClass: ['error-snackbar']})
        this.dialogRef.close();
      }
    )
  }

  close(): void {
    this.dialogRef.close();
  }

  ngOnDestroy(): void {
    if(!!this.sacuvajProfesoraSub) { this.sacuvajProfesoraSub.unsubscribe() }
  }
}
