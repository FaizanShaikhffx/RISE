
public class Product{
  
  String productName; 
  int price; 
  int quantity; 

  Product(String pname, int productPrice, int productQuantity){
    productName = pname; 
    price = productPrice;
    quantity = productQuantity; 
  }

    void totalPrice(){
      System.out.println(price * quantity); 
  }

  
  public static void main(String args[]){
      Product p1 = new Product("laptop", 45000, 10);
      p1.totalPrice(); 
  }
}