import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { GrupaTable } from 'src/app/models/grupa-table.model';
import { Grupa } from 'src/app/models/grupa.model';
import { Lokacija } from 'src/app/models/lokacija.model';
import { Profesor } from 'src/app/models/profesor.model';
import { Uzrast } from 'src/app/models/uzrast.model';
import { DialogService } from 'src/app/services/dialog.service';
import { GrupaService } from 'src/app/services/grupa.service';
import { GrupaDialogComponent } from './grupa-dialog/grupa-dialog.component';

@Component({
  selector: 'app-grupe-crud',
  templateUrl: './grupe-crud.component.html',
  styleUrls: ['./grupe-crud.component.scss']
})
export class GrupeCrudComponent implements OnInit {

  @Input() grupe: Grupa[];
  @Input() lokacije: Lokacija[];
  @Input() profesori: Profesor[];
  @Input() uzrasti: Uzrast[];
  grupeTable: GrupaTable[] = [];
  @Output() promenaMedjuGrupama: EventEmitter<boolean> = new EventEmitter<boolean>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = ['redniBroj', 'vremeOdrzavanjaCasa', 'lokacija', 'uzrast', 'profesor', 'akcije'];
  dataSource: MatTableDataSource<GrupaTable>;
  obrisiGrupuSub: Subscription;

  constructor(private dialogService: DialogService, private grupaService: GrupaService, private snack: MatSnackBar,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.grupe.forEach(g => {
      let grupaTable = {
        id: g.id,
        vremeOdrzavanjaCasa: g.danOdrzavanjaCasa + ", " + g.vremeOdrzavanjaCasa,
        lokacija: g.lokacija.naziv,
        uzrast: g.uzrast.naziv,
        profesor: g.profesor.ime + " " + g.profesor.prezime
      }
      this.grupeTable.push(grupaTable);
    })

    this.dataSource = new MatTableDataSource(this.grupeTable);
    this.dataSource.filterPredicate = function (grupa: GrupaTable, filter: string) {
      return grupa.lokacija.trim().toLowerCase().includes(filter.trim().toLowerCase());
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
    let dialogRef = this.dialog.open(GrupaDialogComponent, { data: { grupa: null, lokacije: this.lokacije, profesori: this.profesori, uzrasti: this.uzrasti, pregled: false } });
    dialogRef.afterClosed().subscribe(
      res => {
        if(!!res) {
            this.snack.open("Uspešno ste dodali grupu", null, { duration: 5000, panelClass: ['success-snackbar']})
            this.promenaMedjuGrupama.emit();
      }
      }
    );
  }

  pregled(grupaTable: GrupaTable): void {
    this.dialog.open(GrupaDialogComponent, { data: { grupa: this.grupe.find(g => g.id == grupaTable.id), lokacije: this.lokacije, profesori: this.profesori, uzrasti: this.uzrasti, pregled: true } });
  }

  izmena(grupaTable: GrupaTable): void {
    this.dialog.open(GrupaDialogComponent, { data: { grupa: this.grupe.find(g => g.id == grupaTable.id), lokacije: this.lokacije, profesori: this.profesori, uzrasti: this.uzrasti, pregled: false } });
  }

  brisanje(grupaTable: GrupaTable): void {
    this.dialogService.confirmDialog(
      "Brisanje grupe",
      "Da li ste sigurni da želite da obrišete grupu",
      "Ne",
      "Da", () => {
        this.obrisiGrupuSub = this.grupaService.obrisiGrupu(grupaTable.id)
        .subscribe(
          result => {
            this.snack.open("Uspešno ste obrisali grupu", null, { duration: 5000, panelClass: ['success-snackbar']})
            this.promenaMedjuGrupama.emit(result);
          },
          error => {
            this.snack.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
          });
        }, () => { });
  }

  ngOnDestroy(): void {
    if(!!this.obrisiGrupuSub) { this.obrisiGrupuSub.unsubscribe() }
  }
}
