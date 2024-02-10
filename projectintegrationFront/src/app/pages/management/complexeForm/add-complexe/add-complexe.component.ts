import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ComplexeService } from '../../../../service/ComplexeService/complexe.service';
import { AddComplexe } from '../../../../class/complexe';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-complexe',
  templateUrl: './add-complexe.component.html',
  styleUrl: './add-complexe.component.css'
})
export class AddComplexeComponent implements OnInit {
  ComplexeForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
     private Routes: ActivatedRoute,
    private Comps: ComplexeService) { }

  ngOnInit(): void {
    this.Routes;
    this.initForm();
  }
  initForm(): void
  { 
    this.ComplexeForm = this.fb.group({
      name:['', Validators.required],
      decription: ['', Validators.required],
      adress: ['',Validators.required]
    });
  } 
  onSubmit(): void { 
    if (this.ComplexeForm.valid) { 
      const addComplexe: AddComplexe = this.ComplexeForm.value as AddComplexe;
      this.Comps.create(addComplexe);
    }
  }
}
