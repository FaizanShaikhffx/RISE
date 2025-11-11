import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

// Matches your GuestHouseDto
export interface GuestHouseDto {
  guestHouseId: number;
  name: string;
  location: string;
  description: string;
  imageUrl: string; // We added this for images
}

// Matches your GuestHouseCreateDto
export interface GuestHouseCreateDto {
  name: string;
  location: string;
  description: string;
  imageUrl: string;
}

@Injectable({
  providedIn: 'root'
})
export class GuesthouseService {
  private apiUrl = environment.apiUrl + '/GuestHouse';

  constructor(private http: HttpClient) { }

  getAll(): Observable<GuestHouseDto[]> {
    return this.http.get<GuestHouseDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<GuestHouseDto> {
    return this.http.get<GuestHouseDto>(`${this.apiUrl}/${id}`);
  }

  create(guesthouse: GuestHouseCreateDto): Observable<GuestHouseDto> {
    return this.http.post<GuestHouseDto>(this.apiUrl, guesthouse);
  }

  update(id: number, guesthouse: GuestHouseCreateDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, guesthouse);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}