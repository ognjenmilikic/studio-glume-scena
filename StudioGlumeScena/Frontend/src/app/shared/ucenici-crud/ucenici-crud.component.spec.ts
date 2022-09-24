import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UceniciCrudComponent } from './ucenici-crud.component';

describe('UceniciCrudComponent', () => {
  let component: UceniciCrudComponent;
  let fixture: ComponentFixture<UceniciCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UceniciCrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UceniciCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
