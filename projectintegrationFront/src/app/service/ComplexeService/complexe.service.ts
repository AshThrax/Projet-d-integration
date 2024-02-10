import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Complexe, UpdateComplexe ,AddComplexe  } from '../../class/complexe';
import { HttpClient } from '@angular/common/http';
import { AddSalleDeTheatre } from '../../class/salledetheatre';

@Injectable({
  providedIn: 'root'
})
export class ComplexeService {
ApiUri: string ='https://localhost:44364';
  constructor(public http: HttpClient) { }

  get(): Observable<Complexe[]>
  {
    return this.http.get<Complexe[]>(this.ApiUri+'/api/Complexe');
  }
   getbyid(id:number): Observable<Complexe>
  {
    return this.http.get<Complexe>(`${this.ApiUri}/api/Complexe/${id}`);
  }
  create(data: AddComplexe):void
  {
    this.http.post<AddComplexe>(this.ApiUri+'/api/Complexe',data);
  }
  update(id:number,data: UpdateComplexe):void
  {
     this.http.put<UpdateComplexe>(`${this.ApiUri}/api/Complexe/${id}`,data);
  }
  delete(id:number):void
  {
    this.http.delete<Complexe>(this.ApiUri+'/api/Complexe/'+id);
  }

  addsalle(id:number,data: AddSalleDeTheatre):void
  {
    this.http.post<AddSalleDeTheatre>(`${this.ApiUri}/api/Complexe/add-salle/${id}`,data);
  }
}
