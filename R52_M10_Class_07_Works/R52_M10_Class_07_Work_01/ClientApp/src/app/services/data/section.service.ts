import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { apiUrl } from 'src/app/models/data/app-constant';
import { SectionModel } from 'src/app/models/data/section-model';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  constructor(
    private http:HttpClient


  ) { }
  getWithDepartment():Observable<SectionModel[]>{
    return this.http.get<SectionModel[]>(`${apiUrl}/api/Sections`);
  }
  post(data:SectionModel):Observable<SectionModel>{
    return this.http.post<SectionModel>(`${apiUrl}/api/Sections`, data);
  }
}
