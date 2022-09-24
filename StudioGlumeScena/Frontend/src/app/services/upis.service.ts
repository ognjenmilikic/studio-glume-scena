import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PrijavaZaUpis } from '../models/prijava-za-upis.model';

@Injectable({
  providedIn: 'root'
})
export class UpisService {

  api: string = environment.api;
  controllerName: string = 'PrijavaZaUpis/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  prijavaZaUpis(prijava: PrijavaZaUpis): Observable<PrijavaZaUpis>{
    return this.http.post<PrijavaZaUpis>(this.controllerEndopint + 'NovaPrijava', prijava);
  }

  vratiSvePrijaveZaUpis(): Observable<PrijavaZaUpis[]>{
    return this.http.get<PrijavaZaUpis[]>(this.controllerEndopint + 'VratiSvePrijaveZaUpis');
  }

  odbaciPrijavu(id: number): Observable<boolean>{
    return this.http.get<boolean>(this.controllerEndopint + 'OdbaciPrijavu/' + id);
  }

  oznaciKaoProcitano(id: number): Observable<boolean>{
    return this.http.get<boolean>(this.controllerEndopint + 'OznaciKaoProcitano/' + id);
  }

  razresiPrijavu(id: number): Observable<boolean>{
    return this.http.get<boolean>(this.controllerEndopint + 'RazresiPrijavu/' + id);
  }
}
