import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDocs } from './view-docs';

describe('ViewDocs', () => {
  let component: ViewDocs;
  let fixture: ComponentFixture<ViewDocs>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewDocs],
    }).compileComponents();

    fixture = TestBed.createComponent(ViewDocs);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
