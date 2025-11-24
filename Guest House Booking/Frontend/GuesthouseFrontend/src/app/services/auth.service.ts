import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from '../environments/environment';


interface LoginResponse {
  token: string;
  userName: string, 
  role: string,
  gender: string; // <-- ADD THIS LINE
}

interface ResetPasswordDto {
    email: string;
    otp: string;
    newPassword: string;
}

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private apiUrl = environment.apiUrl + '/Auth'; 

  private userSubject = new BehaviorSubject<LoginResponse | null>(null);
  public user$ = this.userSubject.asObservable(); 

  constructor(private http: HttpClient) {
    this.loadUserFromStorage(); 
  }

  isLoggedIn():boolean {
    return !!this.userSubject.value; // 'true' if user is not null
  }

  isAdmin(): boolean{
    return this.userSubject.value?.role == "Admin"; 
  }

  getToken(): string|null{
    return this.userSubject.value?.token || null; 
  }

  getRole(): string | null{
    return this.userSubject.value?.role || null;
  }
  getGender(): string | null {
    return this.userSubject.value?.gender || null; // <-- ADD THIS METHOD
  }

  private loadUserFromStorage(){
    const user = localStorage.getItem('user');
    if(user){
      this.userSubject.next(JSON.parse(user));
    }
  }

  login(email: string, password: string): Observable<LoginResponse>{
    return this.http
    .post<LoginResponse>(`${this.apiUrl}/login`, {email, password})
    .pipe(
      tap((response)=>{
        this.userSubject.next(response); 

        localStorage.setItem('user', JSON.stringify(response)); 
      })
    );
  }

  logout(){
    localStorage.removeItem('user');

    this.userSubject.next(null);
  }

  forgotPassword(email: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/forgot-password`, { email });
  }

  resetPassword(dto: ResetPasswordDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/reset-password`, dto);
  }

  getProfile(): Observable<any> {
    return this.http.get(`${this.apiUrl}/profile`);
  }
  // ... inside AuthService class

  // Matches the DTO
  updateProfile(data: { userName: string, email: string, gender: string }): Observable<any> {
    return this.http.put(`${this.apiUrl}/update-profile`, data).pipe(
      tap((response: any) => {
        // --- THIS IS CRITICAL ---
        // The API sent back a new token and user info.
        // We must update the local storage so the Navbar updates instantly.
        const updatedUser = {
          token: response.token,
          userName: response.userName,
          role: response.role,
          gender: response.gender
        };

        localStorage.setItem('user', JSON.stringify(updatedUser));
        this.userSubject.next(updatedUser); // Notify the rest of the app
      })
    );
  }
  
  // Helper to get the current email (you might need this for the form)
  getEmail(): string {
    // We need to decode the token to get the email, 
    // OR just save email in the login response. 
    // For now, let's assume we save it or the user types it.
    // A simpler way for this form is to let the user just see their current data.
    // Let's skip this helper and load data via a new API call if needed, 
    // or just use what we have.
    return ''; 
  }

}
