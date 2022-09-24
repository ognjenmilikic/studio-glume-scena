import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profesor } from '../models/profesor.model';

@Injectable({
  providedIn: 'root'
})
export class ProfesorService {

  api: string = environment.api;
  controllerName: string = 'Profesor/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  vratiSveProfesore(): Observable<Profesor[]>{
    return this.http.get<Profesor[]>(this.controllerEndopint + 'VratiSve');
  }

  obrisiProfesora(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.controllerEndopint + "ObrisiProfesora/" + id);
  }

  sacuvajProfesora(profesor: Profesor): Observable<Profesor>{
    return this.http.post<Profesor>(this.controllerEndopint + "SacuvajProfesora", profesor);
  }
}
