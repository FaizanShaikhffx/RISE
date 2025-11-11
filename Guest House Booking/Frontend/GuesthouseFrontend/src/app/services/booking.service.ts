import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

// --- DTO Interfaces ---

// Matches your BookingDto
export interface BookingDto {
  bookingId: number;
  userName: string;
  guestHouseName: string;
  roomName: string;
  bedNumber: string;
  dateFrom: Date;
  dateTo: Date;
  status: string;
  remarks: string;
  createdDate: Date;
}

// Matches your BookingRejectDto
export interface BookingRejectDto {
  remarks: string;
}

// Matches your BookingCreateDto
export interface BookingCreateDto {
  guestHouseId: number;
  roomId: number;
  bedId: number;
  dateFrom: Date;
  dateTo: Date;
}

// --- DTOs for the form dropdowns ---

// A simple version of GuestHouseDto
export interface FormGuestHouseDto {
  guestHouseId: number;
  name: string;
  location: string;
  description: string;
  imageUrl: string; // <-- So we can show the image
}

// A simple version of RoomDto
export interface FormRoomDto {
  roomId: number;
  roomName: string;
  genderAllowed: string;
}

// A simple version of BedDto
export interface FormBedDto {
  bedId: number;
  bedNumber: string;
}


@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private apiUrl = environment.apiUrl + '/Booking';

  constructor(private http: HttpClient) { }

  // --- Admin Endpoints ---
  getAllBookings(): Observable<BookingDto[]> {
    return this.http.get<BookingDto[]>(`${this.apiUrl}/all`);
  }

  approveBooking(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/approve/${id}`, {});
  }

  rejectBooking(id: number, dto: BookingRejectDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/reject/${id}`, dto);
  }

  // --- User Endpoints ---
  
  /** Gets all bookings for the currently logged-in user */
  getMyBookings(): Observable<BookingDto[]> {
    return this.http.get<BookingDto[]>(`${this.apiUrl}/my-bookings`);
  }

  /** Creates a new booking request */
  createBooking(dto: BookingCreateDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/create`, dto);
  }

  // --- Form Helper Endpoints ---

  /** Gets a list of all guesthouses for the form */
  getGuesthouseList(): Observable<FormGuestHouseDto[]> {
    return this.http.get<FormGuestHouseDto[]>(`${this.apiUrl}/guesthouses`);
  }

  /** Gets rooms for a specific guesthouse */
  getRoomsByGuesthouse(guesthouseId: number): Observable<FormRoomDto[]> {
    return this.http.get<FormRoomDto[]>(`${this.apiUrl}/rooms-by-guesthouse/${guesthouseId}`);
  }

  /** Gets available beds for a room and date range */
/** Gets available beds for a room and date range */
  getAvailableBeds(roomId: number, dateFrom: string, dateTo: string): Observable<FormBedDto[]> {
    
    // The dates are already in "YYYY-MM-DD" string format from the form.
    // We can pass them directly to HttpParams.
    
    const params = new HttpParams()
      .set('roomId', roomId.toString())
      .set('dateFrom', dateFrom) // <-- FIX: No more .toISOString()
      .set('dateTo', dateTo);    // <-- FIX: No more .toISOString()

    return this.http.get<FormBedDto[]>(`${this.apiUrl}/available-beds`, { params });
  }
}