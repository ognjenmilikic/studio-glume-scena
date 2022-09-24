import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrijaveZaUpisCrudComponent } from './prijave-za-upis-crud.component';

describe('PrijaveZaUpisCrudComponent', () => {
  let component: PrijaveZaUpisCrudComponent;
  let fixture: ComponentFixture<PrijaveZaUpisCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrijaveZaUpisCrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrijaveZaUpisCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
