import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesoriCrudComponent } from './profesori-crud.component';

describe('ProfesoriCrudComponent', () => {
  let component: ProfesoriCrudComponent;
  let fixture: ComponentFixture<ProfesoriCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfesoriCrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfesoriCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
