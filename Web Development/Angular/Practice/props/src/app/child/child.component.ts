import { Component, Input, Output, EventEmitter  } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent {
  
 @Output() childData: EventEmitter<string> = new EventEmitter<string>();


sendData(){
  this.childData.emit("I am from Child");
}

  

}
