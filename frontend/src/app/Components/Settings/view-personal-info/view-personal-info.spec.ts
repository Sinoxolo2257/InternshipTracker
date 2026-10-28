import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPersonalInfo } from './view-personal-info';

describe('ViewPersonalInfo', () => {
  let component: ViewPersonalInfo;
  let fixture: ComponentFixture<ViewPersonalInfo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewPersonalInfo],
    }).compileComponents();

    fixture = TestBed.createComponent(ViewPersonalInfo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
