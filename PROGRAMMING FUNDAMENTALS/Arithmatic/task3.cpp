#include<bits/stdc++.h>
using namespace std;

int main (){
  //check whether character is alphabet or not
  char ch; 
  cout<<"Enter the Character : "; 
  cin>>ch; 
  
  if(ch >= 97 && ch <= 122 || ch >=65 && ch<= 90){
    cout<<"it is character"; 
  }else{
    cout<<"It is number";
  }

  return 0;
}