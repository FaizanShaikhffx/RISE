import { Component, NgZone } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr'; // 1. Import Toastr

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html'
})
export class UserFormComponent {
  form: FormGroup;
  isLoading = false; // 2. Add loading state

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router,
    private toastr: ToastrService, // 3. Inject Toastr
    private zone: NgZone // 4. Inject NgZone for navigation
  ) {
    this.form = this.fb.group({
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      gender: ['Male', Validators.required],
      role: ['User', Validators.required]
    });
  }

  onSubmit() {
    if (this.form.invalid || this.isLoading) {
      return;
    }

    this.isLoading = true; // Start loading

    this.userService.createUser(this.form.value).subscribe({
      next: (response: { message: string }) => {
        this.isLoading = false;
        
        // 5. Show success toast
        this.toastr.success(response.message || 'User created successfully!', 'Success');
        
        // 6. Redirect to Dashboard
        this.zone.run(() => {
          this.router.navigate(['/admin/dashboard']);
        });
      },
      error: (err: HttpErrorResponse) => {
        this.isLoading = false;
        
        // 7. Handle Error
        let message = 'An unknown error occurred.';
        if (typeof err.error === 'string') {
          message = err.error;
        } else if (err.error?.message) {
          message = err.error.message;
        }
        
        this.toastr.error(message, 'Creation Failed');
        console.error('Create user failed', err);
      }
    });
  }

  onCancel() {
    this.router.navigate(['/admin/dashboard']);
  }
}