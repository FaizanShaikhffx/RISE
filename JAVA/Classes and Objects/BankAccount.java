class BankAccount {

  String accountHolder; 
  int accountNumber; 
  double balance; 

  BankAccount( String bankAccountHolder, int bankAccountNumber, double bankBalance){
    accountHolder = bankAccountHolder; 
    accountNumber = bankAccountNumber; 
    balance = bankBalance; 
  }

  void deposite(double amount){
    if(amount > 0){
      System.out.println("You Successfully deposited : "+amount); 
      balance = balance + amount; 
      System.out.println("Your Current balance is : "+balance); 
    }else{
      System.out.println("Invalid Ammount"); 
    }
  }

  void withdraw(double amount){
    if(amount > balance){
      System.out.println("Insufficiant Balance"); 
    }else{
      System.out.println("You successfully widrawed :"+amount); 
      balance = balance - amount; 
      System.out.println("Your current balance is :"+balance); 
    }
  }

  void display(){
    System.out.println(accountHolder+" "+ accountNumber + " "+ balance); 
  }

  public static void main(String args[]){
    BankAccount b1 = new BankAccount("Faizan", 10002000, 5000);
    b1.display(); 
    b1.withdraw(2000); 
  }
}