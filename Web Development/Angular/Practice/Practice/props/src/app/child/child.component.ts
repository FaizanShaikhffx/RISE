import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-child',
  template: '<p>Received from Parent {{name}}</p>',
  styleUrls: ['./child.component.css']
})
export class ChildComponent {
 @Input() name?: string; 
}
