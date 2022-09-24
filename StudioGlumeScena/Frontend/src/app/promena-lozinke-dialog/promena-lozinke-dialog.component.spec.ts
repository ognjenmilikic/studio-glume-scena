import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PromenaLozinkeDialogComponent } from './promena-lozinke-dialog.component';

describe('PromenaLozinkeDialogComponent', () => {
  let component: PromenaLozinkeDialogComponent;
  let fixture: ComponentFixture<PromenaLozinkeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PromenaLozinkeDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PromenaLozinkeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
