import { Component, OnInit } from '@angular/core';
import { GetService } from './services/get.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
 
  data: any; 

  constructor(private posts: GetService) {}

  ngOnInit(): void {
    this.posts.getPosts().subscribe(response => {
      this.data = response
      console.log(response);
    })
  }
  

}
