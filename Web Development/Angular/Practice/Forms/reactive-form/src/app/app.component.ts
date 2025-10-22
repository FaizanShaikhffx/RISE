import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
 
userForm = new FormGroup({
  name: new FormControl('', [Validators.required, Validators.minLength(5)]),
  age: new FormControl('', [Validators.required, Validators.min(18), Validators.max(65)]),
  password: new FormControl('', [Validators.required, Validators.minLength(5)]),
  gender: new FormControl('', [Validators.required])
})



get Name(){
  return this.userForm.get("name")!;
}
get Age(){
  return this.userForm.get("age")!; 
}
get Password(){
  return this.userForm.get("password")!; 
}
get Gender(){
  return this.userForm.get("gender")!; 
}

  onSubmit(){
    console.log(this.userForm.value);
    
  }

}
