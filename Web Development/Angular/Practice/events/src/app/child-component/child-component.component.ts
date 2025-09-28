import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-child',
  template: `<button (click)="notifyParent()">Notify Parent</button>`
})

export class ChildComponentComponent {
  
  @Output() notify = new EventEmitter<string>(); 

  notifyParent(){
    this.notify.emit('A message from child component'); 
  }
}
