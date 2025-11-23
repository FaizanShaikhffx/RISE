import { Component, OnInit } from '@angular/core';
import { AuditLogDto, AuditLogService } from 'src/app/services/audit-log.service';

@Component({
  selector: 'app-audit-log',
  templateUrl: './audit-log.component.html',
})
export class AuditLogComponent implements OnInit {
  logs: AuditLogDto[] = [];
  isLoading = true;

  constructor(private auditLogService: AuditLogService) { }

  ngOnInit(): void {
    this.auditLogService.getLogs().subscribe(data => {
      this.logs = data;
      this.isLoading = false;
    });
  }
}