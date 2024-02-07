import { ActivatedRoute } from '@angular/router';
import { UpdatePiece } from './../../../../class/piece';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PieceService } from '../../../../service/Piece/piece.service';

@Component({
  selector: 'app-updt-piece',
  templateUrl: './updt-piece.component.html',
  styleUrl: './updt-piece.component.css'
})
export class UpdtPieceComponent implements OnInit {
  @Input() exisitingPiece!: UpdatePiece;
  PieceForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private Routes: ActivatedRoute,
    private pieceServ: PieceService) { }

  ngOnInit(): void
  { 
    this.Routes;//
    this.initForm();
  }
  private initForm(): void {
    this.PieceForm = this.fb.group({
      id: [this.exisitingPiece.id, Validators.required],
      titre: [this.exisitingPiece. titre, Validators.required],
      description: [this.exisitingPiece.description, Validators.required],
      duree: [this.exisitingPiece. duree, Validators.required],
    });
  }
  onSubmit() { 
    if (this.PieceForm.valid) { 
      const updtPiece: UpdatePiece = this.PieceForm.value as UpdatePiece;
      //mise a jour de l'entité piéce de theatre
      this.pieceServ.update(this.exisitingPiece.id, updtPiece);
    }
  }
}
