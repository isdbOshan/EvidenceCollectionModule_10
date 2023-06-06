import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { apiUrl } from '../models/app-const';
import { Manager } from '../models/manager';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private http:HttpClient) { }

  // get():Observable<Manager[]>{
  //   return this.http.get<Manager[]>(`${apiUrl}/api/Managers`);
  // }
  // post(data:Manager):Observable<Manager>{
  //   return this.http.post<Manager>(`${apiUrl}/api/Managers`, data);
  // }
  // put(data:Manager):Observable<any>{
  //   return this.http.put<any>(`${apiUrl}/api/Managers/${data.managerId}`, data);
  // }

  // delete(id:number):Observable<any>{
  //   return this.http.delete<any>(`${apiUrl}/api/Managers/${id}`);
  // }
  getById(id:number):Observable<Manager>{
    return this.http.get<Manager>(`${apiUrl}/api/Managers/${id}`);
  }
}
