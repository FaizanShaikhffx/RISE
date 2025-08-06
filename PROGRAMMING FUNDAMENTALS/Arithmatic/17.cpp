// Electricity bill calculater

/*write a program to calculate  electricity bill
100<=  to charge 5 rupees per unit
101-200 charge 7 rupees per unit 
if 200> units then 10 rs per unit
add 50 rs fixed charge if unit greater than 150;*/

// #include<bits/stdc++.h>
// using namespace std;

// int main (){;

  
//   int unit; 
//   cout<<"enter unit amount : "; 
//   cin>>unit; 
//   int fixed_charge = 50; 


//   if(unit <= 100 && unit > 0){
//     int bill = unit * 5; 
//     cout<<"Your bill is : "<<bill; 
//   }
//   else if(unit > 100 && unit <= 150){
//     int temp = unit - 100; 
//     int extra_bill = (temp * 7);  
//     int bill = (100 * 5) + extra_bill; 
//     cout<<"Your bill is : "<<bill;
//   }else if(unit > 150 && unit <= 200){
//     int temp = unit - 100;  
//     int extra_bill = (temp * 7);  
//     int bill = (100 * 5) + extra_bill + fixed_charge; 
//     cout<<"Your bill is : "<<bill;
//   }else{
//     int temp1 = unit - 200; 
//     int bill = (100 * 5) + (100 * 7) + (temp1 * 10) + fixed_charge; 
//     cout<<"Your bill is : "<<bill;
//   }

//   // unit = 150   temp = 50   extra-bill = 350   bill = 150 * 5       
  

//   return 0;
// }






// generate a random number between 1-100 let user get it use loop to give multiple attempts;
// after each guess print too high too low or correct. 

#include<bits/stdc++.h>
using namespace std;

int main (){;
  int num = rand();
  cout<<num<<endl;
  int n; 
  for(int i = 0; i<=100; i++){
    cout<<"enter number : "; 
    cin>>n; 
    if(n == num){
      cout<<"This is your guessed number : "<<num;
      break;
    }else if(n > num){
      cout<<"to high enter another : ";
      cin>>n;
    }else if(n < num){
      cout<<"to low enter another : ";
      cin>>n; 
    }else {
      cout<<"invalid number!";
    }
  }
  return 0;
}







// create a program that allows a user to enter username and password (harcore) give 3 attempts after that block the access.

// #include<bits/stdc++.h>
// using namespace std;

// int main (){;
//   int attempt = 0; 
//   string username = "admin";
//   string password = "admin123";
  
//   for(int i = 0; i<3; i++){
   
//     string user; 
//     cout<<"Enter username : "; 
//     cin>>user; 
//     string pass; 
//     cout<<"Enter password : "; 
//     cin>>pass; 
//     if(user == username && pass == password){
//       cout<<"You Logged in successfully"<<endl;
//       break; 
//     }else {
//       attempt ++; 
//     }
//      if(attempt == 3){
//       cout<<"too many attempts access Blocked!";
//     }
//   }
//   return 0;
// }


// take a number as a input if its postive than check if even and odd. 
// if its negative print negative number
// if 0 then print 0

// #include<bits/stdc++.h>
// using namespace std;

// int main (){;
//   int n; 
//   cout<<"Enter the value of n : "; 
//   cin>>n; 
//   if(n < 0){
//     cout<<"negative number";   
//   }else if(n == 0){
//     cout<<0;
//   }else if(n > 0){
//     if(n%2 == 0){
//       cout<<"The number you entered is even"; 
//     }else{
//       cout<<"The number you entered is odd"; 
//     }
//   }
//   return 0;
// }



// take a number as a input and print multiplication table of that number.
 
// #include<bits/stdc++.h>
// using namespace std;

// int main (){;
  
//   return 0;
// }


//maximum of 2 number using function

// #include<bits/stdc++.h>
// using namespace std;

// int maxOfNumberO(int a, int b, int c){
//   if(a > b && a > c){
//     return a; 
//   }else if(b > c){
//     return b; 
//   }else {
//     return c; 
//   }
// }

// int main (){;
  
//   int a, b, c; 
//   cout<<"Enter the first number : "; 
//   cin>>a; 
//   cout<<"Enter the second number : "; 
//   cin>>b; 
//   cout<<"Enter the third number : "; 
//   cin>>c; 


//   cout<<maxOfNumberO(a, b, c); 
//   return 0;
// }



