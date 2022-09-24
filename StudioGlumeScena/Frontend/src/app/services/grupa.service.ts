import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Grupa } from '../models/grupa.model';
import { Profesor } from '../models/profesor.model';
import { Ucenik } from '../models/ucenik.model';

@Injectable({
  providedIn: 'root'
})
export class GrupaService {

  api: string = environment.api;
  controllerName: string = 'Grupa/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  vratiSveGrupe(): Observable<Grupa[]>{
    return this.http.get<Grupa[]>(this.controllerEndopint + 'VratiSve');
  }

  vratiGrupeZaProfesora(korisnikId: number): Observable<Grupa[]>{
    return this.http.get<Grupa[]>(this.controllerEndopint + 'VratiGrupeZaProfesora/' + korisnikId);
  }

  obrisiGrupu(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.controllerEndopint + "ObrisiGrupu/" + id);
  }

  sacuvajGrupu(grupa: Grupa): Observable<Grupa>{
    return this.http.post<Grupa>(this.controllerEndopint + "SacuvajGrupu", grupa);
  }
}
