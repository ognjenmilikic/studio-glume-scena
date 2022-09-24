import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelHomeComponent } from './admin-panel-home/admin-panel-home.component';

const routes: Routes = [
  {
    path: "", component: AdminPanelHomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminPanelRoutingModule { }
