import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RepresentationService } from '../../../../service/Representation/representation.service';
import { Representation } from '../../../../class/representation';

@Component({
  selector: 'app-representation-lst',
  templateUrl: './representation-lst.component.html',
  styleUrl: './representation-lst.component.css'
})
export class RepresentationLstComponent implements OnInit {
  isThisFill: boolean = false;
  idSalle  !: number;
  repitems : Representation[] = [];
  constructor(
    private route: ActivatedRoute,
    private repService: RepresentationService
  )
  { }

  ngOnInit()
  { 
    this.route.queryParams
      .subscribe(params => { this.idSalle = params['id'] });
    this.getFromSalle();
  }
  getFromSalle() { 
      this.repService.getSalle(this.idSalle).subscribe(
      (params: Representation[]) => {
          this.repitems = params;
          this.isThisFill = true;
      });
  }
}
