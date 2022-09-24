import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { UcenikPanelRoutingModule } from './ucenik-panel-routing.module';
import { UcenikPanelHomeComponent } from './ucenik-panel-home/ucenik-panel-home.component';

@NgModule({
  declarations: [
    UcenikPanelHomeComponent
  ],
  imports: [
    CommonModule,
    UcenikPanelRoutingModule,
    SharedModule
  ]
})
export class UcenikPanelModule { }
