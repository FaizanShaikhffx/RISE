
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
 
  profileForm = new FormGroup({
    name: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required, Validators.minLength(6)]),
    email: new FormControl('', [Validators.required, Validators.maxLength(8)])
  }); 

  onSubmit(){
    console.log(this.profileForm.value)
  }

  get name(){
    return this.profileForm.get("name");
  }
  get email(){
    return this.profileForm.get("email");
  }
  get password(){
    return this.profileForm.get("password")
  }




}
