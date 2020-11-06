import { Injectable } from '@angular/core';
import {  HttpClient} from "@angular/common/http";
import { Observable } from 'rxjs';
import { filter, map, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  private readonly END_POINT :string ="http://52.15.217.2/api/";

  get<T>(url:string):Observable<T>{

    return this.httpClient.get<T>(this.END_POINT+url).pipe(
      tap((x:any)=>{ if(x.StatusCode!=200){ alert("Error occured") }}),
      filter((x:any)=>x.StatusCode == 200),
      map((x:any)=>x.Data)
    );

  }

  post<T>(url:string,data):Observable<T>{

    return this.httpClient.post<T>(this.END_POINT+url,data).pipe(
      map((x:any)=>x.Data)
    );

  }


}
