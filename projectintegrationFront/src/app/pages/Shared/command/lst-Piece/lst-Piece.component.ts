import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Piece } from '../../../../class/piece';
import { PieceService } from '../../../../service/Piece/piece.service';
@Component({
  selector: 'app-lst-Piece',
  templateUrl: './lst-Piece.component.html',
  styleUrls: ['./lst-Piece.component.css']
})
export class LstPieceComponent implements OnInit {
idComplexe!: number;
  Pieceitems: Piece[]=[]
IsitemFill: boolean = false;
  constructor(
    private route: Router,
    private Routed: ActivatedRoute
    , private Ps: PieceService) {

   }

  ngOnInit() {
    this.Routed.queryParams
      .subscribe(params => { this.idComplexe = params['id'] });
    this.GetByCompelxe(this.idComplexe);
  }

  GetByCompelxe(id: number) {
    this.Ps.getbyComplexe(id)
      .subscribe((data: Piece[]) => {
        this.Pieceitems = data;
        this.IsitemFill = true;
    });
  }
  getRepresentation(id:number): void
  { 
     this.route.navigate(['representation'],{ queryParams: { id: id } });
  }
}
