import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Application, ApplicationRequest } from '../Models/models';

@Injectable({ providedIn: 'root' })
export class ApplicationService {
  private http = inject(HttpClient);
  private url = `${environment.apiUrl}/application`;

  getAll() { return this.http.get<Application[]>(this.url); }
  getById(id: number) { return this.http.get<Application>(`${this.url}/${id}`); }
  getByStatus(statusID: number) { return this.http.get<Application[]>(`${this.url}/status/${statusID}`); }
  getByCompany(companyID: number) { return this.http.get<Application[]>(`${this.url}/company/${companyID}`); }
  create(a: ApplicationRequest) { return this.http.post<Application>(this.url, a); }
  update(id: number, a: ApplicationRequest) { return this.http.put<Application>(`${this.url}/${id}`, a); }

  // dashboard panels
  getClosingSoon(days = 7) { return this.http.get<Application[]>(`${environment.apiUrl}/deadline/closing-soon`, { params: { days } }); }
  getOverdue() { return this.http.get<Application[]>(`${environment.apiUrl}/deadline/overdue`); }
}