import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentinenceDesginComponent } from './mentinence-desgin.component';

describe('MentinenceDesginComponent', () => {
  let component: MentinenceDesginComponent;
  let fixture: ComponentFixture<MentinenceDesginComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentinenceDesginComponent]
    });
    fixture = TestBed.createComponent(MentinenceDesginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
