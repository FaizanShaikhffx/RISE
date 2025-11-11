import { Component, OnInit } from '@angular/core';
import { BookingDto, BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-my-bookings',
  templateUrl: './my-bookings.component.html'
})
export class MyBookingsComponent implements OnInit {
  myBookings: BookingDto[] = [];
  isLoading = true;

  constructor(private bookingService: BookingService) { }

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings(): void {
    this.isLoading = true;
    this.bookingService.getMyBookings().subscribe({
      next: (data) => {
        this.myBookings = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Failed to load bookings', err);
        this.isLoading = false;
      }
    });
  }
}