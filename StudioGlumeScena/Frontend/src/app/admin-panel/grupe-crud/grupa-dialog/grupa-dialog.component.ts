import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Grupa } from 'src/app/models/grupa.model';
import { Lokacija } from 'src/app/models/lokacija.model';
import { Profesor } from 'src/app/models/profesor.model';
import { Ucenik } from 'src/app/models/ucenik.model';
import { Uzrast } from 'src/app/models/uzrast.model';
import { GrupaService } from 'src/app/services/grupa.service';
import { UcenikService } from 'src/app/services/ucenik.service';
import { UcenikDialogComponent } from 'src/app/shared/ucenici-crud/ucenik-dialog/ucenik-dialog.component';

@Component({
  selector: 'app-grupa-dialog',
  templateUrl: './grupa-dialog.component.html',
  styleUrls: ['./grupa-dialog.component.scss']
})
export class GrupaDialogComponent implements OnInit, OnDestroy {

  grupa: Grupa | null;
  pregled: boolean = false;
  grupaForm: FormGroup;
  lokacije: Lokacija[];
  profesori: Profesor[];
  uzrasti: Uzrast[];
  naslov: string = "";
  sacuvajGrupuSub: Subscription;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private dialogRef: MatDialogRef<UcenikDialogComponent>,
  private grupaService: GrupaService, private snack: MatSnackBar) {
    this.grupa = data.grupa;
    this.lokacije = data.lokacije;
    this.profesori = data.profesori;
    this.uzrasti = data.uzrasti;
    this.pregled = data.pregled;

    if(!!!this.grupa) {
      this.naslov = "Evidentiranje grupe";
    }
    else {
      this.naslov = this.pregled ? "Pregled grupe" : "Izmena grupe";
    }
  }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.grupaForm = new FormGroup({
      id: new FormControl({ value: this.grupa?.id, disabled: this.pregled }),
      vremeOdrzavanjaCasa: new FormControl({ value: this.grupa?.vremeOdrzavanjaCasa, disabled: this.pregled }, [Validators.required]),
      danOdrzavanjaCasa: new FormControl({ value: this.grupa?.danOdrzavanjaCasa, disabled: this.pregled }, [Validators.required]),
      profesorId: new FormControl({ value: this.grupa?.profesorId, disabled: this.pregled }, [Validators.required]),
      lokacijaId: new FormControl({ value: this.grupa?.lokacijaId, disabled: this.pregled }, [Validators.required]),
      uzrastId: new FormControl({ value: this.grupa?.uzrastId, disabled: this.pregled }, [Validators.required])
    })
  }

  sacuvaj(): void {
    if(!!!this.grupa) {
      this.grupa = {
        id : 0,
        vremeOdrzavanjaCasa : this.grupaForm.controls.vremeOdrzavanjaCasa.value,
        danOdrzavanjaCasa : this.grupaForm.controls.danOdrzavanjaCasa.value,
        aktivanZadatak : "",
        profesorId : this.grupaForm.controls.profesorId.value,
        profesor: null,
        lokacijaId : this.grupaForm.controls.lokacijaId.value,
        lokacija: null,
        uzrastId : this.grupaForm.controls.uzrastId.value,
        uzrast : null,
        ucenik: null
      }
    }
    else {
      this.grupa.vremeOdrzavanjaCasa = this.grupaForm.controls.vremeOdrzavanjaCasa.value;
      this.grupa.danOdrzavanjaCasa = this.grupaForm.controls.danOdrzavanjaCasa.value;
      this.grupa.aktivanZadatak = "";
      this.grupa.profesorId = this.grupaForm.controls.profesorId.value;
      this.grupa.profesor = null;
      this.grupa.lokacijaId = this.grupaForm.controls.lokacijaId.value;
      this.grupa.lokacija = null;
      this.grupa.uzrastId = this.grupaForm.controls.uzrastId.value;
      this.grupa.uzrast = null;
    }

    this.sacuvajGrupuSub = this.grupaService.sacuvajGrupu(this.grupa).subscribe(
      res => {
        this.snack.open("Uspešno ste sačuvali grupu", null, { duration: 5000, panelClass: ['success-snackbar']})
        this.dialogRef.close(res);
      },
      error => {
        this.snack.open("Došlo je do greške prilikom čuvanja grupe", null, { duration: 5000, panelClass: ['error-snackbar']})
        this.dialogRef.close();
      }
    )
  }

  close(): void {
    this.dialogRef.close();
  }

  ngOnDestroy(): void {
    if(!!this.sacuvajGrupuSub) { this.sacuvajGrupuSub.unsubscribe() }
  }

}
