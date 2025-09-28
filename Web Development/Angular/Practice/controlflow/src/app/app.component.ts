import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  // title = 'controlflow';
  // display = true; 

  // toggleHideDiv(){
  //   this.display = false
  // }
  // toggleShowDiv(){
  //   this.display = true
  // }
  // toggle(){
  //   // if(this.display){
  //   //   this.display = false;
  //   // }else{
  //   //   this.display = true;
  //   // }
  //   this.display = this.display ? false : true; 
  // }

  // color = 1; 
  // toggle(num: number){
  //   this.color = num; 
  // }
  // toggleInput(event: Event){
  //   let res:any = (event.target as HTMLInputElement).value; 
  //   if(res == 1){
  //     this.color = 1; 
  //   }else if(res == 2){
  //     this.color = 2; 
  //   }else if(res == 3){
  //     this.color = 3; 
  //   }else if(res == 4){
  //     this.color = 4; 
  //   }else if(res == ""){
  //     this.color = 1; 
  //   }
  //   else{
  //     this.color = 4; 
  //   }
  // }

  tasks = [
    { id: 1, title: 'Learn @for syntax' },
    { id: 2, title: 'Practice with a debugging task' },
    { id: 3, title: 'Master Angular control flow' }
  ];

  // Empties the tasks array
  clearTasks() {
    this.tasks = [];
  }

}
