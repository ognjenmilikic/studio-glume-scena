import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfesorPanelRoutingModule } from './profesor-panel-routing.module';
import { ProfesorPanelHomeComponent } from './profesor-panel-home/profesor-panel-home.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SharedModule } from '../shared/shared.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { ZadajNoviZadatakDialogComponent } from './zadaj-novi-zadatak-dialog/zadaj-novi-zadatak-dialog.component';

@NgModule({
  declarations: [
    ProfesorPanelHomeComponent,
    ZadajNoviZadatakDialogComponent
  ],
  imports: [
    CommonModule,
    ProfesorPanelRoutingModule,
    MatProgressSpinnerModule,
    SharedModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule
  ]
})
export class ProfesorPanelModule { }
