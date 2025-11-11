import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentServiceService {

  constructor() { }

  getStudent(){
    return [
    {name: "Adil", age: 25, standard: 12},
    {name: "Kumar", age: 19, standard: 11},
    {name: "Zain", age: 18, standard: 10},
  ];
  }

}
