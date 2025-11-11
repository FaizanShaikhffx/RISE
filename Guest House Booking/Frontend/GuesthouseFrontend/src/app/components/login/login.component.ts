import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      // Create form controls with validation
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

 onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    this.errorMessage = null;
    const { email, password } = this.loginForm.value;

    this.authService.login(email, password).subscribe({
      next: (response) => {
        
        // --- THIS IS THE REDIRECTION LOGIC ---
        if (response.role === 'Admin') {
          // 1. If user is Admin, go to the Admin Dashboard
          this.router.navigate(['/admin-dashboard']);
        } else {
          // 2. If user is a regular User, go to their "My Bookings" page
          this.router.navigate(['/my-bookings']); 
        }
      },
      error: (err) => {
        // Show an error message if login fails
        this.errorMessage = 'Invalid email or password. Please try again.';
        console.error(err);
      },
    });
  }}
