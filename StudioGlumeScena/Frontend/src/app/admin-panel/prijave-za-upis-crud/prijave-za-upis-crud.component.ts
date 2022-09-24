import { Component, EventEmitter, Input, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { Grupa } from 'src/app/models/grupa.model';
import { PrijavaZaUpis } from 'src/app/models/prijava-za-upis.model';
import { Ucenik } from 'src/app/models/ucenik.model';
import { DialogService } from 'src/app/services/dialog.service';
import { UpisService } from 'src/app/services/upis.service';
import { UcenikDialogComponent } from 'src/app/shared/ucenici-crud/ucenik-dialog/ucenik-dialog.component';

@Component({
  selector: 'app-prijave-za-upis-crud',
  templateUrl: './prijave-za-upis-crud.component.html',
  styleUrls: ['./prijave-za-upis-crud.component.scss']
})
export class PrijaveZaUpisCrudComponent implements OnInit, OnDestroy {

  @Input() prijave: PrijavaZaUpis[];
  @Input() sveGrupe: Grupa[];
  @Output() promenaMedjuPrijavama: EventEmitter<boolean> = new EventEmitter<boolean>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = ['redniBroj', 'ime', 'prezime', 'godinaRodjenja', 'brojTelefona', 'adresa', 'akcije'];
  dataSource: MatTableDataSource<PrijavaZaUpis>;
  odbaciPrijavuSub: Subscription;
  oznaciKaoProcitanoSub: Subscription;

  constructor(private dialogService: DialogService, private upisService: UpisService, private snack: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.prijave);
  }

  ngAfterViewInit() {
    this.paginator._intl.itemsPerPageLabel="Broj redova po stranici:";
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  oznaciKaoProcitano(prijava: PrijavaZaUpis): void {
    this.oznaciKaoProcitanoSub = this.upisService.oznaciKaoProcitano(prijava.id).subscribe(
      res => {
        this.promenaMedjuPrijavama.emit(res);
      }
    )
  }

  generisiUcenikaOdPrijave(prijava: PrijavaZaUpis): void {
    let ucenik = {
      id : 0,
      ime : prijava.ime,
      prezime : prijava.prezime,
      godinaRodjenja: prijava.godinaRodjenja,
      brojTelefona : prijava.brojTelefona,
      adresa : prijava.adresa,
      email: prijava.email,
      grupaId: null,
      grupa: null,
      korisnikId: 0,
      korisnik: null
    }

    let dialogRef = this.dialog.open(UcenikDialogComponent, { data: { ucenik: ucenik, sveGrupe: this.sveGrupe, pregled: false, generisanoSaPrijave: true, prijavaId: prijava.id } });
    dialogRef.afterClosed().subscribe(
      res => {
        if(!!res) {
          this.dialogService.infoDialog("Uspešno dodat nov korisnik!",
          "Kredencijali za logovanje novog korisnika su:\n\nEmail: " + res.korisnik.email + "\nPassword: " + res.korisnik.password,
          "Izađi")
          this.promenaMedjuPrijavama.emit();
      }
      }
    );
  }

  odbaciPrijavu(prijava: PrijavaZaUpis): void {
    this.dialogService.confirmDialog(
      "Odbacivanje prijave",
      "Da li ste sigurni da želite da odbacite prijavu za upis?",
      "Ne",
      "Da", () => {
        this.odbaciPrijavuSub = this.upisService.odbaciPrijavu(prijava.id)
        .subscribe(
          result => {
            this.snack.open("Uspešno ste odbacili prijavu", null, { duration: 5000, panelClass: ['success-snackbar']})
            this.promenaMedjuPrijavama.emit(result);
          },
          error => {
            this.snack.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
          });
        }, () => { });
  }

  ngOnDestroy(): void {
    if(!!this.odbaciPrijavuSub) { this.odbaciPrijavuSub.unsubscribe() }
    if(!!this.oznaciKaoProcitanoSub) { this.oznaciKaoProcitanoSub.unsubscribe() }
  }
}
