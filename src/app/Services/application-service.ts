import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Application } from '../Models/Application';
import { ApplicationDto } from '../DTOs/ApplicationDto';

@Injectable({
  providedIn: 'root',
})
export class ApplicationService {

  private apiUrl='https://localhost:7128/api/application';

  constructor(private http:HttpClient){}

  getAllApplication(): Observable<Application[]>{
    return this.http.get<Application[]>(this.apiUrl);
  }

  getApplicationById(id:number):Observable<Application>{
    return this.http.get<Application>(`${this.apiUrl}/${id}`);
  }

  getApplicationByCompanyId(companyId:number):Observable<Application[]>{
    return this.http.get<Application[]>(`${this.apiUrl}/company/${companyId}`);
  }

  addApplication(application:ApplicationDto): Observable<Application>{
    return this.http.post<Application>(this.apiUrl,application);
  }

  updateApplication(id:number,application:ApplicationDto): Observable<Application>{
    return this.http.put<Application>(`${this.apiUrl}/${id}`,application);
  }
}
