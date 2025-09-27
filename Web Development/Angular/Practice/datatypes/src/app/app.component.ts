import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  
  user: {name: string} = {name: ""}; 

  async getUser(){
    console.log("Fetching user..."); 

    let user = await this.fetchUserFromApi(); 
    this.user.name =  user.name; 
    console.log("user found : "+user.name); 
  }

  fetchUserFromApi(): Promise<{name: string}>{
    return new Promise(resolve =>{
      setTimeout(()=>{
        resolve({name: "Eva"})
      }, 2000)
    })
  }
}
