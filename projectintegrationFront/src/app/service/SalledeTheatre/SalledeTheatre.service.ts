import { Injectable } from '@angular/core';
import { AddSalleDeTheatre, SalleDeTheatre, UpdateSalleDeTheatre } from '../../class/salledetheatre';
import { HttpClient} from '@angular/common/http';
import { Observable} from 'rxjs';
import { AddPiece } from '../../class/piece';
@Injectable({
  providedIn: 'root'
})
export class SalledetheatreService {

ApiUri: string ='https://localhost:44364/api/SallesDeThéatre';
  constructor(public http: HttpClient) { }

  get(): Observable<SalleDeTheatre[]>
  {
    return this.http.get<SalleDeTheatre[]>(this.ApiUri);
  }
   getbyid(id:number): Observable<SalleDeTheatre>
  {
    return this.http.get<SalleDeTheatre>(`${this.ApiUri }/${id}`);
  }
  create(data: AddSalleDeTheatre):void
  {

    this.http.post<AddSalleDeTheatre>(`${this.ApiUri}`,data);
  }
  addPiece(idsalle:number,data: AddPiece):void
  {

    this.http.post<AddPiece>(`${ this.ApiUri }/add-piece/${idsalle}`,data);
  }
  update(id:number,data: UpdateSalleDeTheatre):void
  {
     this.http.put<UpdateSalleDeTheatre>(`${ this.ApiUri }/${id}`,data);
  }
  delete(Iddata: number):void
  {
    this.http.delete<SalleDeTheatre>(`${ this.ApiUri }/${Iddata}`);
  }
}
