import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { apiUrl } from '../models/app-const';
import { Section } from '../models/section';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  constructor( private http:HttpClient) { }
  get():Observable<Section[]>{
    return this.http.get<Section[]>(`${apiUrl}/api/Sections`);
  }
  post(data:Section):Observable<Section>{
    return this.http.post<Section>(`${apiUrl}/api/Sections`, data);
  }
  put(data:Section):Observable<any>{
    return this.http.put<any>(`${apiUrl}/api/Sections/${data.sectionId}`, data);
  }
  delete(id:number):Observable<any>{
    return this.http.delete<any>(`${apiUrl}/api/Sections/${id}`);
  }
  getById(id:number):Observable<Section>{
    return this.http.get<Section>(`${apiUrl}/api/Sections/${id}`);
  }
}
