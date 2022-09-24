import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UcenikPanelHomeComponent } from './ucenik-panel-home/ucenik-panel-home.component';

const routes: Routes = [
  {
    path: "", component: UcenikPanelHomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UcenikPanelRoutingModule { }
