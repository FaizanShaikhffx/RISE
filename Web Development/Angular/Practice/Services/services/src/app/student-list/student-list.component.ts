import { Component, OnInit } from '@angular/core';
import { StudentServiceService } from '../services/student-service.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
  // providers: [StudentServiceService]
})
export class StudentListComponent implements OnInit {

  // public student = [
  //   {name: "Adil", age: 25, standard: 12},
  //   {name: "Kumar", age: 19, standard: 11},
  //   {name: "Zain", age: 18, standard: 10},
  // ];

  student: any; 
  constructor(private std: StudentServiceService){
    this.student = std.getStudent(); 
  }

  ngOnInit(): void {
    
  }
}
