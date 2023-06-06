import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from '../models/app-constant';
import { Product } from '../models/product';
import { Section } from '../models/section';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  constructor(private http:HttpClient) { }
  get():Observable<Section[]>{
    return this.http.get<Section[]>(`${apiUrl}/api/sections`);
  }
  getById(id:number):Observable<Section>{
    return this.http.get<Section>(`${apiUrl}/api/sections/${id}`);
  }
  getSectionProduct(id:Number):Observable<Product[]>{
    return this.http.get<Product[]>(`${apiUrl}/api/sections/Products/${id}`);
  }
  post(data:Section):Observable<Section>{
    return this.http.post<Section>(`${apiUrl}/api/sections`, data);
  }
  put(data:Section):Observable<any>{
    return this.http.put<any>(`${apiUrl}/api/sections/${data.sectionId}`, data);
  }
  delete(id:number):Observable<any>{
    return this.http.delete<Section>(`${apiUrl}/api/sections/${id}`);
  }
}
