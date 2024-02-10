import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Command, UpdateCommand,addCommand} from '../../class/command';

@Injectable({
  providedIn: 'root'
})
export class CommandService {

ApiUri: string ='https://localhost:44364/api/Command';
  constructor(public http: HttpClient) { }

  get(): Observable<Command[]>
  {
    return this.http.get<Command[]>(this.ApiUri);
  }
   getAuth(): Observable<string>
  {
    return this.http.get<string>(`${this.ApiUri}/get-auth`);
  }
   getbyid(id:number): Observable<Command>
  {
    return this.http.get<Command>(`${this.ApiUri}/${id}`);
   }
   getbyUser(): Observable<Command[]>
  {
    return this.http.get<Command[]>(`${this.ApiUri}/get-command-user/`);
   }
  getbyPiece(idPiece:number): Observable<Command[]>
  {
    return this.http.get<Command[]>(`${this.ApiUri}/get-piece/${idPiece}`);
  }
  create(data: addCommand):void
  {

    this.http.post<addCommand>(this.ApiUri,data);
  }
  update(id:number,data: UpdateCommand):void
  {
     this.http.put<UpdateCommand>(`${this.ApiUri}/${id}`,data);
  }
  delete(id:number):void
  {
    this.http.delete<Command>(`${this.ApiUri}/${id}`);
  }
}
