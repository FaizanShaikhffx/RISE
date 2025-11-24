import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html'
})
export class UserProfileComponent implements OnInit {
  form: FormGroup;
  isEditing = false; // Toggle between View Mode and Edit Mode
  isLoading = false;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  // Static Profile Image (as requested)
  profileImage = 'https://cdn-icons-png.flaticon.com/512/3135/3135715.png';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ) {
    this.form = this.fb.group({
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      gender: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile() {
    this.authService.getProfile().subscribe(data => {
      this.form.patchValue(data);
    });
  }

  toggleEdit() {
    this.isEditing = !this.isEditing;
    this.successMessage = null;
    this.errorMessage = null;
    if (!this.isEditing) {
      // If cancelling, reload original data
      this.loadProfile();
    }
  }

  onSubmit() {
    if (this.form.invalid) return;
    this.isLoading = true;
    this.successMessage = null;
    this.errorMessage = null;

    this.authService.updateProfile(this.form.value).subscribe({
      next: (res) => {
        this.isLoading = false;
        this.successMessage = res.message;
        this.isEditing = false; // Go back to view mode
      },
      error: (err: HttpErrorResponse) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || 'Update failed.';
      }
    });
  }
}