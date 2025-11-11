import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomService } from 'src/app/services/room.service';
import { GuesthouseService, GuestHouseDto } from 'src/app/services/guesthouse.service';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html'
})
export class RoomFormComponent implements OnInit {
  form: FormGroup;
  isEditMode = false;
  currentId: number = 0;
  guestHouses: GuestHouseDto[] = []; 

  constructor(
    private fb: FormBuilder,
    private roomService: RoomService,
    private guesthouseService: GuesthouseService, 
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      guestHouseId: [null, Validators.required],
      roomName: ['', Validators.required],
      genderAllowed: ['Any', Validators.required]
    });
  }

  ngOnInit(): void {
    this.guesthouseService.getAll().subscribe(data => {
      this.guestHouses = data;
    });

    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEditMode = true;
        this.currentId = +params['id'];
        this.roomService.getById(this.currentId).subscribe(data => {
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
      this.router.navigate(['/admin/rooms']); // <-- Change this route
    };

    if (this.isEditMode) {
      this.roomService.update(this.currentId, this.form.value)
        .subscribe({
          next: navigateToList, // Navigate on success
          error: (err) => console.error('Update failed', err)
        });
    } else {
      this.roomService.create(this.form.value)
        .subscribe({
          next: navigateToList, // Navigate on success
          error: (err) => console.error('Create failed', err)
        });
    }
  }

  // --- ADD THIS CANCEL BUTTON LOGIC ---
  onCancel() {
    this.router.navigate(['/admin/rooms']); // <-- Change this route
  }
}