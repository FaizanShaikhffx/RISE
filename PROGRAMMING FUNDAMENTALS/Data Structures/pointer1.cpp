#include<bits/stdc++.h>
using namespace std;

int main (){;
  
  // int *p = 0; 
  // cout<<*p<<endl;  segmentation fault

  // int i = 5;  
  // int *q = &i; 

  // cout<<q<<endl; 
  // cout<<*q<<endl; 

  // int *p = 0; 
  // p = &i; 

  // cout<<p<<endl; 
  // cout<<*p<<endl; 

  int num = 5; 
  int a = num; 
  a++; 

  int *p = &num; 
  cout<<"Before "<<num<<endl;
  (*p)++; 
  cout<<"After "<<num<<endl;

  int *q = p; 
  cout<<p<<" - "<<q << endl;
  cout<< *p << " - " << *q<<endl;  

  return 0;
}