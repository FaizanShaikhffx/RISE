#include<bits/stdc++.h>
using namespace std; 

int swapElement(int *a, int *b){
  int temp = *a; 
  *a = *b; 
  *b = temp; 
}

int main(){
  int a = 5; 
  int b = 10; 
  swapElement(&a, &b);
  cout<<"a : "<<a<<endl;
  cout<<"b : "<<b<<endl;
  return 0; 
}