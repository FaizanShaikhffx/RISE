import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  count = 1; 
  
 handleIncreament(){
  this.count = this.count + 1; 
 }
}
