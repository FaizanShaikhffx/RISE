import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

// This interface matches our new .NET DTO
export interface AuditLogDto {
  auditLogId: number;
  action: string;
  userName: string;
  timestamp: Date;
  oldValue: string;
  newValue: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuditLogService {
  private apiUrl = environment.apiUrl + '/AuditLog';

  constructor(private http: HttpClient) { }

  /** Gets all audit logs from the API */
  getLogs(): Observable<AuditLogDto[]> {
    return this.http.get<AuditLogDto[]>(this.apiUrl);
  }
}