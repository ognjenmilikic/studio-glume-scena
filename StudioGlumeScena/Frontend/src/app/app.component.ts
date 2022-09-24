import { Component, HostListener } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { PromenaLozinkeDialogComponent } from './promena-lozinke-dialog/promena-lozinke-dialog.component';
import { JwtService } from './services/jwt.service';
import { SifraKorisnickeUloge } from './shared/enums/enums';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private jwtService: JwtService, private dialog: MatDialog, private router: Router) { }

  @HostListener('window:scroll', ['$event'])
  onScroll(): void {
    let element = document.querySelector('.navbar') as HTMLElement;
    if (window.pageYOffset > element.clientHeight) {
      element.classList.add('navbar-scrolled');
    } else {
      element.classList.remove('navbar-scrolled');
    }
  }

  userAuthenticated(): boolean {
    return this.jwtService.isLoggedIn();
  }

  administratorUlogovan(): boolean {
    return this.jwtService.vratiSifruKorisnickeUloge() == SifraKorisnickeUloge.Administrator.toString();
  }

  profesorUlogovan(): boolean {
    return this.jwtService.vratiSifruKorisnickeUloge() == SifraKorisnickeUloge.Profesor.toString();
  }

  ucenikUlogovan(): boolean {
    return this.jwtService.vratiSifruKorisnickeUloge() == SifraKorisnickeUloge.Ucenik.toString();
  }

  vratiImeIPrezimeKorisnika(): string {
    return this.jwtService.vratiImeIPrezimeKorisnika();
  }

  promenaLozinke(): void {
    this.dialog.open(PromenaLozinkeDialogComponent);
  }

  logout(): void {
    this.jwtService.clearToken();
    this.router.navigate(['']);
  }
}
