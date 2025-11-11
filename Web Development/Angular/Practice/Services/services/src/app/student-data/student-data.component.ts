import { Component, OnInit } from '@angular/core';
import { StudentServiceService } from '../services/student-service.service';

@Component({
  selector: 'app-student-data',
  templateUrl: './student-data.component.html',
  styleUrls: ['./student-data.component.css'],
  // providers: [StudentServiceService]
})
export class StudentDataComponent  {

  public student: any; 

  constructor(private std: StudentServiceService){
    this.student = std.getStudent(); 
    console.log(this.student);
  }


  // public student = [
  //   {name: "Adil", age: 25, standard: 12},
  //   {name: "Kumar", age: 19, standard: 11},
  //   {name: "Zain", age: 18, standard: 10},
  // ];
  
}
