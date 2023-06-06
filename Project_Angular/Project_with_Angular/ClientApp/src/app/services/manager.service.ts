import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from '../models/app-constant';
import { ImagePath } from '../models/image-path';
import { Manager } from '../models/manager';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private http:HttpClient) { }
  get():Observable<Manager[]>{
    return this.http.get<Manager[]>(`${apiUrl}/api/managers`);
  }
  getById(id:number):Observable<Manager>{
    return this.http.get<Manager>(`${apiUrl}/api/managers/${id}`);
  }
  post(data:Manager):Observable<Manager>{
    return this.http.post<Manager>(`${apiUrl}/api/managers`, data);
  }
  put(data:Manager):Observable<any>{
    return this.http.put<any>(`${apiUrl}/api/managers/${data.managerId}`, data);
  }
  upload(id:number, f:File):Observable<ImagePath>{
    const formData = new FormData();

    formData.append('file', f);
    return  this.http.post<ImagePath>(`${apiUrl}/api/Managers/Picture/Upload/${id}`, formData)
  }

  delete(id:number):Observable<any>{
    return this.http.delete<Manager>(`${apiUrl}/api/managers/${id}`);
  }
}
