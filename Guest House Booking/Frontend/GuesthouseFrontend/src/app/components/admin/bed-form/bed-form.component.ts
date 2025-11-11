import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BedService } from 'src/app/services/bed.service';
import { RoomService, RoomDto } from 'src/app/services/room.service';

@Component({
  selector: 'app-bed-form',
  templateUrl: './bed-form.component.html'
})
export class BedFormComponent implements OnInit {
  form: FormGroup;
  isEditMode = false;
  currentId: number = 0;
  rooms: RoomDto[] = []; 

  constructor(
    private fb: FormBuilder,
    private bedService: BedService,
    private roomService: RoomService, 
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      roomId: [null, Validators.required],
      bedNumber: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.roomService.getAll().subscribe(data => {
      this.rooms = data;
    });

    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEditMode = true;
        this.currentId = +params['id'];
        this.bedService.getById(this.currentId).subscribe(data => {
          this.form.patchValue(data);
        });
      }
    });
  }

  // --- THIS IS THE FIX ---
  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    const navigateToList = () => {
      // This function navigates back to the list.
      this.router.navigate(['/admin/beds']); // <-- Change this route
    };

    if (this.isEditMode) {
      this.bedService.update(this.currentId, this.form.value)
        .subscribe({
          next: navigateToList, // Navigate on success
          error: (err) => console.error('Update failed', err)
        });
    } else {
      this.bedService.create(this.form.value)
        .subscribe({
          next: navigateToList, // Navigate on success
          error: (err) => console.error('Create failed', err)
        });
    }
  }

  // --- ADD THIS CANCEL BUTTON LOGIC ---
  onCancel() {
    this.router.navigate(['/admin/beds']); // <-- Change this route
  }
}