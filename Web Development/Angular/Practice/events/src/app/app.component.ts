import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  
  username: string = 'DefaultUser';

  
  updateUsername(newUsername: any) {
    console.log(newUsername); // Check the console to see what you are receiving!
    this.username = newUsername;
  }
}