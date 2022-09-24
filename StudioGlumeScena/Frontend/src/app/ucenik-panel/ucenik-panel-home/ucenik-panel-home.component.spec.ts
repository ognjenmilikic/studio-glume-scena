import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UcenikPanelHomeComponent } from './ucenik-panel-home.component';

describe('UcenikPanelHomeComponent', () => {
  let component: UcenikPanelHomeComponent;
  let fixture: ComponentFixture<UcenikPanelHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UcenikPanelHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UcenikPanelHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
