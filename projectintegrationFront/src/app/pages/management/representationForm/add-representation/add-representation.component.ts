import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PieceService } from '../../../../service/Piece/piece.service';
import { AddRepresentation } from '../../../../class/representation';

@Component({
  selector: 'app-add-representation',
  templateUrl: './add-representation.component.html',
  styleUrl: './add-representation.component.css'
})
export class AddRepresentationComponent implements OnInit {
  
  representationForm!: FormGroup;
  idPiece!: number;
  idSalle!: number;
  constructor(
    private fb: FormBuilder,
    private routes: ActivatedRoute,
    private service: PieceService
  ) { }
  ngOnInit(): void
  {
    this.routes.queryParams.subscribe(params =>
    { 
      this.idPiece = params['idpiece'];
      this.idSalle = params['idsalle'];
    })
   this.initForm()
  }

  initForm(): void
  { 
    this.representationForm = this.fb.group(
      {
        
      Prix: ['', [Validators.required, Validators.min(0)]],
      Seance: ['', Validators.required],
      max: ['', Validators.required],
      current:['',Validators.required],
      IdSalleDeTheatre: [this.idSalle, Validators.required],
      IdPiece: [this.idPiece, Validators.required],
      });
  }
  onsubmit(): void
  { 
      if (this.representationForm.valid) { 
      const updtrep: AddRepresentation = this.representationForm.value as AddRepresentation;
      //
      this.service.Addrepresentation(this.idPiece,updtrep);
    }
  }
}
