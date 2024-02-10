import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddRepresentation, Representation } from '../../class/representation';
import { AddPiece, Piece, UpdatePiece } from '../../class/piece';

@Injectable({
  providedIn: 'root'
})
export class PieceService {

ApiUri: string ='https://localhost:44364/api/Piece';
  constructor(public http: HttpClient) { }
///api/Piece
  get(): Observable<Piece[]>
  {
    return this.http.get<Piece[]>(this.ApiUri);
  }
   getbyid(): Observable<Piece>
  {
    return this.http.get<Piece>(this.ApiUri);
   }
  getbyComplexe(id: number):Observable<Piece[]> {
    return this.http.get<Piece[]>(`${this.ApiUri}/get-complexe/${id}`);
  }
  create(data: AddPiece):void
  {
    this.http.post<AddPiece>(this.ApiUri,data);
  }
  Addrepresentation(idPiece:number,data: AddRepresentation):void
  {
    this.http.post<AddRepresentation>(`${ this.ApiUri }/add-representation/${idPiece}`,data);
  }
  update(id:number,data: UpdatePiece):void
  {
     this.http.put<UpdatePiece>(`${this.ApiUri}${id}`,data);
  }
  delete(data: Piece):void
  {
    this.http.delete<Piece>(this.ApiUri);
  }
 deleteRepresentation(idPiece:number,idrepresentation:number):void
  {
    this.http.delete<Piece>(`${this.ApiUri}/delete-representation/${idPiece}/${idrepresentation}`);
  }
}
