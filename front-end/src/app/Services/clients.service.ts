import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Client } from '../Models/Client';
import { Observable,Subject, tap } from 'rxjs';
import { Result as TResult } from "../Models/ResultT";
import { Result } from "../Models/Result";

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  serviceUrl = `${environment.ApiUrl}/Clients`;

  constructor(private httpClient:HttpClient) {
  }

  private _refreshNeeded=new Subject<void>();

  get refreshNeeded(){
    return this._refreshNeeded;
  }


  getClients():Observable<TResult<Client[]>> {
    return this.httpClient.get<TResult<Client[]>>(`${this.serviceUrl}/GetClients`);
  }

  getClientById(clientId:string):Observable<TResult<Client>> {
    return this.httpClient.get<TResult<Client>>(`${this.serviceUrl}/GetClientById/${clientId}`);
  }

  createClient(client: Client):Observable<Client>{
    return this.httpClient.post<Client>(`${this.serviceUrl}/CreateClient`,client).pipe(
      tap(()=> {
        this.refreshNeeded.next();
      })
    )
  }

  deleteClient(clientId:string):Observable<Result> {
   return this.httpClient.delete<Result>(`${this.serviceUrl}/DeleteClient/${clientId}`).pipe(
    tap(()=>{
      this.refreshNeeded.next();
    })
    )
  }

  updateClient(client:Client):Observable<TResult<Client>>{
    return  this.httpClient.put<TResult<Client>>(`${this.serviceUrl}/UpdateClient`, client).pipe(
      tap(()=>{
        this.refreshNeeded.next();
      })
    )
  }
}
