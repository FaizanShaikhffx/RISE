#include<bits/stdc++.h>
using namespace std;

int main (){;
  cout<<"Welcome to the ATM System"<<endl;
  cout<<"For balance enter 1, for widraw enter 2, for deposite enter 3, for exit enter 4 "<<endl;

  
  int balance = 1000; 
  int widrawMoney; 
  int depositeMoney; 
  int Exit; 
  int choice; 

  cout<<"Enter the choice : "; 
  cin>>choice; 

  switch(choice){

    case 1: 
    cout<<"Your Balance is : "<<balance; 
    break; 

    case 2: 
    cout<<"Widraw amount : "; 
    cin>>widrawMoney;
    if(widrawMoney<=balance){
      balance = balance - widrawMoney; 
      cout<<"You successfully widraw "<<widrawMoney<<endl; 
      cout<<"Your current balance is : "<<balance<<endl;
    }
    break; 

    case 3: 
    cout<<"deposite amount : "; 
    cin>>depositeMoney;
    if(depositeMoney > 0 ){
      balance = balance + depositeMoney; 
      cout<<"You successfully deposite "<<depositeMoney<<endl;
      cout<<"Your current balance is : "<<balance<<endl; 
    }
    break; 

    case 4: 
    cout<<"exit"; 
    break; 


  }
  
  return 0;
}