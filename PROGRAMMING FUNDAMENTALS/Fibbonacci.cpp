#include<bits/stdc++.h>
using namespace std;

int main (){;
  int a = 0; 
  int b = 1; 
  cout<<a<<" "; 
  cout<<b<<" "; 

  for(int i = 2; i<10; i++){
    int next = a+b;
    a = b;
    b =next; 
    cout<<next<< " ";
  }
  return 0;
}