import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Publisher } from '../models/data/publisher';
import { Observable } from 'rxjs';
import {apiUrl  } from '../models/constants/app-constant';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  constructor(private http:HttpClient) { }
  get():Observable<Publisher[]>{
    return this.http.get<Publisher[]>(`${apiUrl}/api/Publishers`);
  }
  getById(id:number):Observable<Publisher>{
    return this.http.get<Publisher>(`${apiUrl}/api/Publishers${id}`);
  }
  post(data:Publisher):Observable<Publisher>{
    return this.http.post<Publisher>(`${apiUrl}/api/Publishers`, data);
  }
  put(data:Publisher):Observable<any>{
    return this.http.put<any>(`${apiUrl}/api/Publishers${data.publisherId}`, data);
  }
  delete(id:number):Observable<any>{
    return this.http.delete<any>(`${apiUrl}/api/Publishers${id}`);
  }
}
