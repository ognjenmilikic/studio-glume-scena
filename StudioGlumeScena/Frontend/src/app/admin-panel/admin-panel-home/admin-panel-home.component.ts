import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { forkJoin, Subscription } from 'rxjs';
import { GrupaTable } from 'src/app/models/grupa-table.model';
import { Grupa } from 'src/app/models/grupa.model';
import { Lokacija } from 'src/app/models/lokacija.model';
import { PrijavaZaUpis } from 'src/app/models/prijava-za-upis.model';
import { Profesor } from 'src/app/models/profesor.model';
import { Ucenik } from 'src/app/models/ucenik.model';
import { Uzrast } from 'src/app/models/uzrast.model';
import { GrupaService } from 'src/app/services/grupa.service';
import { LokacijaService } from 'src/app/services/lokacija.service';
import { ProfesorService } from 'src/app/services/profesor.service';
import { UcenikService } from 'src/app/services/ucenik.service';
import { UpisService } from 'src/app/services/upis.service';
import { UzrastService } from 'src/app/services/uzrast.service';
import { SifraUzrasta } from 'src/app/shared/enums/enums';
import { UceniciCrudComponent } from 'src/app/shared/ucenici-crud/ucenici-crud.component';
import { GrupeCrudComponent } from '../grupe-crud/grupe-crud.component';
import { PrijaveZaUpisCrudComponent } from '../prijave-za-upis-crud/prijave-za-upis-crud.component';
import { ProfesoriCrudComponent } from '../profesori-crud/profesori-crud.component';

@Component({
  selector: 'app-admin-panel-home',
  templateUrl: './admin-panel-home.component.html',
  styleUrls: ['./admin-panel-home.component.scss'],
})
export class AdminPanelHomeComponent implements OnInit, OnDestroy {

  @ViewChild('uceniciCrud') uceniciCrud: UceniciCrudComponent;
  @ViewChild('profesoriCrud') profesoriCrud: ProfesoriCrudComponent;
  @ViewChild('grupeCrud') grupeCrud: GrupeCrudComponent;
  @ViewChild('prijaveCrud') prijaveCrud: PrijaveZaUpisCrudComponent;
  loading: boolean = true;
  sviUcenici: Ucenik[] = [];
  sviProfesori: Profesor[] = [];
  sveGrupe: Grupa[] = [];
  svePrijaveZaUpis: PrijavaZaUpis[] = [];
  sveLokacije: Lokacija[] = [];
  sviUzrasti: Uzrast[] = [];
  sveGrupeTable: GrupaTable[] = [];
  inicijalniPodaciSub: Subscription;

  constructor(private ucenikService: UcenikService, private profesorService: ProfesorService,
    private grupaService: GrupaService, private prijavaZaUpisService: UpisService,
    private lokacijaService: LokacijaService, private uzrastService: UzrastService) { }

  ngOnInit(): void {
    this.ucitajStranicu();
  }

  ucitajStranicu(): void {
    this.inicijalniPodaciSub = forkJoin({
      vratiSveGrupeRequest: this.grupaService.vratiSveGrupe(),
      vratiSveProfesoreRequest: this.profesorService.vratiSveProfesore(),
      vratiSveUcenikeRequest: this.ucenikService.vratiSveUcenike(),
      vratiSvePrijaveZaUpisRequest: this.prijavaZaUpisService.vratiSvePrijaveZaUpis(),
      vratiSveLokacijeRequest: this.lokacijaService.vratiSveLokacije(),
      vratiSveUzrasteRequest: this.uzrastService.vratiSveUzraste()
    })
      .subscribe(({ vratiSveGrupeRequest, vratiSveProfesoreRequest, vratiSveUcenikeRequest, vratiSvePrijaveZaUpisRequest, vratiSveLokacijeRequest, vratiSveUzrasteRequest }) => {
        this.sveGrupe = vratiSveGrupeRequest;
        this.sviProfesori = vratiSveProfesoreRequest;
        this.sviUcenici = vratiSveUcenikeRequest;
        this.svePrijaveZaUpis = vratiSvePrijaveZaUpisRequest;
        this.sveLokacije = vratiSveLokacijeRequest;
        this.sviUzrasti = vratiSveUzrasteRequest;

        if (!!this.uceniciCrud) {
          this.uceniciCrud.dataSource.data = this.sviUcenici;
        }

        if (!!this.profesoriCrud) {
          this.profesoriCrud.dataSource.data = this.sviProfesori;
        }

        if (!!this.grupeCrud) {
          this.sveGrupeTable = [];
          this.sveGrupe.forEach(g => {
            let grupaTable = {
              id: g.id,
              vremeOdrzavanjaCasa: g.danOdrzavanjaCasa + ", " + g.vremeOdrzavanjaCasa,
              lokacija: g.lokacija.naziv,
              uzrast: g.uzrast.naziv,
              profesor: g.profesor.ime + " " + g.profesor.prezime
            }
            this.sveGrupeTable.push(grupaTable);
          })

          this.grupeCrud.dataSource.data = this.sveGrupeTable;
        }

        if(!!this.prijaveCrud) {
          this.prijaveCrud.dataSource.data = this.svePrijaveZaUpis;
        }

        this.loading = false;
      });
  }

  vratiBrojMladjihOsnovaca(): number {
    let idGrupeMladjihOsnovaca = this.sveGrupe.filter(g => g.uzrast?.sifra == SifraUzrasta.MladjiOsnovci.toString()).map(g => g.id);
    let mladjiOsnovci = this.sviUcenici.filter(u => idGrupeMladjihOsnovaca.includes(u.grupa.id))
    return mladjiOsnovci.length;
  }

  vratiBrojStarijihOsnovaca(): number {
    let idGrupeStarijihOsnovaca = this.sveGrupe.filter(g => g.uzrast?.sifra == SifraUzrasta.StarijiOsnovci.toString()).map(g => g.id);
    let starijiOsnovci = this.sviUcenici.filter(u => idGrupeStarijihOsnovaca.includes(u.grupa.id))
    return starijiOsnovci.length;
  }

  vratiBrojSrednjoskolaca(): number {
    let idGrupeSrednjoskolaca = this.sveGrupe.filter(g => g.uzrast?.sifra == SifraUzrasta.Srednjoskolci.toString()).map(g => g.id);
    let srednjoskolci = this.sviUcenici.filter(u => idGrupeSrednjoskolaca.includes(u.grupa.id))
    return srednjoskolci.length;
  }

  vratiBrojGrupaZaLokaciju(lokacijaId: number) {
    return this.sveGrupe.filter(g => g.lokacija?.id == lokacijaId).length;
  }

  vratiBrojNeprocitanihPrijava(): number {
    return this.svePrijaveZaUpis.filter(p => !p.procitano).length;
  }

  vratiBrojNerazresenihPrijava(): number {
    return this.svePrijaveZaUpis.filter(p => !p.razreseno).length;
  }

  ngOnDestroy(): void {
    if (!!this.inicijalniPodaciSub) { this.inicijalniPodaciSub.unsubscribe() }
  }
}
