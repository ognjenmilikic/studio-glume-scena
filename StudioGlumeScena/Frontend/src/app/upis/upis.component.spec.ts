import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpisComponent } from './upis.component';

describe('UpisComponent', () => {
  let component: UpisComponent;
  let fixture: ComponentFixture<UpisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
