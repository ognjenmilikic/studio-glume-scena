import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPanelHomeComponent } from './admin-panel-home.component';

describe('AdminPanelHomeComponent', () => {
  let component: AdminPanelHomeComponent;
  let fixture: ComponentFixture<AdminPanelHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminPanelHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminPanelHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
