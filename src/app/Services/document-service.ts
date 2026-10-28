import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Document } from '../Models/Document';

@Injectable({
  providedIn: 'root',
})
export class DocumentService {
  private apiUrl='https://localhost:7128/api/Docs';

  constructor(private http: HttpClient){}

  getDocuments(): Observable<Document[]>{
    return this.http.get<Document[]>(this.apiUrl);
  }

  getDocumentById(id:number): Observable<Document>{
    return this.http.get<Document>(`${this.apiUrl}/${id}`);
  }

  addDocument(document:Document): Observable<Document>{
    return this.http.post<Document>(this.apiUrl,document);
  }

  archiveDocument(id:number, ): Observable<Document>{
    return this.http.patch<Document>(`${this.apiUrl}/${id}`, null);
  }
}
