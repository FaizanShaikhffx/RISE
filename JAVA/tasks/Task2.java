
class Customer{
  
  void applyDiscount(int purchasedAmount){
    System.out.println("Your purchased ammount is : "+purchasedAmount); 
  }

  void getLoyaltyPoints(int points){
    System.out.println("You Got "+points+" points"); 
  }

}

class RegularCustomer extends Customer{
  void applyDiscount(int purchasedAmount, double coupon){
    System.out.println("Applied discount successfully and you payable amount is : "+purchasedAmount * coupon); 

  }
  void getLoyaltyPoints(int points){
    System.out.println("You Got "+points+" points"); 
  }
}


class PremiumCustomer extends Customer{
  void applyDiscount(int purchasedAmount, double coupon){
    System.out.println("Applied discount successfully and you payable amount is : "+ (purchasedAmount * (coupon * 2))); 

  }

  void getLoyaltyPoints(int points){
    System.out.println("You Got "+(points * 2 )+" points"); 
    
  }
}

public class Task2{


  public static void main(String args[]){
    PremiumCustomer p1 = new PremiumCustomer(); 
    p1.applyDiscount(5000, 0.10); 
  }
}