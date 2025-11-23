import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

// Matches your BedDto
export interface BedDto {
  bedId: number;
  roomId: number;
  bedNumber: string;
}

// Matches your BedCreateDto
export interface BedCreateDto {
  roomId: number;
  bedNumber: string;
}

@Injectable({
  providedIn: 'root'
})
export class BedService {
  private apiUrl = environment.apiUrl + '/Bed';

  constructor(private http: HttpClient) { }

  getAll(): Observable<BedDto[]> {
    return this.http.get<BedDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<BedDto> {
    return this.http.get<BedDto>(`${this.apiUrl}/${id}`);
  }

  create(bed: BedCreateDto): Observable<BedDto> {
    return this.http.post<BedDto>(this.apiUrl, bed);
  }

  update(id: number, bed: BedCreateDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, bed);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  getAllByRoom(roomId: number): Observable<BedDto[]> {
    return this.http.get<BedDto[]>(`${environment.apiUrl}/Bed/by-room/${roomId}`);
  }
}