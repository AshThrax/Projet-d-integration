import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class GenericHttpService<T> {

  constructor(private http: HttpClient) { }

  get(uri: string): Observable<T[]>
  {
    return this.http.get<T[]>(uri);
  }

  getbyId(uri: string, id:number): Observable<T>
  {
     return this.http.get<T>(uri+'/'+id);
  }

  post(uri: string, data: T): void
  {
  
    this.http.post<T>(uri, data);
  }
  update(uri: string, data: T): void
  {
     this.http.put<T>(uri, data);
  }
  Delete(uri: string, data: T): void
  {
     this.http.delete<T>(uri);
  }
}
