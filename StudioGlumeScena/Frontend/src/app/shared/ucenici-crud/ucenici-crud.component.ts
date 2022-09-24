import { Component, Input, OnDestroy, OnInit, Output, ViewChild, EventEmitter } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Ucenik } from 'src/app/models/ucenik.model';
import { MatTableDataSource } from '@angular/material/table';
import { DialogService } from 'src/app/services/dialog.service';
import { UcenikService } from 'src/app/services/ucenik.service';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { JwtService } from 'src/app/services/jwt.service';
import { SifraKorisnickeUloge } from '../enums/enums';
import { MatDialog } from '@angular/material/dialog';
import { UcenikDialogComponent } from './ucenik-dialog/ucenik-dialog.component';
import { Grupa } from 'src/app/models/grupa.model';

@Component({
  selector: 'app-ucenici-crud',
  templateUrl: './ucenici-crud.component.html',
  styleUrls: ['./ucenici-crud.component.scss']
})
export class UceniciCrudComponent implements OnInit, OnDestroy {

  @Input() ucenici: Ucenik[];
  @Input() sveGrupe: Grupa[];
  @Output() promenaMedjuUcenicima: EventEmitter<boolean> = new EventEmitter<boolean>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = ['redniBroj', 'ime', 'prezime', 'godinaRodjenja', 'brojTelefona', 'adresa', 'akcije'];
  dataSource: MatTableDataSource<Ucenik>;
  obrisiUcenikaSub: Subscription;
  jeAdministrator: boolean = false;

  constructor(private dialogService: DialogService, private ucenikService: UcenikService, private snack: MatSnackBar,
    private jwtService: JwtService, private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.jeAdministrator = this.jwtService.imaSifruUloge(SifraKorisnickeUloge.Administrator.toString());
    this.dataSource = new MatTableDataSource(this.ucenici);
    this.dataSource.filterPredicate = function (ucenik: Ucenik, filter: string) {
      return ucenik.prezime.trim().toLowerCase().includes(filter.trim().toLowerCase());
   }
  }

  ngAfterViewInit() {
    this.paginator._intl.itemsPerPageLabel="Broj redova po stranici:";
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter($event: Event) {
    const filterValue = ($event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  dodaj(): void {
    let dialogRef = this.dialog.open(UcenikDialogComponent, { data: { ucenik: null, sveGrupe: this.sveGrupe, pregled: false, generisanoSaPrijave: false } });
    dialogRef.afterClosed().subscribe(
      res => {
        if(!!res) {
          this.dialogService.infoDialog("Uspešno dodat nov korisnik!",
          "Kredencijali za logovanje novog korisnika su:\n\nEmail: " + res.korisnik.email + "\nPassword: " + res.korisnik.password,
          "Izađi")
          this.promenaMedjuUcenicima.emit();
      }
      }
    );
  }

  pregled(ucenik: Ucenik): void {
    this.dialog.open(UcenikDialogComponent, { data: { ucenik: ucenik, sveGrupe: this.sveGrupe, pregled: true } });
  }

  izmena(ucenik: Ucenik): void {
    this.dialog.open(UcenikDialogComponent, { data: { ucenik: ucenik, sveGrupe: this.sveGrupe, pregled: false } });
  }

  brisanje(ucenik: Ucenik): void {
    this.dialogService.confirmDialog(
      "Brisanje učenika",
      "Da li ste sigurni da želite da obrišete učenika pod imenom " + ucenik.ime + " " + ucenik.prezime,
      "Ne",
      "Da", () => {
        this.obrisiUcenikaSub = this.ucenikService.obrisiUcenika(ucenik.id)
        .subscribe(
          result => {
            this.snack.open("Uspešno ste obrisali učenika", null, { duration: 5000, panelClass: ['success-snackbar']})
            this.promenaMedjuUcenicima.emit(result);
          },
          error => {
            this.snack.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
          });
        }, () => { });
  }

  ngOnDestroy(): void {
    if(!!this.obrisiUcenikaSub) { this.obrisiUcenikaSub.unsubscribe() }
  }

}
