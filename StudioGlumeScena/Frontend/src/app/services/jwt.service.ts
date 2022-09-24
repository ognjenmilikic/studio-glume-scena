import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedUser } from '../models/authenticatedUser.model';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  constructor(private jwtHelper: JwtHelperService) { }

  setToken(token: string): void {
    localStorage.setItem("jwt", token)
  }

  getToken(): string {
    return localStorage.getItem("jwt");
  }

  isLoggedIn(): boolean {
    let token = this.getToken();

    return !!token && !this.jwtHelper.isTokenExpired(token);
  }

  getLoggedUser(): AuthenticatedUser {
    return this.jwtHelper.decodeToken<AuthenticatedUser>(this.getToken());
  }

  vratiSifruKorisnickeUloge(): string {
    return this.getLoggedUser()?.SifraUloge;
  }

  imaSifruUloge(sifraUloge: string): boolean {
    return this.vratiSifruKorisnickeUloge() == sifraUloge;
  }

  vratiImeIPrezimeKorisnika(): string {
    let user = this.getLoggedUser();
    return user.Ime + " " + user.Prezime;
  }

  vratiIdKorisnika(): string {
    return this.getLoggedUser().KorisnikId
  }

  clearToken(): void {
    localStorage.removeItem("jwt");
  }
}
