import { Component, OnInit } from '@angular/core';
import { RoomDto, RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html'
})
export class RoomListComponent implements OnInit {
  rooms: RoomDto[] = [];

  constructor(private roomService: RoomService) {}

  ngOnInit(): void {
    this.loadRooms();
  }

  loadRooms(): void {
    this.roomService.getAll().subscribe(data => {
      this.rooms = data;
    });
  }

  deleteRoom(id: number): void {
    if (confirm('Are you sure you want to delete this room?')) {
      this.roomService.delete(id).subscribe(() => {
        this.loadRooms();
      });
    }
  }
}