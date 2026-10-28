import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Listing, ListingRequest } from '../Models/models';

@Injectable({ providedIn: 'root' })
export class ListingService {
  private http = inject(HttpClient);
  private url = `${environment.apiUrl}/listing`;

  getAll() { return this.http.get<Listing[]>(this.url); }
  getById(id: number) { return this.http.get<Listing>(`${this.url}/${id}`); }
  create(l: ListingRequest) { return this.http.post<Listing>(this.url, l); }
  update(id: number, l: ListingRequest) { return this.http.put<Listing>(`${this.url}/${id}`, l); }
}