import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GetService {

  public url = `https://jsonplaceholder.typicode.com/posts`
  
  constructor( private client: HttpClient) { }

  getPosts(){
    return this.client.get(this.url);
  }

}
