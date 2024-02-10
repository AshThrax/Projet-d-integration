import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RepresentationLstComponent } from './representation-lst.component';

describe('RepresentationLstComponent', () => {
  let component: RepresentationLstComponent;
  let fixture: ComponentFixture<RepresentationLstComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RepresentationLstComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RepresentationLstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
