import { Component, OnInit, NgZone } from '@angular/core'; 
import { GuesthouseService, GuestHouseDto } from 'src/app/services/guesthouse.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-guesthouse-list',
  templateUrl: './guesthouse-list.component.html'
})
export class GuesthouseListComponent implements OnInit {
  guesthouses: GuestHouseDto[] = [];
  successMessage: string | null = null; // 1. For the success UI

  constructor(
    private guesthouseService: GuesthouseService,
    private zone: NgZone, 
    private toastr: ToastrService,
  ) {}

  ngOnInit(): void {
    this.loadGuesthouses();
  }

  loadGuesthouses() {
    this.guesthouseService.getAll().subscribe(data => {
      this.guesthouses = data;
    });
  }

  deleteGuestHouse(id: number) {
    // 2. We removed the 'confirm()' box
    this.guesthouseService.delete(id).subscribe({
      next: () => {
        this.zone.run(() => {
          // 3. Set the success message
          this.toastr.success('Guesthouse deleted successfully.', 'Deleted');
          this.loadGuesthouses(); // Refresh the list

          // 4. Make the message disappear after 3 seconds
          setTimeout(() => {
            this.successMessage = null;
          }, 3000);
        });
      },
      error: (err) => {
       this.toastr.error('Failed to delete guesthouse.', 'Error');
      }
    });
  }
}