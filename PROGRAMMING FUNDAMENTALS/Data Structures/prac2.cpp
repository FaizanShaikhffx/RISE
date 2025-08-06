#include<bits/stdc++.h>
using namespace std; 

int main(){

  int a; 
  cout<<"Enter the value of a : "; 
  cin>>a; 
  int b; 
  cout<<"Enter the value of b : "; 
  cin>>b; 
  int c; 
  cout<<"Enter the value of c : "; 
  cin>>c; 
  

  if(a > b && a > c){
    cout<<"a height is heigher than b and c";

  }if(b > c && b > a){
    cout<<"b height is heigher than a and c";
  }if(c > a && c > b){
    cout<<"c height is heigher than a and b ";
  }

  return 0; ;
}