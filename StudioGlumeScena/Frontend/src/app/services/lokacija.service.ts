import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lokacija } from '../models/lokacija.model';

@Injectable({
  providedIn: 'root'
})
export class LokacijaService {

  api: string = environment.api;
  controllerName: string = 'Lokacija/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  vratiSveLokacije(): Observable<Lokacija[]>{
    return this.http.get<Lokacija[]>(this.controllerEndopint + 'VratiSveLokacije');
  }
}
