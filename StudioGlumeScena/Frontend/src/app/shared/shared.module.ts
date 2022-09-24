import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SeparatorComponent } from './separator/separator.component';
import { SeparatorSecondaryComponent } from './separator-secondary/separator-secondary.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { UceniciCrudComponent } from './ucenici-crud/ucenici-crud.component';
import { UcenikDialogComponent } from './ucenici-crud/ucenik-dialog/ucenik-dialog.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { InfoDialogComponent } from './info-dialog/info-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    SeparatorComponent,
    SeparatorSecondaryComponent,
    SpinnerComponent,
    UceniciCrudComponent,
    UcenikDialogComponent,
    ConfirmDialogComponent,
    InfoDialogComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatInputModule,
    MatIconModule,
    MatTooltipModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatSelectModule
  ],
  exports: [
    SeparatorComponent,
    SeparatorSecondaryComponent,
    SpinnerComponent,
    UceniciCrudComponent
  ]
})
export class SharedModule { }
