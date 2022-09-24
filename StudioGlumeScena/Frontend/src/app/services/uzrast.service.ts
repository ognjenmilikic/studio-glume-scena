import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Uzrast } from '../models/uzrast.model';

@Injectable({
  providedIn: 'root'
})
export class UzrastService {

  api: string = environment.api;
  controllerName: string = 'Uzrast/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  vratiSveUzraste(): Observable<Uzrast[]>{
    return this.http.get<Uzrast[]>(this.controllerEndopint + 'VratiSve');
  }
}
