import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent {

  form: FormGroup;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    this.successMessage = null;
    this.errorMessage = null;
    const email = this.form.value.email;

    this.authService.forgotPassword(email).subscribe({
      next: (response) => {
        // We navigate to the reset page and pass the email
        // in the URL so the next form can use it.
        this.router.navigate(['/reset-password'], { queryParams: { email: email } });
      },
      error: (err) => {
        this.errorMessage = "An error occurred. Please try again.";
      }
    });
  }
}