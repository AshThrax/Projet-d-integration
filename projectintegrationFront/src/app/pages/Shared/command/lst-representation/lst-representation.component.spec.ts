import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LstRepresentationComponent } from './lst-representation.component';

describe('LstRepresentationComponent', () => {
  let component: LstRepresentationComponent;
  let fixture: ComponentFixture<LstRepresentationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LstRepresentationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LstRepresentationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
