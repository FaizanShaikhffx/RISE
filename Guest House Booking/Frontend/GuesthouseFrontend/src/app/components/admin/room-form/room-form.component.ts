import { Component, OnInit, NgZone } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomService, RoomDto, RoomCreateDto } from 'src/app/services/room.service';
import { GuesthouseService, GuestHouseDto } from 'src/app/services/guesthouse.service';
import { BedService, BedDto, BedCreateDto } from 'src/app/services/bed.service'; // <-- Import Bed services
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html'
})
export class RoomFormComponent implements OnInit {
  // Room Form
  roomForm: FormGroup;
  isEditMode = false; // This is now ALWAYS "edit mode" for the room
  currentRoomId: number = 0;
  isLoading = false;
  
  // Guesthouse (for context)
  guestHouses: GuestHouseDto[] = []; 
  guesthouseId: number | null = null; // Guesthouse this room belongs to
  guesthouseName: string = '';

  // --- NEW BED MANAGEMENT STATE ---
  beds: BedDto[] = [];
  bedForm: FormGroup;
  isBedEditMode = false;
  currentBedId: number | null = null;
  
  // --- WIZARD STATE ---
  isWizardFlow = false;

  constructor(
    private fb: FormBuilder,
    private roomService: RoomService,
    private guesthouseService: GuesthouseService, 
    private bedService: BedService, // <-- Inject BedService
    private router: Router,
    private route: ActivatedRoute,
    private zone: NgZone,
    private toastr: ToastrService, // <-- Inject
  ) {
    // Form for Room
    this.roomForm = this.fb.group({
      guestHouseId: [null, Validators.required],
      roomName: ['', Validators.required],
      genderAllowed: ['Any', Validators.required]
    });

    // Form for Beds
    this.bedForm = this.fb.group({
      bedNumber: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Check for wizard flow first (from Step 1)
    this.route.queryParams.subscribe(params => {
      if (params['guesthouseId']) {
        this.isWizardFlow = true;
        this.guesthouseId = +params['guesthouseId'];
        
        this.roomForm.get('guestHouseId')?.setValue(this.guesthouseId);
        this.roomForm.get('guestHouseId')?.disable();

        this.guesthouseService.getById(this.guesthouseId).subscribe(gh => {
          this.guesthouseName = gh.name;
        });
      } else {
        // Not a wizard, load all guesthouses for the normal dropdown (legacy)
        this.guesthouseService.getAll().subscribe(data => {
          this.guestHouses = data;
        });
      }
    });

    // Check for edit mode (from Guesthouse "Manage Beds" link)
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEditMode = true;
        this.currentRoomId = +params['id'];
        this.roomForm.get('guestHouseId')?.disable(); 
        
        this.roomService.getById(this.currentRoomId).subscribe(data => {
          this.roomForm.patchValue(data);
          this.guesthouseId = data.guestHouseId; // Set guesthouseId for "Cancel"
          this.loadBeds(); // Load beds for this room
        });
      }
    });
  }

  // --- Room Form Logic ---
  onRoomSubmit() {
    if (this.roomForm.invalid) return;
    this.isLoading = true;

    const formValue = this.roomForm.getRawValue(); 
    const roomData: RoomCreateDto = {
      guestHouseId: formValue.guestHouseId,
      roomName: formValue.roomName,
      genderAllowed: formValue.genderAllowed
    };

    if (this.isEditMode) {
      // --- UPDATE LOGIC ---
      this.roomService.update(this.currentRoomId, roomData).subscribe({
        next: () => {
          this.isLoading = false;
          this.toastr.success('Room updated successfully!'); // <-- Success Toast
          this.router.navigate(['/admin/guesthouse/edit', roomData.guestHouseId]);
          // You can show a success message here
        },
        error: (err) => {
          this.isLoading = false;
          this.toastr.error('Failed to update room.', 'Error'); // <-- Error Toast
        }
      });
    } else {
      // --- CREATE LOGIC (Wizard) ---
      this.roomService.create(roomData).subscribe({
        next: (newRoom) => {
          this.isLoading = false;
          this.toastr.success('Room created successfully!'); // <-- Success Toast
          if (this.isWizardFlow) {
            // --- Step 2 -> Step 3: Go to Add Beds ---
            this.zone.run(() => {
              this.router.navigate(['/admin/bed/new'], { 
                queryParams: { 
                  roomId: newRoom.roomId,
                  guesthouseId: this.guesthouseId
                } 
              });
            });
          } else {
            // This case shouldn't happen in the new flow, but as a fallback:
            this.router.navigate(['/admin/guesthouse/edit', roomData.guestHouseId]);
          }
        },
        error: (err: HttpErrorResponse) => {
          this.isLoading = false;
          this.toastr.error(err.error?.innerException || 'Failed to create room.', 'Error');
        }
      });
    }
  }

  // --- NEW BED LOGIC ---
  loadBeds() {
    this.bedService.getAllByRoom(this.currentRoomId).subscribe(data => {
      this.beds = data;
    });
  }

  onBedSubmit() {
    if (this.bedForm.invalid) return;

    const bedData: BedCreateDto = {
      ...this.bedForm.value,
      roomId: this.currentRoomId // Automatically assign this room's ID
    };

    if (this.isBedEditMode && this.currentBedId) {
      // Update Bed
      this.bedService.update(this.currentBedId, bedData).subscribe(() => {
        this.resetBedForm();
        this.loadBeds();
      });
    } else {
      // Create Bed
      this.bedService.create(bedData).subscribe(() => {
        this.resetBedForm();
        this.loadBeds();
      });
    }
  }

  onEditBed(bed: BedDto) {
    this.isBedEditMode = true;
    this.currentBedId = bed.bedId;
    this.bedForm.patchValue(bed);
  }

  onDeleteBed(bedId: number) {
    if (confirm('Are you sure you want to delete this bed?')) {
      this.bedService.delete(bedId).subscribe(() => {
        this.loadBeds();
        this.resetBedForm();
      });
    }
  }

  resetBedForm() {
    this.isBedEditMode = false;
    this.currentBedId = null;
    this.bedForm.reset();
  }
  
  onCancel() {
    // Go back to the Guesthouse edit page
    if (this.guesthouseId) {
      this.router.navigate(['/admin/guesthouse/edit', this.guesthouseId]);
    } else {
      this.router.navigate(['/admin/guesthouses']);
    }
  }
}