import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  form: FormGroup;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute // To read the email from the URL
  ) {
    this.form = this.fb.group({
      email: [{ value: '', disabled: true }, [Validators.required, Validators.email]],
      otp: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
    // Read the email from the URL (e.g., /reset-password?email=test@test.com)
    this.route.queryParams.subscribe(params => {
      if (params['email']) {
        this.form.get('email')?.setValue(params['email']);
      } else {
        // If no email, send them back
        this.router.navigate(['/forgot-password']);
      }
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    this.successMessage = null;
    this.errorMessage = null;
    
    // Get all values, including the disabled email
    const dto = this.form.getRawValue();

    this.authService.resetPassword(dto).subscribe({
      next: (response) => {
        this.successMessage = response.message;
        // On success, send them to login after 3 seconds
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 3000);
      },
      error: (err) => {
        this.errorMessage = err.error?.message || "An error occurred.";
      }
    });
  }
}
