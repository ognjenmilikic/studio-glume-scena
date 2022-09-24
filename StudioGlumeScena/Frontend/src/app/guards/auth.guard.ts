import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivateChild } from "@angular/router";
import { JwtService } from "../services/jwt.service";

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(
    private router: Router,
    private jwtService: JwtService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
      let isLoggedIn = this.jwtService.isLoggedIn();

      if (isLoggedIn) {
        if (this.imaPravoPristupa(route)) {
          return true;
        }
        else {
          this.router.navigate(['/neautorizovanPristup']);
          return false;
        }
      }
      else {
        this.router.navigate(["login"]);
        return false;
      }
  }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.canActivate(childRoute, state);
  }

  imaPravoPristupa(route: ActivatedRouteSnapshot): boolean {
    if (!!!route.data || !!!route.data.sifraUloge) {
      return true;
    }
    else {
      return this.jwtService.imaSifruUloge(route.data.sifraUloge);
    }
  }
}
