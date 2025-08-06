#include<bits/stdc++.h>
using namespace std;

int main (){;
  
  // for(int i = 0; i<=4; i++){
  //   for(int j = 0; j<=4; j++){
  //     cout<<"*";
  //   }
  //   cout<<endl;
  // }

  // for(int i = 0; i<=5; i++){
  //   for(int j = i; j<=5; j++){
  //     cout<<"*";
  //   }
  //   cout<<endl;
  // }

  int x = 0, y = 0; 
  // x = (++y) + (y--);

  x = ++y + --y + ++y;  
  cout<<x<<endl;
  cout<<y<<endl;


  return 0;
}