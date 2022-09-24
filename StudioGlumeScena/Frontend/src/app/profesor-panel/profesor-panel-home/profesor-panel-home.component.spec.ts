import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesorPanelHomeComponent } from './profesor-panel-home.component';

describe('ProfesorPanelHomeComponent', () => {
  let component: ProfesorPanelHomeComponent;
  let fixture: ComponentFixture<ProfesorPanelHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfesorPanelHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfesorPanelHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
