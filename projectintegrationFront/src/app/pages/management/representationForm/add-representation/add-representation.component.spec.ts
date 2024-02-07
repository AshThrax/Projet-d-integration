import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRepresentationComponent } from './add-representation.component';

describe('AddRepresentationComponent', () => {
  let component: AddRepresentationComponent;
  let fixture: ComponentFixture<AddRepresentationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddRepresentationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddRepresentationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
