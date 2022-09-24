import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ZadajNoviZadatakDialogComponent } from './zadaj-novi-zadatak-dialog.component';

describe('ZadajNoviZadatakDialogComponent', () => {
  let component: ZadajNoviZadatakDialogComponent;
  let fixture: ComponentFixture<ZadajNoviZadatakDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ZadajNoviZadatakDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ZadajNoviZadatakDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
