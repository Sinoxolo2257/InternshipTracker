import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Cv } from '../Models/models';

@Injectable({ providedIn: 'root' })
export class DocumentService {
  private http = inject(HttpClient);
  private url = `${environment.apiUrl}/docs`;

  getAll() { return this.http.get<Document[]>(this.url); }

  upload(versionName: string, file: File) {
    const form = new FormData();
    form.append('versionName', versionName);
    form.append('file', file);
    return this.http.post<Document>(this.url, form);
  }

  archive(id: number) { return this.http.patch<Document>(`${this.url}/${id}/archive`, {}); }

  download(cv: Cv) {
    this.http.get(`${this.url}/${cv.versionID}/download`, { responseType: 'blob' })
      .subscribe(blob => {
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = cv.originalFileName;
        link.click();
        URL.revokeObjectURL(link.href);
      });
  }
}