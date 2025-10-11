import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-template-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './template-form.component.html',
  styleUrls: ['./template-form.component.css']
})

export class TemplateFormComponent {
  userObj: any = {
    name: '',
    email: '',
    password: '',
    age: null,
    gender: '',
  }

  onSave(){
   
    const formValue = this.userObj; 
  }
}
