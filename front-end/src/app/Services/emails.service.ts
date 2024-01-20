import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Client, Email } from '../Models/Client';
import { Observable,Subject, tap } from 'rxjs';
import { Result as TResult } from "../Models/ResultT";
import { Result } from "../Models/Result";

@Injectable({
  providedIn: 'root'
})
export class EmailsService {

  serviceUrl = `${environment.ApiUrl}/Emails`;
  constructor(private httpClient:HttpClient) {
  }

  private _refreshNeeded= new Subject<void>();

  get refreshNeeded(){
    return this._refreshNeeded;
  }


  sendEmail(email: Email): Observable<Result>{
    return this.httpClient.post<Result>(`${this.serviceUrl}/SendEmail`, email).pipe(
      tap(()=> {
        this.refreshNeeded.next();
      })
    )
  }
}
