import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(public http: HttpClient)
  {

  }

  get(): Observable<string> {
    return this.http.get<string>("https://localhost:44364/api/Values");
  }
}
