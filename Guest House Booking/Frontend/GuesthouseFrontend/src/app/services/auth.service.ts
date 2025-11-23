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

}
