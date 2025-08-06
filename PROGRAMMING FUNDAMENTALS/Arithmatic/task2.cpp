#include<bits/stdc++.h>
using namespace std;

int main (){;
  
  int loanAmount; 
  cout<<"Enter loan amount : "; 
  cin>>loanAmount; 
  
  int emi = loanAmount / 10; 

  int interest = (loanAmount * 3) / 100; 
  int principle = emi + interest; 
  int balance = loanAmount - emi; 

  if(balance > 0){
    if(interest >= 0){
      balance = loanAmount - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl; 
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }
    if(interest >= 0){
      balance = balance - emi; 
      interest = (balance * 3 ) / 100; 
      cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    }

  }

  


        

  
  return 0;
}