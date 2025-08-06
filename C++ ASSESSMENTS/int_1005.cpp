#include<bits/stdc++.h>
using namespace std; 

int main(){

  int choice; 
  cout<<"Press 1. Add Student Marks"<<endl; 
  cout<<"Press 2. Display All Marks"<<endl; 
  cout<<"Press 3. Calculate Average Marks"<<endl; 
  cout<<"Press 4. Find Grade of a Student"<<endl; 
  cout<<"Press 5. Exit"<<endl; 

  cout<<"Enter the choice : "; 
  cin>>choice; 

  switch(choice){
    case 1:
    int student1; 
    cout<<"Enter student1 marks: "; 
    cin>>student1; 

    int student2;  
    cout<<"Enter student2 marks : "; 
    cin>>student2;  

    int student3; 
    cout<<"Enter student3 marks : "; 
    cin>>student3; 

    int student4; 
    cout<<"Enter student4 Marks : "; 
    cin>>student4; 

    int student5; 
    cout<<"Enter student5 Marks : "; 
    cin>>student5; 
    
    cout<<"marks added  successfully"<<endl; 
    cout<<"Press 1. Add Student Marks"<<endl; 
    cout<<"Press 2. Display All Marks"<<endl; 
    cout<<"Press 3. Calculate Average Marks"<<endl; 
    cout<<"Press 4. Find Grade of a Student"<<endl; 
    cout<<"Press 5. Exit"<<endl; 
    cout<<"Enter the choice : "; 
    cin>>choice; 
    
    case 2:
    cout<<"student1 Marks : "<<student1<<endl; 
    cout<<"student2 Marks : "<<student2<<endl; 
    cout<<"student3 Marks : "<<student3<<endl; 
    cout<<"student4 Marks : "<<student4<<endl; 
    cout<<"student5 Marks : "<<student5<<endl; 

    cout<<"Press 1. Add Student Marks"<<endl; 
    cout<<"Press 2. Display All Marks"<<endl; 
    cout<<"Press 3. Calculate Average Marks"<<endl; 
    cout<<"Press 4. Find Grade of a Student"<<endl; 
    cout<<"Press 5. Exit"<<endl; 
    cout<<"Enter the choice : "; 
    cin>>choice; 


    case 3: 
    int avg; 
    avg = (student1 + student2 + student3 + student4 + student5) / 5; 
    cout<<"Average marks : "<<avg<<endl; 

    cout<<"Press 1. Add Student Marks"<<endl; 
    cout<<"Press 2. Display All Marks"<<endl; 
    cout<<"Press 3. Calculate Average Marks"<<endl; 
    cout<<"Press 4. Find Grade of a Student"<<endl; 
    cout<<"Press 5. Exit"<<endl; 
    cout<<"Enter the choice : "; 
    cin>>choice; 
   
    case 4: 
    int studentNumber; 
    cout<<"Enter Student number : "; 
    cin>>studentNumber; 

    if(studentNumber == 1){
  
      if(student1 > 80){
        cout<<"grade A"<<endl; 
      }else if(student1 >= 70 && student1 <= 80){
        cout<<"grade b"<<endl; 
      }else if(student1 >= 60 && student1 <= 70){
        cout<<"grade c"<<endl; 
      }else if(student1 >= 50 && student1 <= 60){
        cout<<"grade d"<<endl; 
      }else if(student1 >= 40 && student1 <= 50){
        cout<<"grade e"<<endl; 
      }else if(student1 < 40){
        cout<<"fail"<<endl; 
      }
    }else if(studentNumber == 2){
      if(student2 > 80){
        cout<<"grade A"<<endl; 
      }else if(student2 >= 70 && student2 <= 80){
        cout<<"grade b"<<endl; 
      }else if(student2 >= 60 && student2 <= 70){
        cout<<"grade c"<<endl; 
      }else if(student2 >= 50 && student2 <= 60){
        cout<<"grade d"<<endl; 
      }else if(student2 >= 40 && student2 <= 50){
        cout<<"grade e"<<endl; 
      }else if(student2 < 40){
        cout<<"fail"<<endl; 
      }
    }else if(studentNumber == 3){
      if(student3 > 80){
        cout<<"grade A"<<endl; 
      }else if(student3 >= 70 && student3 <= 80){
        cout<<"grade b"<<endl; 
      }else if(student3 >= 60 && student3 <= 70){
        cout<<"grade c"<<endl; 
      }else if(student3 >= 50 && student3 <= 60){
        cout<<"grade d"<<endl; 
      }else if(student3 >= 40 && student3 <= 50){
        cout<<"grade e"<<endl; 
      }else if(student3 < 40){
        cout<<"fail"<<endl; 
      }
      
    }else if(studentNumber == 4){
      if(student4 > 80){
        cout<<"grade A"<<endl; 
      }else if(student4 >= 70 && student4 <= 80){
        cout<<"grade b"<<endl; 
      }else if(student4 >= 60 && student4 <= 70){
        cout<<"grade c"<<endl; 
      }else if(student4 >= 50 && student4 <= 60){
        cout<<"grade d"<<endl; 
      }else if(student4 >= 40 && student4 <= 50){
        cout<<"grade e"<<endl; 
      }else if(student4 < 40){
        cout<<"fail"<<endl; 
      }
    }else if(studentNumber == 5){
      if(student5 > 80){
        cout<<"grade A"<<endl; 
      }else if(student5 >= 70 && student5 <= 80){
        cout<<"grade b"<<endl; 
      }else if(student5 >= 60 && student5 <= 70){
        cout<<"grade c"<<endl; 
      }else if(student5 >= 50 && student5 <= 60){
        cout<<"grade d"<<endl; 
      }else if(student5 >= 40 && student5 <= 50){
        cout<<"grade e"<<endl; 
      }else if(student5 < 40){
        cout<<"fail"<<endl; 
      }
    }else{
      cout<<"Invalid format"<<endl; 
    }

    
    cout<<"Press 1. Add Student Marks"<<endl; 
    cout<<"Press 2. Display All Marks"<<endl; 
    cout<<"Press 3. Calculate Average Marks"<<endl; 
    cout<<"Press 4. Find Grade of a Student"<<endl; 
    cout<<"Press 5. Exit"<<endl; 
    cout<<"Enter the choice : "; 
    cin>>choice; 
    

    case 5:
    cout<<"Exiting program. Thank you!"; 
    break; 
 

  }



  return 0; 

}