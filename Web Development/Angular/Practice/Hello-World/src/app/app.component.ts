import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface Todo {
  title: string;
  completed: boolean;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  name=  "Anil"

  changeName(event: Event){
    this.name = (event.target as HTMLInputElement).value; 
  }
}
