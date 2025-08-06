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
    balance = loanAmount - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl; 
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 
    
    cout<<"Emi amount : "<<emi<< " Interest : "<<interest<<" Balance : "<<balance<<endl;
    interest = (balance * 3 ) / 100; 
    balance = balance - emi; 



  }

  

  //check whether character is alphabet or not

        

  
  return 0;
}