import { Component, EventEmitter, Input, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { Profesor } from 'src/app/models/profesor.model';
import { DialogService } from 'src/app/services/dialog.service';
import { ProfesorService } from 'src/app/services/profesor.service';
import { ProfesorDialogComponent } from './profesor-dialog/profesor-dialog.component';

@Component({
  selector: 'app-profesori-crud',
  templateUrl: './profesori-crud.component.html',
  styleUrls: ['./profesori-crud.component.scss']
})
export class ProfesoriCrudComponent implements OnInit, OnDestroy {

  @Input() profesori: Profesor[];
  @Output() promenaMedjuProfesorima: EventEmitter<boolean> = new EventEmitter<boolean>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = ['redniBroj', 'ime', 'prezime', 'brojTelefona', 'adresa', 'akcije'];
  dataSource: MatTableDataSource<Profesor>;
  obrisiProfesoraSub: Subscription;

  constructor(private dialogService: DialogService, private profesorService: ProfesorService, private snack: MatSnackBar, private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.profesori);
    this.dataSource.filterPredicate = function (profesor: Profesor, filter: string) {
      return profesor.prezime.trim().toLowerCase().includes(filter.trim().toLowerCase());
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
    let dialogRef = this.dialog.open(ProfesorDialogComponent, { data: { profesor: null, pregled: false } });
    dialogRef.afterClosed().subscribe(
      res => {
        if(!!res) {
          this.dialogService.infoDialog("Uspešno dodat nov korisnik!",
          "Kredencijali za logovanje novog korisnika su:\n\nEmail: " + res.korisnik.email + "\nPassword: " + res.korisnik.password,
          "Izađi")
          this.promenaMedjuProfesorima.emit();
      }
      }
    );
  }

  pregled(profesor: Profesor): void {
    this.dialog.open(ProfesorDialogComponent, { data: { profesor: profesor, pregled: true } });
  }

  izmena(profesor: Profesor): void {
    this.dialog.open(ProfesorDialogComponent, { data: { profesor: profesor, pregled: false } });
  }

  brisanje(profesor: Profesor): void {
    this.dialogService.confirmDialog(
      "Brisanje profesora",
      "Da li ste sigurni da želite da obrišete profesora pod imenom " + profesor.ime + " " + profesor.prezime,
      "Ne",
      "Da", () => {
        this.obrisiProfesoraSub = this.profesorService.obrisiProfesora(profesor.id)
        .subscribe(
          result => {
            this.snack.open("Uspešno ste obrisali profesora", null, { duration: 5000, panelClass: ['success-snackbar']})
            this.promenaMedjuProfesorima.emit(result);
          },
          error => {
            this.snack.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
          });
        }, () => { });
  }

  ngOnDestroy(): void {
    if(!!this.obrisiProfesoraSub) { this.obrisiProfesoraSub.unsubscribe() }
  }
}
