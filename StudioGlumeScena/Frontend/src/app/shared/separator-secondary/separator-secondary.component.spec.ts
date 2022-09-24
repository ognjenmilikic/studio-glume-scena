import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeparatorSecondaryComponent } from './separator-secondary.component';

describe('SeparatorSecondaryComponent', () => {
  let component: SeparatorSecondaryComponent;
  let fixture: ComponentFixture<SeparatorSecondaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeparatorSecondaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeparatorSecondaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
