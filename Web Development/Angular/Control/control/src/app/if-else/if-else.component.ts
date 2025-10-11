import { Component } from '@angular/core';

@Component({
  selector: 'app-if-else',
  templateUrl: './if-else.component.html',
  styleUrls: ['./if-else.component.css']
})
export class IfElseComponent {
  age: number | null = null;
  user = [{name: "Faizan", id: 1}]; 
  
}

