import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { HttpErrorResponse } from '@angular/common/http'; // <-- 1. IMPORT THIS

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html'
})
export class UserFormComponent {
  form: FormGroup;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {
    this.form = this.fb.group({
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      gender: ['Male', Validators.required],
      role: ['User', Validators.required] // Default to 'User'
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    this.successMessage = null;
    this.errorMessage = null;

    this.userService.createUser(this.form.value).subscribe({
      
      // --- 2. THIS IS THE SUCCESS FIX ---
      // We explicitly type 'response' and use the message from the API
      next: (response: { message: string }) => {
        this.successMessage = response.message; 
        this.form.reset({ gender: 'Male', role: 'User' }); // Reset the form
      },
      
      // --- 3. THIS IS THE ERROR FIX ---
      // We explicitly type 'err' and add robust logic
      error: (err: HttpErrorResponse) => {
        let message = 'An unknown error occurred.';
        
        if (typeof err.error === 'string') {
          // This handles your API's "Email address is already in use."
          message = err.error;
        } else if (err.error?.message) {
          // This handles if the API sends an object
          message = err.error.message;
        }
        
        this.errorMessage = message;
        console.error('Create user failed', err);
      }
    });
  }

  onCancel() {
    this.router.navigate(['/admin-dashboard']);
  }
}