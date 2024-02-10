import { ComplexeService } from './../../../../service/ComplexeService/complexe.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddSalleDeTheatre, SalleDeTheatre } from './../../../../class/salledetheatre';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-salle',
  templateUrl: './add-salle.component.html',
  styleUrl: './add-salle.component.css'
})
export class AddSalleComponent implements OnInit{
  idcomplexe !:number;
  salleDeTheatreForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private routes: ActivatedRoute,
    private service: ComplexeService

  ) { }
  
  ngOnInit(): void {
    this.routes.queryParams.subscribe(
      params => {
        this.idcomplexe = params['id'];
      });
    this.initForm();
  }
  initForm(): void
  { 
    this.salleDeTheatreForm = this.fb.group(
      {  
      name: ['', Validators.required],
      placeMax: ['', [Validators.required, Validators.min(0)]],
      placeCurrent: ['', [Validators.required, Validators.min(0)]],
      complexeId: [this.idcomplexe, Validators.required],
      }
    );
  }
  
  onSubmit(): void {
    if (this.salleDeTheatreForm.valid) {
      const salleDeTheatreData: AddSalleDeTheatre = this.salleDeTheatreForm.value as AddSalleDeTheatre;
      // Perform form submission logic, e.g., send data to the backend
      this.service.addsalle(this.idcomplexe, salleDeTheatreData);
      console.log(salleDeTheatreData);
    }

  }
}
