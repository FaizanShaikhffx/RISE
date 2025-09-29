import { Component, computed, effect, Signal, signal, WritableSignal } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  // data : WritableSignal<number > = signal(10);
  // // count: Signal<number> = computed(()=>10) 

  // updateSignal(){
  //   this.data.update((val) => val + 1); 
  // }

  // x = signal(10); 
  // y = signal(20); 
  // z = computed(()=>this.x() + this.y())

  // showSignalValue(){

  //   console.log(this.z());
    
  // }
  

  username = signal("Anil"); 
  display = false; 
  count = signal(0); 

  constructor(){
    effect(()=>{
      if(this.count() == 2){
        this.display = true; 
      }else{
        this.display = false; 
      }
    })
  }

  toggleValue(){
   this.count.set(this.count() + 1)
  }
 
}
