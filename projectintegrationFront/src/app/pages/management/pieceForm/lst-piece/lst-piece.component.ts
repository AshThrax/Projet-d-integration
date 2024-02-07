import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PieceService } from '../../../../service/Piece/piece.service';
import { Piece } from '../../../../class/piece';

@Component({
  selector: 'app-lst-piece',
  templateUrl: './lst-piece.component.html',
  styleUrl: './lst-piece.component.css'
})
export class LstPieceComponent implements OnInit {
  idPiece!: number;
  pieceitems: Piece[] = [];
   isThisFill: boolean = false;
  constructor(
    private route: Router,
    private routed: ActivatedRoute,
    private service:PieceService
    ) { 
      
  }
  //renvoie la liste des representation a laquel 
  //la pièce souscrit
    GetRepresentation(id:number) {
      this.route.navigate(['representaion/list'],
        { queryParams: { id: id } });
  }
  //renvoie le composant avec lequel on rajoute une represnatation
    AddRepresentation(id:number) {
      this.route.navigate(['representaion/add'],
        { queryParams: { id: id } });
    }
    
  ngOnInit(): void {
    //recuperation de l'id lié au pièece
      this.routed.queryParams
        .subscribe((params) => {
          this.idPiece = +params['id']
        });
    
    this.service.get()//par 
      .subscribe((params: Piece[]) =>
      { 
        this.pieceitems = params;
        this.isThisFill = true;
      })
  }
}
