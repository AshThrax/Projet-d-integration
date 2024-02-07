import { AddPiece } from './../../../../class/piece';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SalledetheatreService } from '../../../../service/SalledeTheatre/SalledeTheatre.service';


@Component({
  selector: 'app-add-piece',
  templateUrl: './add-piece.component.html',
  styleUrl: './add-piece.component.css'
})
export class AddPieceComponent implements OnInit{
  idsalle!: number;
  PieceForm!: FormGroup;

  constructor
    (private fb: FormBuilder,
      private route: ActivatedRoute,
      private PieceServ: SalledetheatreService
  ) { }
  
    ngOnInit(): void {
      this.route.params.subscribe(params => {
        this.idsalle = +params['id'];
       });
      this.initForm();
  }
  initForm(): void
  { 
    this.PieceForm = this.fb.group({
      titre: ['',Validators.required],
      duree: ['',Validators.required],
      description:['',Validators.required]
    });
  }
  onSubmit(): void { 
    if (!this.PieceForm.invalid) { 
      const addPiece: AddPiece = this.PieceForm.value as AddPiece;
      //ajout d'une piece de theatre a notre salle de theatre
      this.PieceServ.addPiece(this.idsalle,addPiece);
    }
  }
}
