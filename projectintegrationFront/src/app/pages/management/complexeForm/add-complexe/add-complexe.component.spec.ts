import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComplexeComponent } from './add-complexe.component';

describe('AddComplexeComponent', () => {
  let component: AddComplexeComponent;
  let fixture: ComponentFixture<AddComplexeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddComplexeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddComplexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
