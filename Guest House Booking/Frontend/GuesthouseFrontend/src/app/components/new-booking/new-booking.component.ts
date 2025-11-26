import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingService, FormBedDto, FormGuestHouseDto, FormRoomDto, BookingCreateDto } from 'src/app/services/booking.service';
import { AuthService } from 'src/app/services/auth.service';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr'; // <-- 1. Import Toastr

@Component({
  selector: 'app-new-booking',
  templateUrl: './new-booking.component.html',
  providers: [DatePipe]
})
export class NewBookingComponent implements OnInit {
  step = 1; 

  // Data
  guesthouses: FormGuestHouseDto[] = [];
  allRooms: FormRoomDto[] = []; 
  filteredRooms: FormRoomDto[] = []; 
  availableBeds: FormBedDto[] = [];

  // Selections
  selectedGuesthouse: FormGuestHouseDto | null = null;
  selectedRoom: FormRoomDto | null = null;
  
  // Form
  dateForm: FormGroup;
  availabilityMessage: string | null = null;
  minDate: string; 

  loadingBedId: number | null = null; // Tracks which bed is currently processing

  constructor(
    private bookingService: BookingService,
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    public datePipe: DatePipe,
    private toastr: ToastrService // <-- 2. Inject Toastr
  ) {
    this.minDate = new Date().toISOString().split('T')[0];

    this.dateForm = this.fb.group({
      dateFrom: [this.minDate, Validators.required],
      dateTo: ['', Validators.required]
    }, { validator: this.dateRangeValidator });
  }

  dateRangeValidator(group: FormGroup) {
    const from = group.get('dateFrom')?.value;
    const to = group.get('dateTo')?.value;
    if (from && to && new Date(to) <= new Date(from)) {
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

  selectGuesthouse(guesthouse: FormGuestHouseDto): void {
    this.selectedGuesthouse = guesthouse;
    this.step = 2;
    this.bookingService.getRoomsByGuesthouse(guesthouse.guestHouseId).subscribe(data => {
      this.allRooms = data;
      this.filteredRooms = data; 
    });
  }

  selectRoom(room: FormRoomDto): void {
    this.selectedRoom = room;
    this.step = 3;
    this.dateForm.get('dateFrom')?.patchValue(this.minDate); 
    this.dateForm.get('dateTo')?.patchValue('');
  }

  checkAvailability(): void {
    if (this.dateForm.invalid || !this.selectedRoom) {
      this.availabilityMessage = "Please select valid dates.";
      return;
    }
    
    if (this.dateForm.hasError('invalidRange')) {
      this.availabilityMessage = "Invalid date range.";
      return;
    }

    this.availableBeds = []; 
    this.availabilityMessage = "Checking availability...";
    
    const { dateFrom, dateTo } = this.dateForm.value;
    const roomId = this.selectedRoom.roomId;

    this.bookingService.getAvailableBeds(roomId, dateFrom, dateTo).subscribe({
      next: (beds) => {
        if (beds.length > 0) {
          this.availableBeds = beds;
          this.availabilityMessage = null; 
        } else {
          this.availabilityMessage = 'No beds are available for the selected dates.';
        }
      },
      error: (err) => {
        console.error('Failed to check availability', err);
        this.availabilityMessage = 'An error occurred. Please try again.';
        this.toastr.error('Could not check availability.', 'System Error'); // Toast for error
      }
    });
  }
  
 submitBooking(bedId: number): void {
    if (!this.selectedGuesthouse || !this.selectedRoom || !this.dateForm.valid) {
      return;
    }
    
    // Prevent double-clicking
    if (this.loadingBedId !== null) return;

    const { dateFrom, dateTo } = this.dateForm.value;

    const bookingDto: BookingCreateDto = {
      guestHouseId: this.selectedGuesthouse.guestHouseId,
      roomId: this.selectedRoom.roomId,
      bedId: bedId,
      dateFrom: new Date(dateFrom + 'T00:00:00Z'), 
      dateTo: new Date(dateTo + 'T00:00:00Z')      
    };

    // Set loading state
    this.loadingBedId = bedId; 

    this.bookingService.createBooking(bookingDto).subscribe({
      next: (response: { message: string }) => {
        this.toastr.success(response.message, 'Booking Submitted!'); 
        this.router.navigate(['/my-bookings']);
        // No need to reset loadingBedId because we are navigating away
      },
      error: (err) => {
        // Reset loading state on error
        this.loadingBedId = null; 
        let msg = err.error?.message || 'Booking failed. Please try again.';
        this.toastr.error(msg, 'Booking Failed'); 
      }
    });
  }

  goBack(toStep: number) {
    this.step = toStep;
    this.availableBeds = [];
    this.availabilityMessage = null;
  }
}