import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfesorPanelHomeComponent } from './profesor-panel-home/profesor-panel-home.component';

const routes: Routes = [
  {
    path: "", component: ProfesorPanelHomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfesorPanelRoutingModule { }
