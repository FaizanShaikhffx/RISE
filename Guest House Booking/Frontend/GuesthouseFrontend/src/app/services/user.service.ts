import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

// Matches your UserCreateDto
export interface UserCreateDto {
  userName: string;
  email: string;
  gender: string;
  role: string; // "Admin" or "User"
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  // Note: The endpoint is in 'Auth', not a new 'User' controller
  private apiUrl = environment.apiUrl + '/Auth';

  constructor(private http: HttpClient) { }

  createUser(user: UserCreateDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/create-user`, user);
  }
}