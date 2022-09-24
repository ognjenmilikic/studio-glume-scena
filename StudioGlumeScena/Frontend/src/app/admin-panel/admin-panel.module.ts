import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPanelRoutingModule } from './admin-panel-routing.module';
import { AdminPanelHomeComponent } from './admin-panel-home/admin-panel-home.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SharedModule } from '../shared/shared.module';
import { ProfesoriCrudComponent } from './profesori-crud/profesori-crud.component';
import { ProfesorDialogComponent } from './profesori-crud/profesor-dialog/profesor-dialog.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { GrupeCrudComponent } from './grupe-crud/grupe-crud.component';
import { GrupaDialogComponent } from './grupe-crud/grupa-dialog/grupa-dialog.component';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { PrijaveZaUpisCrudComponent } from './prijave-za-upis-crud/prijave-za-upis-crud.component';
import { MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
  declarations: [
    AdminPanelHomeComponent,
    ProfesoriCrudComponent,
    ProfesorDialogComponent,
    GrupeCrudComponent,
    GrupaDialogComponent,
    PrijaveZaUpisCrudComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule,
    AdminPanelRoutingModule,
    SharedModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatInputModule,
    MatIconModule,
    ReactiveFormsModule,
    MatOptionModule,
    MatSelectModule,
    NgxMaterialTimepickerModule,
    MatTooltipModule
  ]
})
export class AdminPanelModule { }
