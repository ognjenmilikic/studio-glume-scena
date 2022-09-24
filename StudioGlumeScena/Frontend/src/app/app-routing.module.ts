import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { PredstaveComponent } from './predstave/predstave.component';
import { SifraKorisnickeUloge } from './shared/enums/enums';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { UpisComponent } from './upis/upis.component';

const routes: Routes = [
  { path: "predstave", component: PredstaveComponent },
  { path: "upis", component: UpisComponent },
  { path: "kontakt", component: KontaktComponent },
  { path: "login", component: LoginComponent },
  { path: "neautorizovanPristup", component: UnauthorizedComponent },
  {
    path: "admin-panel",
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    loadChildren: () => import('./admin-panel/admin-panel.module').then(m => m.AdminPanelModule),
    data: {
      sifraUloge: SifraKorisnickeUloge.Administrator.toString()
    }
  },
  {
    path: "profesor-panel",
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    loadChildren: () => import('./profesor-panel/profesor-panel.module').then(m => m.ProfesorPanelModule),
    data: {
      sifraUloge: SifraKorisnickeUloge.Profesor.toString()
    }
  },
  {
    path: "ucenik-panel",
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    loadChildren: () => import('./ucenik-panel/ucenik-panel.module').then(m => m.UcenikPanelModule),
    data: {
      sifraUloge: SifraKorisnickeUloge.Ucenik.toString()
    }
  },
  { path: "", component: HomeComponent },
  { path: "**", component: NotFoundComponent }
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
