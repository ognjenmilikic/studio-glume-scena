import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Grupa } from 'src/app/models/grupa.model';
import { Ucenik } from 'src/app/models/ucenik.model';
import { UcenikService } from 'src/app/services/ucenik.service';
import { UpisService } from 'src/app/services/upis.service';

@Component({
  selector: 'app-ucenik-dialog',
  templateUrl: './ucenik-dialog.component.html',
  styleUrls: ['./ucenik-dialog.component.scss']
})
export class UcenikDialogComponent implements OnInit, OnDestroy {

  ucenik: Ucenik | null;
  pregled: boolean = false;
  generisanoSaPrijave: boolean = false;
  ucenikForm: FormGroup;
  sveGrupe: Grupa[];
  naslov: string = "";
  prijavaId: number = 0;
  sacuvajUcenikaSub: Subscription;
  razresiPrijavuSub: Subscription;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private dialogRef: MatDialogRef<UcenikDialogComponent>,
  private ucenikService: UcenikService, private snack: MatSnackBar, private upisService: UpisService) {
    this.ucenik = data.ucenik;
    this.pregled = data.pregled;
    this.sveGrupe = data.sveGrupe;
    this.generisanoSaPrijave = data.generisanoSaPrijave
    this.prijavaId = data.prijavaId;

    if(!!!this.ucenik || this.generisanoSaPrijave) {
      this.naslov = "Evidentiranje učenika";
    }
    else {
      this.naslov = this.pregled ? "Pregled učenika" : "Izmena učenika";
    }
  }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.ucenikForm = new FormGroup({
      id: new FormControl({ value: this.ucenik?.id, disabled: this.pregled }),
      ime: new FormControl({ value: this.ucenik?.ime, disabled: this.pregled }, [Validators.required]),
      prezime: new FormControl({ value: this.ucenik?.prezime, disabled: this.pregled }, [Validators.required]),
      godinaRodjenja: new FormControl({ value: this.ucenik?.godinaRodjenja, disabled: this.pregled }, [Validators.required, Validators.pattern('^[0-9]{4}$')]),
      brojTelefona: new FormControl({ value: this.ucenik?.brojTelefona, disabled: this.pregled }, [Validators.required, Validators.pattern('^(06|\\+3816|003816)[0-9]{7,9}$')]),
      adresa: new FormControl({ value: this.ucenik?.adresa, disabled: this.pregled }, [Validators.required]),
      email: new FormControl({ value: this.ucenik?.email, disabled: this.pregled }, [Validators.required, Validators.email]),
      grupaId: new FormControl({ value: this.ucenik?.grupaId, disabled: this.pregled }, [Validators.required])
    })
  }

  sacuvaj(): void {
    if(!!!this.ucenik) {
      this.ucenik = {
        id : 0,
        ime : this.ucenikForm.controls.ime.value,
        prezime : this.ucenikForm.controls.prezime.value,
        godinaRodjenja : this.ucenikForm.controls.godinaRodjenja.value,
        brojTelefona : this.ucenikForm.controls.brojTelefona.value,
        adresa : this.ucenikForm.controls.adresa.value,
        email : this.ucenikForm.controls.email.value,
        grupaId : this.ucenikForm.controls.grupaId.value,
        grupa : null,
        korisnikId : 0,
        korisnik : null
      }
    }
    else {
      this.ucenik.ime = this.ucenikForm.controls.ime.value;
      this.ucenik.prezime = this.ucenikForm.controls.prezime.value;
      this.ucenik.godinaRodjenja = this.ucenikForm.controls.godinaRodjenja.value;
      this.ucenik.brojTelefona = this.ucenikForm.controls.brojTelefona.value;
      this.ucenik.adresa = this.ucenikForm.controls.adresa.value;
      this.ucenik.email = this.ucenikForm.controls.email.value;
      this.ucenik.grupaId = this.ucenikForm.controls.grupaId.value;
    }

    this.sacuvajUcenikaSub = this.ucenikService.sacuvajUcenika(this.ucenik).subscribe(
      res => {
        this.snack.open("Uspešno ste sačuvali učenika", null, { duration: 5000, panelClass: ['success-snackbar']})
        this.dialogRef.close(res);
        if(this.generisanoSaPrijave) {
          this.razresiPrijavu();
        }
      },
      error => {
        this.snack.open("Došlo je do greške prilikom čuvanja učenika", null, { duration: 5000, panelClass: ['error-snackbar']})
        this.dialogRef.close();
      }
    )
  }

  razresiPrijavu(): void {
    this.razresiPrijavuSub = this.upisService.razresiPrijavu(this.prijavaId).subscribe()
  }

  close(): void {
    this.dialogRef.close();
  }

  ngOnDestroy(): void {
    if(!!this.sacuvajUcenikaSub) { this.sacuvajUcenikaSub.unsubscribe() }
    if(!!this.razresiPrijavuSub) { this.razresiPrijavuSub.unsubscribe() }
  }

}
