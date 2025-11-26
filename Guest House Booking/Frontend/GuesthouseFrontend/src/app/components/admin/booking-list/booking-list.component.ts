import { Component, OnInit } from '@angular/core';
import { BookingDto, BookingService } from 'src/app/services/booking.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html'
})
export class BookingListComponent implements OnInit {
  allBookings: BookingDto[] = []; 
  filteredBookings: BookingDto[] = []; 
  currentFilter: string = 'Pending'; 
  
  // Loading state
  processingBookingId: number | null = null; 
  processingAction: 'Approve' | 'Reject' | null = null;

  // --- NEW VARIABLES FOR INLINE REJECT ---
  rejectingBookingId: number | null = null; // Which row is showing the input?
  rejectionRemark: string = ''; // The text typed in that input

  constructor(
    private bookingService: BookingService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings(): void {
    this.bookingService.getAllBookings().subscribe(data => {
      this.allBookings = data;
      this.applyFilter();
    });
  }

  setFilter(status: string) {
    this.currentFilter = status;
    this.applyFilter();
    // Reset reject mode if user switches tabs
    this.cancelReject(); 
  }

  applyFilter() {
    if (this.currentFilter === 'All') {
      this.filteredBookings = [...this.allBookings];
    } else {
      this.filteredBookings = this.allBookings.filter(b => b.status === this.currentFilter);
    }
  }

  // --- APPROVE LOGIC ---
  onApprove(id: number): void {
    if (this.processingBookingId !== null) return;

    this.processingBookingId = id;
    this.processingAction = 'Approve';

    this.bookingService.approveBooking(id).subscribe({
      next: () => {
        this.toastr.success('Booking Approved Successfully!', 'Approved');
        this.loadBookings();
        this.resetProcessingState();
      },
      error: (err) => {
        this.toastr.error('Failed to approve booking.', 'Error');
        this.resetProcessingState();
      }
    });
  }

  // --- NEW REJECT LOGIC (Inline) ---

  // 1. Click "Reject" button -> Shows Input
  initiateReject(id: number): void {
    // If another row is open, close it
    this.rejectingBookingId = id;
    this.rejectionRemark = ''; 
  }

  // 2. Click "Cancel" button -> Hides Input
  cancelReject(): void {
    this.rejectingBookingId = null;
    this.rejectionRemark = '';
  }

  // 3. Click "Confirm Reject" -> Calls API
  confirmReject(id: number): void {
    if (!this.rejectionRemark.trim()) {
      this.toastr.warning('Please enter a reason for rejection.', 'Reason Required');
      return;
    }

    if (this.processingBookingId !== null) return;

    this.processingBookingId = id;
    this.processingAction = 'Reject';

    this.bookingService.rejectBooking(id, { remarks: this.rejectionRemark }).subscribe({
      next: () => {
        this.toastr.warning('Booking Rejected.', 'Rejected');
        this.loadBookings();
        this.resetProcessingState();
        this.cancelReject(); // Close the input
      },
      error: (err) => {
        this.toastr.error('Failed to reject booking.', 'Error');
        this.resetProcessingState();
      }
    });
  }

  resetProcessingState() {
    this.processingBookingId = null;
    this.processingAction = null;
  }
}