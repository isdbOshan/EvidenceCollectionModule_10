import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductModel } from 'src/app/models/data/product-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  get():Observable<ProductModel[]>{
    return this.http.get<ProductModel[]>('')
  }
}
