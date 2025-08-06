#include<bits/stdc++.h>
using namespace std;

int main (){;
  char choice; 
  int a; 
  int b; 
  cout<<"Enter the value of a : "; 
  cin>>a; 
  cout<<"Enter the value of b : "; 
  cin>>b; 

  cout<<"Enter your choice : "; 
  cin>>choice; 
  

  switch(choice){
    case '+': 
    cout<<"The sum of a and b is : "<<a+b; 
    break; 
    case '-': 
    cout<<"The diff of a and b is : "<<a-b; 
    break; 
    case '*': 
    cout<<"The multiplication of a and b is : "<<a*b; 
    break; 
    case '/': 
    cout<<"The division of a and b is : "<<a/b; 
    break; 
    
    default:
    cout<<"Invalid operator"; 
    break; 

  }
  return 0;
}