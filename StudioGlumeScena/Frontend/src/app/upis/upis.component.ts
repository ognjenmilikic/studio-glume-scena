import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PrijavaZaUpis } from '../models/prijava-za-upis.model';
import { UpisService } from '../services/upis.service';
import { MatDialog } from '@angular/material/dialog';
import { UpisDialogComponent } from './upis-dialog/upis-dialog.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-upis',
  templateUrl: './upis.component.html',
  styleUrls: ['./upis.component.scss']
})
export class UpisComponent implements OnInit, OnDestroy {

  upisForm: FormGroup;
  prijava: PrijavaZaUpis;
  prijavaSub: Subscription;

  constructor(private upisService: UpisService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void{
    this.upisForm = new FormGroup({
      ime: new FormControl('', [Validators.required]),
      prezime: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      brojTelefona: new FormControl('', [Validators.required, Validators.pattern('^(06|\\+3816|003816)[0-9]{7,9}$')]),
      godinaRodjenja: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{4}$')]),
      adresa: new FormControl('', [Validators.required])
    });
  }

  upis(): void{
    this.prijava = this.upisForm.value;
    this.prijavaSub = this.upisService.prijavaZaUpis(this.prijava).subscribe(
      result => {
        this.upisForm.reset();
        let naslov = result.ime + " je naš budući polaznik!";
        let tekst = "Uskoro ćemo te kontaktirati na " + result.email + " sa daljim instrukcijama. Ovo je početak jedne blistave karijere!"
        let putanjaDoSlike = "assets/images/logo/happyface.png";
        this.dialog.open(UpisDialogComponent, { data: { naslov: naslov, tekst: tekst, putanjaDoSlike: putanjaDoSlike } });
      },
      error => {
        this.dialog.open(UpisDialogComponent, { data: { naslov: "Ups!", tekst: "Došlo je do greške, molimo pokušajte ponovo.", putanjaDoSlike: "assets/images/logo/sadface.png" } });
      }
    )
  }

  ngOnDestroy(): void {
    if(!!this.prijavaSub) { this.prijavaSub.unsubscribe() }
  }
}
