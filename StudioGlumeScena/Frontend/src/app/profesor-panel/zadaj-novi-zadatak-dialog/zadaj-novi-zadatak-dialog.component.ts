import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Grupa } from 'src/app/models/grupa.model';
import { GrupaService } from 'src/app/services/grupa.service';
import { UcenikDialogComponent } from 'src/app/shared/ucenici-crud/ucenik-dialog/ucenik-dialog.component';

@Component({
  selector: 'app-zadaj-novi-zadatak-dialog',
  templateUrl: './zadaj-novi-zadatak-dialog.component.html',
  styleUrls: ['./zadaj-novi-zadatak-dialog.component.scss']
})
export class ZadajNoviZadatakDialogComponent implements OnInit {

  grupa: Grupa | null;
  zadatakForm: FormGroup;
  sacuvajGrupuSub: Subscription;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private dialogRef: MatDialogRef<UcenikDialogComponent>,
    private grupaService: GrupaService, private snack: MatSnackBar) {
    this.grupa = data.grupa;
  }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.zadatakForm = new FormGroup({
      aktivanZadatak: new FormControl("", [Validators.required])
    })
  }

  sacuvaj(): void {
    this.grupa.aktivanZadatak = this.zadatakForm.controls.aktivanZadatak.value;

    this.sacuvajGrupuSub = this.grupaService.sacuvajGrupu(this.grupa).subscribe(
      res => {
        this.snack.open("Uspešno ste sačuvali novi zadatak", null, { duration: 5000, panelClass: ['success-snackbar'] })
        this.dialogRef.close(res);
      },
      error => {
        this.snack.open("Došlo je do greške prilikom čuvanja zadatka", null, { duration: 5000, panelClass: ['error-snackbar'] })
        this.dialogRef.close();
      }
    )
  }

  close(): void {
    this.dialogRef.close();
  }

  ngOnDestroy(): void {
    if (!!this.sacuvajGrupuSub) { this.sacuvajGrupuSub.unsubscribe() }
  }
}
