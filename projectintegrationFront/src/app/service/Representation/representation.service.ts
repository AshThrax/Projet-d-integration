import { AddRepresentation, UpdateRepresentation} from './../../class/representation';
import { Injectable } from '@angular/core';
import { Representation } from '../../class/representation';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Command, addCommand } from '../../class/command';

@Injectable({
  providedIn: 'root'
})
export class RepresentationService {

 ApiUri: string ='https://localhost:44364/api/Representation';
  constructor(public http: HttpClient) { }

  get(): Observable<Representation[]>
  {
    return this.http.get<Representation[]>(this.ApiUri+'/api/Representation');
  }
   getbyid(id:number): Observable<Representation>
  {
    return this.http.get<Representation>(`${this.ApiUri}/${id}`);
  }
  create(data: AddRepresentation):void
  {

    this.http.post<AddRepresentation>(this.ApiUri, data);
  }
  update(data: UpdateRepresentation):void
  {
     this.http.put<UpdateRepresentation>(this.ApiUri, data);
  }
  delete(id:number):void
  {
    this.http.delete<Representation>(`${this.ApiUri}/${id}`);
  }
  //---update par rapport au modification
  getSalle(idsalle: number): Observable<Representation[]> {
    return this.http.get<Representation[]>(`${this.ApiUri}/get-salle/${idsalle}`);
  }
   getPiece(idPiece: number): Observable<Representation[]> {
     return this.http.get<Representation[]>(`${this.ApiUri}/get-piece/${idPiece}`);
  }
  addCommandRepresentation(id:number,data: addCommand): void
  {
    this.http.post<addCommand>(`${this.ApiUri}/add-command/${id}`,data);
  }
    deleteCommandRepresentation(idrep:number,idCommand:number):void
  {
    this.http.delete<Representation>(`${this.ApiUri}/delete-command/${idrep}/${idCommand}`);
  }
}
