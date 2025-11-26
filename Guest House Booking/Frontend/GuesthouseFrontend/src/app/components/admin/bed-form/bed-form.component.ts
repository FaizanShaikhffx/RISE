import { Component, OnInit, NgZone } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BedService, BedCreateDto, BedDto } from 'src/app/services/bed.service';
import { RoomService, RoomDto } from 'src/app/services/room.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-bed-form',
  templateUrl: './bed-form.component.html'
})
export class BedFormComponent implements OnInit {
  form: FormGroup;
  isEditMode = false;
  currentId: number = 0;
  rooms: RoomDto[] = []; 
  isLoading = false;
  
  // --- WIZARD STATE ---
  isWizardFlow = false;
  wizardRoomId: number | null = null;
  wizardGuesthouseId: number | null = null; // To go "Finish"
  roomName: string = '';
  successMessage: string | null = null;
  bedsInThisRoom: BedDto[] = []; // Show beds as they are added

  constructor(
    private fb: FormBuilder,
    private bedService: BedService,
    private roomService: RoomService, 
    private router: Router,
    private route: ActivatedRoute,
    private zone: NgZone,
    private toastr: ToastrService,
  ) {
    this.form = this.fb.group({
      roomId: [null, Validators.required],
      bedNumber: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Check for wizard flow first
    this.route.queryParams.subscribe(params => {
      if (params['roomId']) {
        this.isWizardFlow = true;
        this.wizardRoomId = +params['roomId'];
        this.wizardGuesthouseId = +params['guesthouseId']; // Get this for the "Finish" button

        this.form.get('roomId')?.setValue(this.wizardRoomId);
        this.form.get('roomId')?.disable();
        
        // Get room name for the title
        this.roomService.getById(this.wizardRoomId).subscribe(room => {
          this.roomName = room.roomName;
        });
        
        // Load beds already in this room
        this.loadBeds();
      } else {
        // Load all rooms for the normal dropdown
        this.roomService.getAll().subscribe(data => {
          this.rooms = data;
        });
      }
    });

    // Check for edit mode
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEditMode = true;
        this.currentId = +params['id'];
        this.form.get('roomId')?.disable(); // Also disable on edit
        this.bedService.getById(this.currentId).subscribe(data => {
          this.form.patchValue(data);
        });
      }
    });
  }
  
  loadBeds() {
    if (this.wizardRoomId) {
      this.bedService.getAll().subscribe(allBeds => {
        this.bedsInThisRoom = allBeds.filter(b => b.roomId === this.wizardRoomId);
      });
    }
  }

  onSubmit() {
    if (this.form.invalid) return;
    this.isLoading = true;
    this.successMessage = null;

    const formValue = this.form.getRawValue();
    const bedData: BedCreateDto = {
      roomId: formValue.roomId,
      bedNumber: formValue.bedNumber
    };

    if (this.isEditMode) {
      // --- UPDATE LOGIC ---
      this.bedService.update(this.currentId, bedData).subscribe({
        next: () => {
          // Go back to the guesthouse edit page
          this.router.navigate(['/admin/guesthouse/edit', this.wizardGuesthouseId]);
        },
        error: (err) => {
          this.isLoading = false;
          this.toastr.error('Failed to update bed.', 'Error');
        }
      });
    } else {
      // --- CREATE LOGIC (Wizard or Normal) ---
      this.bedService.create(bedData).subscribe({
        next: (newBed) => {
          this.isLoading = false;
          if (this.isWizardFlow) {
            // --- Wizard: Reset form to add another ---
            this.toastr.success(`Bed "${newBed.bedNumber}" added! Add another.`, 'Success');
            this.form.get('bedNumber')?.reset(); // Reset form
            this.loadBeds(); // Refresh the list
            setTimeout(() => this.successMessage = null, 3000); // Hide message
          } else {
            // Normal create, go back to guesthouse list
            this.toastr.success('Bed created successfully!');
            this.router.navigate(['/admin/guesthouses']);
          }
        },
        error: (err: HttpErrorResponse) => {
          this.isLoading = false;
          this.toastr.error('Failed to create bed.', 'Error');
        }
      });
    }
  }

  onCancel() {
    // "Finish" button for wizard
    if (this.wizardGuesthouseId) {
      this.router.navigate(['/admin/guesthouse/edit', this.wizardGuesthouseId]);
    } else {
      this.router.navigate(['/admin/guesthouses']);
    }
  }
}