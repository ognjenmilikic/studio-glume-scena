import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PromenaLozinkeRequest } from '../models/promenaLozinkeRequest.model';

@Injectable({
  providedIn: 'root'
})
export class KorisnikService {

  api: string = environment.api;
  controllerName: string = 'Korisnik/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  promeniLozinku(promenaLozinkeRequest: PromenaLozinkeRequest): Observable<boolean>{
    return this.http.post<boolean>(this.controllerEndopint + 'PromeniLozinku', promenaLozinkeRequest);
  }
}
