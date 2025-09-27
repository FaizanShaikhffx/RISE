import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-app',
  templateUrl: './counter-app.component.html',
  styleUrls: ['./counter-app.component.css']
})
export class CounterAppComponent {
  count:number = 0; 

  decrement(){
    this.count = this.count - 1; 
  }
  
  reset(){
    
    this.count = 0; 
  }
  
  increament(){
    this.count = this.count + 1; 
    
  }
  
  handleCounter(val: string){

    if(this.count < 1){
      this.count  = 0; 
    }

    if(val == 'plus'){
      this.count = this.count + 1; 
    }else if(val =='minus'){
      this.count = this.count - 1; 
    }else if(val == 'reset'){
      this.count = 0; 
    }
  }

}
