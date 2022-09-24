import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subscription } from 'rxjs';
import { LoginCredentials } from '../models/loginCredentials.model';
import { AuthService } from '../services/auth.service';
import { JwtService } from '../services/jwt.service';
import { SifraKorisnickeUloge } from '../shared/enums/enums';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  loginForm: FormGroup;
  authSub: Subscription;
  lozinkaVidljiva: boolean = false;

  constructor(private authService: AuthService, private snackBar: MatSnackBar,
    private jwtService: JwtService, private router: Router, private jwtHelperService: JwtHelperService) { }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)])
    })
  }

  vratiImeIPrezimeKorisnika(): string {
    return this.jwtService.vratiImeIPrezimeKorisnika();
  }

  korisnikUlogovan(): boolean {
    return this.jwtService.isLoggedIn();
  }

  promeniVidljivostLozinke(): void {
    this.lozinkaVidljiva = !this.lozinkaVidljiva;
  }

  login(): void {
    this.authSub = this.authService.login(this.loginForm.value as LoginCredentials).subscribe(
      res => {
        this.jwtService.setToken(res.token);
        let sifraUloge = this.jwtHelperService.decodeToken(res.token).SifraUloge;
        if (sifraUloge == SifraKorisnickeUloge.Administrator.toString()) {
          this.router.navigate(["admin-panel"]);
        }
        else if (sifraUloge == SifraKorisnickeUloge.Profesor.toString()) {
          this.router.navigate(["profesor-panel"]);
        }
        else if (sifraUloge == SifraKorisnickeUloge.Ucenik.toString()) {
          this.router.navigate(["ucenik-panel"]);
        }
      },
      error => {
        this.snackBar.open(error.error, null, { duration: 5000, panelClass: ['error-snackbar']})
      }
    )
  }

  ngOnDestroy(): void {
    if(!!this.authSub) { this.authSub.unsubscribe() }
  }

}
