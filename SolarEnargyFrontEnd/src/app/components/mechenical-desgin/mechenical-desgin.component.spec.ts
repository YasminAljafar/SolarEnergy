import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MechenicalDesginComponent } from './mechenical-desgin.component';

describe('MechenicalDesginComponent', () => {
  let component: MechenicalDesginComponent;
  let fixture: ComponentFixture<MechenicalDesginComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MechenicalDesginComponent]
    });
    fixture = TestBed.createComponent(MechenicalDesginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
