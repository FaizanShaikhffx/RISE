import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
})
export class AdminDashboardComponent implements OnInit {
  adminName: string = '';
  pendingBookingCount: number = 0;
  totalBookings: number = 0;

  constructor(
    private authService: AuthService,
    private bookingService: BookingService
  ) {}

  ngOnInit(): void {
    // 1. Get the admin's name
    this.authService.user$.subscribe(user => {
      if (user) {
        this.adminName = user.userName;
      }
    });

    // 2. Get booking statistics
    this.bookingService.getAllBookings().subscribe(bookings => {
      this.totalBookings = bookings.length;
      this.pendingBookingCount = bookings.filter(b => b.status === 'Pending').length;
    });
  }
}