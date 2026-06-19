import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

import { AuthService } from '../../core/services/auth.service';
import { RegisterRequest } from '../../models/register-request.model';

@Component({
  selector: 'app-register',
  imports: [FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  private authService = inject(AuthService);
  private router = inject(Router);

  errorMessage = '';

  form: RegisterRequest = {
    username: '',
    email: '',
    password: ''
  };

  register() {
    this.errorMessage = '';

    this.authService.register(this.form).subscribe({
      next: () => {
        this.router.navigate(['/login']);
      },
      error: () => {
        this.errorMessage = 'Impossible de créer le compte.';
      }
    });
  }
}