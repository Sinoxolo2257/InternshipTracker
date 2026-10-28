import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewApplication } from './view-application';

describe('ViewApplication', () => {
  let component: ViewApplication;
  let fixture: ComponentFixture<ViewApplication>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewApplication],
    }).compileComponents();

    fixture = TestBed.createComponent(ViewApplication);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
