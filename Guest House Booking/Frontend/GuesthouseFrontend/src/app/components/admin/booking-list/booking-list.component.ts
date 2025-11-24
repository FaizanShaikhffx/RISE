import { Component, OnInit } from '@angular/core';
import { BookingDto, BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html'
})
export class BookingListComponent implements OnInit {
  allBookings: BookingDto[] = []; // Stores everything from API
  filteredBookings: BookingDto[] = []; // Stores what we show on screen
  
  // Default filter
  currentFilter: string = 'Pending'; 

  constructor(private bookingService: BookingService) {}

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings(): void {
    this.bookingService.getAllBookings().subscribe(data => {
      this.allBookings = data;
      // Apply the filter immediately after loading
      this.applyFilter();
    });
  }

  setFilter(status: string) {
    this.currentFilter = status;
    this.applyFilter();
  }

  applyFilter() {
    if (this.currentFilter === 'All') {
      this.filteredBookings = [...this.allBookings];
    } else {
      this.filteredBookings = this.allBookings.filter(b => b.status === this.currentFilter);
    }
  }

  onApprove(id: number): void {
    if (confirm('Are you sure you want to approve this booking?')) {
      this.bookingService.approveBooking(id).subscribe(() => {
        this.loadBookings(); 
      });
    }
  }

  onReject(id: number): void {
    const remarks = prompt('Please enter a reason for rejection:');
    if (remarks) {
      this.bookingService.rejectBooking(id, { remarks }).subscribe(() => {
        this.loadBookings(); 
      });
    }
  }
}