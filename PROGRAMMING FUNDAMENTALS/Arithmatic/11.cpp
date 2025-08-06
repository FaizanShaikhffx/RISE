#include<bits/stdc++.h>
using namespace std;

int main (){;
  // int x = 5; 
  // bool voterId = true;  //matlab uske pass voter Id hai!

  // if(x >= 18){
  //   if(voterId == false){
  //     cout<<"You can vote";
  //   }else{
  //     cout<<"You can not vote";
  //   }
  // }else{
  //   cout<<"Bhai teri age kam hai!";
  // }


  // +-*/ 
  
  char choice; 
  int a, b; 

  cout<<"Enter choice : ";
  cin>>choice; 
  cout<<"Enter the value of a : ";
  cin>>a; 
  cout<<"Enter the value of b : ";
  cin>>b; 

  switch(choice){
    case '+' :
    cout<<a+b<<endl; 
    break; 
    case '-' :
    cout<<a-b<<endl; 
    break; 
    case '*' :
    cout<<a*b<<endl; 
    break; 
    case '/' :
    cout<<a/b<<endl; 
    break; 

    default: 
      cout<<"Invalid"; 
    
  }



  return 0;
}