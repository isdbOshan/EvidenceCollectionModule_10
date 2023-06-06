import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/data/book';
import { apiUrl } from '../models/constants/app-constant';


@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(
    private http:HttpClient
  ) { }

  get():Observable<Book[]>{
    return this.http.get<Book[]>(`${apiUrl}/api/Book`);
  }
  getById(id:number):Observable<Book>{
    return this.http.get<Book>(`${apiUrl}/api/Books${id}`);
  }
  post(data:Book):Observable<Book>{
    return this.http.post<Book>(`${apiUrl}/api/Books`, data);
  }
  put(data:Book):Observable<any>{
    return this.http.put<any>(`${apiUrl}/api/Books${data.bookId}`, data);
  }
  delete(id:number):Observable<any>{
    return this.http.delete<any>(`${apiUrl}/api/Books${id}`);
  }


}
