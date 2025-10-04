import { Component } from '@angular/core';

@Component({
  selector: 'app-ng-if',
  templateUrl: './ng-if.component.html',
  styleUrls: ['./ng-if.component.css']
})
export class NgIfComponent {
  isLoggedIn = true; 
  fruits = ["Apple", "Banana", "Grapes", "PineApple"]
  user= {name: ""}; 
  isAdmin = true; 
  phones = ["Apple", "Samsung", "Motorola", "Asus"]

  color = "Marron"; 
}
