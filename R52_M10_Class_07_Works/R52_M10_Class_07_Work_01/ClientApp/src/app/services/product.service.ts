import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from '../models/app-const';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  get():Observable<Product[]>{
    return this.http.get<Product[]>(`${apiUrl}/api/Products`);
  }
  getById(id:number):Observable<Product>{
    return this.http.get<Product>(`${apiUrl}/api/Products/${id}`);
  }
  post(data:Product):Observable<Product>{
    return this.http.post<Product>(`${apiUrl}/api/Products`, data);
  }
  put(data:Product):Observable<any>{
    return this.http.put<any>(`${apiUrl}/api/Departments/${data.productId}`, data);
  }
  delete(id:number):Observable<any>{
    return this.http.delete<any>(`${apiUrl}/api/Products/${id}`);
  }

}
