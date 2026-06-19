import { HttpClient } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';
import { Router } from '@angular/router';

import { environment } from '../../../environments/environment';
import { LoginRequest } from '../../models/login-request.model';
import { RegisterRequest } from '../../models/register-request.model';
import { AuthResponse } from '../../models/auth-response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);

  private apiUrl = `${environment.apiUrl}/auth`;

  token = signal<string | null>(localStorage.getItem('token'));
  username = signal<string | null>(localStorage.getItem('username'));
  role = signal<string | null>(localStorage.getItem('role'));

  isLoggedIn = computed(() => this.token() !== null);

  login(request: LoginRequest) {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, request);
  }

  register(request: RegisterRequest) {
    return this.http.post(`${this.apiUrl}/register`, request);
  }

  saveSession(response: AuthResponse) {
    localStorage.setItem('token', response.token);
    localStorage.setItem('username', response.username);
    localStorage.setItem('role', response.role);

    this.token.set(response.token);
    this.username.set(response.username);
    this.role.set(response.role);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('role');

    this.token.set(null);
    this.username.set(null);
    this.role.set(null);

    this.router.navigate(['/login']);
  }
}