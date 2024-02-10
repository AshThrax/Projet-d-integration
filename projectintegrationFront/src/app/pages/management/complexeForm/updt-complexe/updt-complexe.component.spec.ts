import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdtComplexeComponent } from './updt-complexe.component';

describe('UpdtComplexeComponent', () => {
  let component: UpdtComplexeComponent;
  let fixture: ComponentFixture<UpdtComplexeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdtComplexeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdtComplexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
