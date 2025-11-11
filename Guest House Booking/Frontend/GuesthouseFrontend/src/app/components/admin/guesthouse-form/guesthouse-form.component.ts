import { Component, OnInit, NgZone } from '@angular/core'; // 1. Import NgZone
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GuesthouseService } from 'src/app/services/guesthouse.service';

@Component({
  selector: 'app-guesthouse-form',
  templateUrl: './guesthouse-form.component.html'
})
export class GuesthouseFormComponent implements OnInit {
  form: FormGroup;
  isEditMode = false;
  currentId: number = 0;
  isLoading = false; 

  constructor(
    private fb: FormBuilder,
    private guesthouseService: GuesthouseService,
    private router: Router,
    private route: ActivatedRoute,
    private zone: NgZone // 2. Inject NgZone
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      location: ['', Validators.required],
      description: [''],
      imageUrl: ['']
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEditMode = true;
        this.currentId = +params['id'];
        this.guesthouseService.getById(this.currentId).subscribe(data => {
          this.form.patchValue(data);
        });
      }
    });
  }

 onSubmit() {
  if (this.form.invalid || this.isLoading) {
    return;
  }
  this.isLoading = true;

  const handleSuccess = () => {
    this.isLoading = false;
    // ✅ Use NgZone.run to ensure navigation triggers Angular change detection
    this.zone.run(() => {
      this.router.navigateByUrl('/admin/guesthouses').then(() => {
        // Optional: reload the route to ensure updated data is shown
        window.location.reload();
      });
    });
  };

  const handleError = (err: any) => {
    this.isLoading = false;
    console.error('API call failed', err);
  };

  if (this.isEditMode) {
    this.guesthouseService.update(this.currentId, this.form.value)
      .subscribe({
        next: handleSuccess,
        error: handleError
      });
  } else {
    this.guesthouseService.create(this.form.value)
      .subscribe({
        next: handleSuccess,
        error: handleError
      });
  }
}


  onCancel() {
    if (this.isLoading) {
      return;
    }
    this.router.navigate(['/admin/guesthouses']);
  }
}