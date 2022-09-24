import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupeCrudComponent } from './grupe-crud.component';

describe('GrupeCrudComponent', () => {
  let component: GrupeCrudComponent;
  let fixture: ComponentFixture<GrupeCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GrupeCrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GrupeCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
