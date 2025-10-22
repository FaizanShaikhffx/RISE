import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  userForm: FormGroup; 
  
  constructor(private fb: FormBuilder){
    this.userForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]]
    })
  }

  get Name(){
    return this.userForm.get('name')!; 
  }
}
