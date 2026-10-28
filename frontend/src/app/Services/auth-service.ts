import { Injectable, computed, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs';
import { environment } from '../../environments/environment';

const apiUrl = environment.apiUrl;

const TOKEN_KEY = 'token';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);

  private _token = signal<string | null>(localStorage.getItem(TOKEN_KEY));
  readonly token = this._token.asReadonly();

  readonly isLoggedIn = computed(() => {
    const t = this._token();
    return !!t && !this.isExpired(t);
  });

  login(emailAddress: string, password: string) {
    return this.http.post<{ token: string }>(`${apiUrl}/auth/login`, { emailAddress, password })
      .pipe(
        tap(res => {
          localStorage.setItem(TOKEN_KEY, res.token);
          this._token.set(res.token);
        })
      );
  }

  register(data: { name: string; surname: string; emailAddress: string; password: string }) {
    return this.http.post(`${apiUrl}/user/register`, data);
  }

  logout() {
    localStorage.removeItem(TOKEN_KEY);
    this._token.set(null);
    this.router.navigate(['/login']);
  }

  private isExpired(token: string): boolean {
    try {
      const payload = token.split('.')[1].replace(/-/g, '+').replace(/_/g, '/');
      const { exp } = JSON.parse(atob(payload));
      return exp * 1000 < Date.now();
    } catch {
      return true;
    }
  }
}