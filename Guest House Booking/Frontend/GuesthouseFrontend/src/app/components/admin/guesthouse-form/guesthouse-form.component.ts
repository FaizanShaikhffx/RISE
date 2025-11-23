import { Component, OnInit, NgZone } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GuesthouseService } from 'src/app/services/guesthouse.service';
import { RoomService, RoomDto, RoomCreateDto } from 'src/app/services/room.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-guesthouse-form',
  templateUrl: './guesthouse-form.component.html'
})
export class GuesthouseFormComponent implements OnInit {
  // Guesthouse Form
  guesthouseForm: FormGroup;
  isEditMode = false;
  currentId: number = 0;
  isLoading = false; 

  // --- NEW ROOM MANAGEMENT STATE ---
  rooms: RoomDto[] = [];
  roomForm: FormGroup;
  isRoomEditMode = false;
  currentRoomId: number | null = null;
  // --- END NEW STATE ---

  constructor(
    private fb: FormBuilder,
    private guesthouseService: GuesthouseService,
    private roomService: RoomService, // <-- Inject RoomService
    private router: Router,
    private route: ActivatedRoute,
    private zone: NgZone 
  ) {
    // Form for Guesthouse
    this.guesthouseForm = this.fb.group({
      name: ['', Validators.required],
      location: ['', Validators.required],
      description: [''],
      imageUrl: ['']
    });

    // Form for Rooms
    this.roomForm = this.fb.group({
      roomName: ['', Validators.required],
      genderAllowed: ['Any', Validators.required]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params['id']) {
        // --- EDIT MODE ---
        this.isEditMode = true;
        this.currentId = +params['id'];
        
        // Load Guesthouse data
        this.guesthouseService.getById(this.currentId).subscribe(data => {
          this.guesthouseForm.patchValue(data);
        });

        // Load Rooms for this Guesthouse
        this.loadRooms();
      }
      // --- CREATE MODE ---
      // (Handled by the wizard flow)
    });
  }

  // --- Guesthouse Form Logic ---
  onGuesthouseSubmit() {
    if (this.guesthouseForm.invalid || this.isLoading) {
      return;
    }
    this.isLoading = true;

    if (this.isEditMode) {
      // --- UPDATE LOGIC ---
      this.guesthouseService.update(this.currentId, this.guesthouseForm.value)
        .subscribe({
          next: () => {
            this.isLoading = false;
            // You can add a success toast here
          },
          error: (err: HttpErrorResponse) => {
            this.isLoading = false; 
            console.error('Guesthouse update failed', err.error);
            alert(err.error?.innerException || err.error?.details || 'Update failed.');
          }
        });
    } else {
      // --- CREATE WIZARD LOGIC ---
      this.guesthouseService.create(this.guesthouseForm.value)
        .subscribe({
          next: (newGuesthouse) => {
            this.isLoading = false;
            // Step 1 -> Step 2: Go to Add Room page
            this.zone.run(() => {
              this.router.navigate(['/admin/room/new'], { 
                queryParams: { guesthouseId: newGuesthouse.guestHouseId } 
              });
            });
          },
          error: (err: HttpErrorResponse) => {
            this.isLoading = false;
            console.error('Guesthouse create failed:', err.error); 
            let errorMsg = err.error?.innerException || err.error?.details || 'Failed to create guesthouse.';
            alert(errorMsg);
          }
        });
    }
  }

  // --- NEW ROOM LOGIC (for the "Edit Guesthouse" page) ---
  loadRooms() {
    this.roomService.getAllByGuesthouse(this.currentId).subscribe(data => {
      this.rooms = data;
    });
  }

  onRoomSubmit() {
    if (this.roomForm.invalid) return;

    const roomData: RoomCreateDto = {
      ...this.roomForm.value,
      guestHouseId: this.currentId // Automatically assign this guesthouse's ID
    };

    if (this.isRoomEditMode && this.currentRoomId) {
      // --- Update Room ---
      this.roomService.update(this.currentRoomId, roomData).subscribe(() => {
        this.resetRoomForm();
        this.loadRooms();
      });
    } else {
      // --- Create Room ---
      this.roomService.create(roomData).subscribe(() => {
        this.resetRoomForm();
        this.loadRooms();
      });
    }
  }

  onEditRoom(room: RoomDto) {
    this.isRoomEditMode = true;
    this.currentRoomId = room.roomId;
    this.roomForm.patchValue(room);
  }

  onDeleteRoom(roomId: number) {
    if (confirm('Are you sure you want to delete this room? This will also delete all beds and associated bookings.')) {
      this.roomService.delete(roomId).subscribe(() => {
        this.loadRooms();
        this.resetRoomForm();
      });
    }
  }

  resetRoomForm() {
    this.isRoomEditMode = false;
    this.currentRoomId = null;
    this.roomForm.reset({ genderAllowed: 'Any' });
  }
  
  onCancel() {
    this.router.navigate(['/admin/guesthouses']);
  }
}