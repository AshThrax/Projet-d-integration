import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LstComplexeComponent } from './lst-complexe.component';

describe('LstComplexeComponent', () => {
  let component: LstComplexeComponent;
  let fixture: ComponentFixture<LstComplexeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LstComplexeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LstComplexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
