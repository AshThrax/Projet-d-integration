
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ComplexeService } from '../../../../service/ComplexeService/complexe.service';
import { UpdateComplexe } from '../../../../class/complexe';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-updt-complexe',
  templateUrl: './updt-complexe.component.html',
  styleUrl: './updt-complexe.component.css'
})
export class UpdtComplexeComponent implements OnInit {
  @Input()
  existingComplexe!: UpdateComplexe;
  //----
  ComplexeForm!: FormGroup;
  idComplexe!: number;
  constructor(
    private fb: FormBuilder,
    private Comps: ComplexeService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
     this.route.queryParams.subscribe(params => { this.idComplexe = params['id'] });
    this.initForm();
  }
   initForm(): void
  { 
     this.ComplexeForm = this.fb.group({
      id:[this.existingComplexe.id, ],
      name:[this.existingComplexe.name, Validators.required],
      decription: [this.existingComplexe.description, Validators.required],
      adress: [this.existingComplexe.address,Validators.required]
    });
  } 
   onSubmit(): void { 
    if (this.ComplexeForm.valid) { 
      const updtComplexe: UpdateComplexe = this.ComplexeForm.value as UpdateComplexe;
      this.Comps.update(this.idComplexe,updtComplexe);
    }
  }
}
