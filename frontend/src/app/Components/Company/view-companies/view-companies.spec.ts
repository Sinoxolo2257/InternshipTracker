import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCompanies } from './view-companies';

describe('ViewCompanies', () => {
  let component: ViewCompanies;
  let fixture: ComponentFixture<ViewCompanies>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewCompanies],
    }).compileComponents();

    fixture = TestBed.createComponent(ViewCompanies);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
