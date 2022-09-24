import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UcenikDialogComponent } from './ucenik-dialog.component';

describe('UcenikDialogComponent', () => {
  let component: UcenikDialogComponent;
  let fixture: ComponentFixture<UcenikDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UcenikDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UcenikDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
