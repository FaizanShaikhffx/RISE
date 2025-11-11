import { Component, OnInit } from '@angular/core';
import { BookingDto, BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html'
})
export class BookingListComponent implements OnInit {
  bookings: BookingDto[] = [];

  constructor(private bookingService: BookingService) {}

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings(): void {
    this.bookingService.getAllBookings().subscribe(data => {
      this.bookings = data;
    });
  }

  onApprove(id: number): void {
    if (confirm('Are you sure you want to approve this booking?')) {
      this.bookingService.approveBooking(id).subscribe(() => {
        this.loadBookings(); // Refresh list
      });
    }
  }

  onReject(id: number): void {
    const remarks = prompt('Please enter a reason for rejection:');
    if (remarks) {
      this.bookingService.rejectBooking(id, { remarks }).subscribe(() => {
        this.loadBookings(); // Refresh list
      });
    }
  }
}