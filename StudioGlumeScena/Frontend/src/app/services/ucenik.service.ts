import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profesor } from '../models/profesor.model';
import { Ucenik } from '../models/ucenik.model';

@Injectable({
  providedIn: 'root'
})
export class UcenikService {

  api: string = environment.api;
  controllerName: string = 'Ucenik/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  vratiSveUcenike(): Observable<Ucenik[]>{
    return this.http.get<Ucenik[]>(this.controllerEndopint + 'VratiSve');
  }

  vratiUcenikaZaIdKorisnika(korisnikId: number): Observable<Ucenik>{
    return this.http.get<Ucenik>(this.controllerEndopint + 'VratiUcenikaZaIdKorisnika/' + korisnikId);
  }

  obrisiUcenika(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.controllerEndopint + "ObrisiUcenika/" + id);
  }

  sacuvajUcenika(ucenik: Ucenik): Observable<Ucenik>{
    return this.http.post<Ucenik>(this.controllerEndopint + "SacuvajUcenika", ucenik);
  }
}
