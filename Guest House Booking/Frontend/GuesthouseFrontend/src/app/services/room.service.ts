import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

// Matches your RoomDto
export interface RoomDto {
  roomId: number;
  guestHouseId: number;
  roomName: string;
  genderAllowed: string;
}

// Matches your RoomCreateDto
export interface RoomCreateDto {
  guestHouseId: number;
  roomName: string;
  genderAllowed: string; // "Male", "Female", "Any"
}

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  private apiUrl = environment.apiUrl + '/Room';

  constructor(private http: HttpClient) { }

  getAll(): Observable<RoomDto[]> {
    return this.http.get<RoomDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<RoomDto> {
    return this.http.get<RoomDto>(`${this.apiUrl}/${id}`);
  }

  create(room: RoomCreateDto): Observable<RoomDto> {
    return this.http.post<RoomDto>(this.apiUrl, room);
  }

  update(id: number, room: RoomCreateDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, room);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

getAllByGuesthouse(guesthouseId: number): Observable<RoomDto[]> {
    // We can re-use the API endpoint from the booking controller
    return this.http.get<RoomDto[]>(`${environment.apiUrl}/Booking/rooms-by-guesthouse/${guesthouseId}`);
  }
}