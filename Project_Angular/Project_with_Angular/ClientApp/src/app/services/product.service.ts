import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from '../models/app-constant';
import { Product } from '../models/product';
import { Section } from '../models/section';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  getWithSection():Observable<Product[]>{
    return this.http.get<Product[]>(`${apiUrl}/api/Products`);
  }
  getById(id:number):Observable<Product>{
    return this.http.get<Product>(`${apiUrl}/api/Products/${id}`);
  }
  post(data:Section):Observable<Product>{
    return this.http.post<Product>(`${apiUrl}/api/Products`, data);
  }
  put(data:Product):Observable<any>{
    return this.http.put<any>(`${apiUrl}/api/Products/${data.productId}`, data);
  }
  delete(id:number):Observable<any>{
    return this.http.delete<Product>(`${apiUrl}/api/Products/${id}`);
  }
}