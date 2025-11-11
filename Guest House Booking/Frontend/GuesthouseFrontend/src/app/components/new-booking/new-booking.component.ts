import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingCreateDto, BookingService, FormBedDto, FormGuestHouseDto, FormRoomDto } from 'src/app/services/booking.service';
import { AuthService } from 'src/app/services/auth.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-new-booking',
  templateUrl: './new-booking.component.html',
  providers: [DatePipe]
})
export class NewBookingComponent implements OnInit {
  step = 1; // 1: Guesthouse, 2: Room, 3: Dates/Beds

  // Data
  guesthouses: FormGuestHouseDto[] = [];
  allRooms: FormRoomDto[] = []; // All rooms for the guesthouse
  filteredRooms: FormRoomDto[] = []; // Rooms filtered by gender
  availableBeds: FormBedDto[] = [];

  // Selections
  selectedGuesthouse: FormGuestHouseDto | null = null;
  selectedRoom: FormRoomDto | null = null;
  
  // Form
  dateForm: FormGroup;
  availabilityMessage: string | null = null;
  minDate: string; // To prevent booking past dates

  constructor(
    private bookingService: BookingService,
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    public datePipe: DatePipe
  ) {
    // Set minimum date for date picker
    this.minDate = new Date().toISOString().split('T')[0];

    this.dateForm = this.fb.group({
      dateFrom: [this.minDate, Validators.required],
      dateTo: ['', Validators.required]
    }, { validator: this.dateRangeValidator });
  }

  // Validator to ensure DateTo is after DateFrom
 // ... inside new-booking.component.ts

  // Validator to ensure DateTo is AT LEAST one day AFTER DateFrom
  dateRangeValidator(group: FormGroup) {
    const from = group.get('dateFrom')?.value;
    const to = group.get('dateTo')?.value;
    if (from && to && new Date(to) <= new Date(from)) { // <-- Use <=
      return { invalidRange: true };
    }
    return null;
  }

  ngOnInit(): void {
    this.loadGuesthouses();
  }

  loadGuesthouses(): void {
    this.bookingService.getGuesthouseList().subscribe(data => {
      this.guesthouses = data;
    });
  }

  // --- Step 1: Guesthouse Selection ---
  selectGuesthouse(guesthouse: FormGuestHouseDto): void {
    this.selectedGuesthouse = guesthouse;
    this.step = 2;

    this.bookingService.getRoomsByGuesthouse(guesthouse.guestHouseId).subscribe(data => {
 
      // --- FIX FOR GENDER FILTERING ---
      // This shows ALL rooms, unfiltered.
      this.allRooms = data;
      this.filteredRooms = data;
    });
  }

  // --- Step 2: Room Selection ---
  selectRoom(room: FormRoomDto): void {
    this.selectedRoom = room;
    this.step = 3;
    this.dateForm.get('dateFrom')?.patchValue(this.minDate); // Reset date
    this.dateForm.get('dateTo')?.patchValue('');
  }

  // --- Step 3: Date & Bed Selection ---
  // Inside new-booking.component.ts
  checkAvailability(): void {
    if (this.dateForm.invalid || !this.selectedRoom) {
      // This might be one reason "nothing happens" - the form is invalid
      this.availabilityMessage = "Please select both a 'From' and 'To' date.";
      return;
    }

    // Check for bad date range
    if (this.dateForm.hasError('invalidRange')) {
      this.availabilityMessage = "'To' date must be after 'From' date.";
      return;
    }

    this.availableBeds = []; 
    this.availabilityMessage = "Checking..."; // Give user feedback
    
    const { dateFrom, dateTo } = this.dateForm.value;
    const roomId = this.selectedRoom.roomId;

    this.bookingService.getAvailableBeds(roomId, dateFrom, dateTo).subscribe({
      next: (beds) => {
        if (beds.length > 0) {
          this.availableBeds = beds;
          this.availabilityMessage = null; // Success, hide message
        } else {
          this.availabilityMessage = 'No beds are available for the selected dates.';
        }
      },
      // --- THIS IS THE FIX ---
      // Add an error block to catch API failures
      error: (err) => {
        console.error('Failed to check availability', err);
        this.availabilityMessage = 'An error occurred. Please try again.';
      }
    });
  }
  
  // --- Final Step: Submit ---
// ... inside new-booking.component.ts

  submitBooking(bedId: number): void {
    if (!this.selectedGuesthouse || !this.selectedRoom || !this.dateForm.valid) {
      return;
    }
    
    const { dateFrom, dateTo } = this.dateForm.value;

    // --- THIS IS THE FIX ---
    // Convert the date strings from the form into real Date objects
    // before sending them to the service.
    const bookingDto: BookingCreateDto = {
      guestHouseId: this.selectedGuesthouse.guestHouseId,
      roomId: this.selectedRoom.roomId,
      bedId: bedId,
      dateFrom: new Date(dateFrom + 'T00:00:00Z'), // <-- FIX
      dateTo: new Date(dateTo + 'T00:00:00Z')   // <-- CONVERT TO DATE
    };

    if (confirm('Are you sure you want to submit this booking request?')) {
      this.bookingService.createBooking(bookingDto).subscribe({
        next: (response: { message: string }) => {
          alert(response.message);
          this.router.navigate(['/my-bookings']);
        },
        error: (err) => {
          // This will now show the *real* error from your API's try/catch block
          alert(err.error?.message || err.error?.details || 'Booking failed. Please try again.');
          console.error(err);
        }
      });
    }
  }
  // Helper to go back
  goBack(toStep: number) {
    this.step = toStep;
    this.availableBeds = [];
    this.availabilityMessage = null;
  }
}