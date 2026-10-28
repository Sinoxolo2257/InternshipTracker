import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Company, CompanyRequest } from '../Models/models';

@Injectable({ providedIn: 'root' })
export class CompanyService {
  private http = inject(HttpClient);
  private url = `${environment.apiUrl}/company`;

  getAll() { return this.http.get<Company[]>(this.url); }
  getById(id: number) { return this.http.get<Company>(`${this.url}/${id}`); }
  create(c: CompanyRequest) { return this.http.post<Company>(this.url, c); }
  update(id: number, c: CompanyRequest) { return this.http.put<Company>(`${this.url}/${id}`, c); }
}