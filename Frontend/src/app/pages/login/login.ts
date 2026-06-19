import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

import { AuthService } from '../../core/services/auth.service';
import { LoginRequest } from '../../models/login-request.model';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  private authService = inject(AuthService);
  private router = inject(Router);

  errorMessage = '';

  form: LoginRequest = {
    email: '',
    password: ''
  };

  login() {
    this.errorMessage = '';

    this.authService.login(this.form).subscribe({
      next: response => {
        this.authService.saveSession(response);
        this.router.navigate(['/dashboard']);
      },
      error: () => {
        this.errorMessage = 'Email ou mot de passe incorrect.';
      }
    });
  }
}