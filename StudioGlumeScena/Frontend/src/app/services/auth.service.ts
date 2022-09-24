import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginCredentials } from '../models/loginCredentials.model';
import { Observable } from 'rxjs';
import { AuthenticatedResponse } from '../models/authenticatedResponse.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  api: string = environment.api;
  controllerName: string = 'Auth/';
  controllerEndopint = this.api + this.controllerName;

  constructor(private http: HttpClient) { }

  login(LoginCredentials: LoginCredentials): Observable<AuthenticatedResponse>{
    return this.http.post<AuthenticatedResponse>(this.controllerEndopint + 'Login', LoginCredentials);
  }
}
