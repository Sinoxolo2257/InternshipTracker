import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CompanyDto } from '../DTOs/CompanyDto';
import { Company } from '../Models/Company';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {

  private apiUrl='https://localhost:7128/api/company';

  constructor(private http:HttpClient){}

  getAllCompanies(): Observable<Company[]>{
    return this.http.get<Company[]>(this.apiUrl);
  }

  getCompanyById(id:number): Observable<Company>{
    return this.http.get<Company>(`${this.apiUrl}/${id}`);
  }

  addCompany(company:CompanyDto):Observable<Company>{
    return this.http.post<Company>(this.apiUrl,company);
  }

  updateCompany(id:number, company:CompanyDto): Observable<Company>{
    return this.http.put<Company>(`${this.apiUrl}/${id}`,company);
  }

}
