import { Component } from '@angular/core';

@Component({
  selector: 'app-inline-style-template',
  template: `
    <p>
      inline-style-template works!
    </p>
    <p>
      inline-style-template Added
    </p>
  `,
  styles: [
    `p{
      color:red; 
    }`
  ]
})
export class InlineStyleTemplateComponent {

}
