import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'component';
  color='red'
  username=''
  inputVal = '';  
  isSubscribed = false; 
  gender = 'male'
  // handleClick(){
  //   alert("Button is Clicked")
  // }

  // handleInput(event: Event){
  //   let val = (event.target as HTMLInputElement).value;
  //   this.inputVal = val; 
  // }
}
