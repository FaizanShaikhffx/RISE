import { Component, OnInit } from '@angular/core';
import { BedDto, BedService } from 'src/app/services/bed.service';

@Component({
  selector: 'app-bed-list',
  templateUrl: './bed-list.component.html'
})
export class BedListComponent implements OnInit {
  beds: BedDto[] = [];

  constructor(private bedService: BedService) {}

  ngOnInit(): void {
    this.loadBeds();
  }

  loadBeds(): void {
    this.bedService.getAll().subscribe(data => {
      this.beds = data;
    });
  }

  deleteBed(id: number): void {
    if (confirm('Are you sure you want to delete this bed?')) {
      this.bedService.delete(id).subscribe(() => {
        this.loadBeds();
      });
    }
  }
}