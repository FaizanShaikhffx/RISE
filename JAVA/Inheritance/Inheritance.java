
class A{
  A(){
    System.out.println("Me A constructor "); 

  }

  A(int a, int b){
    System.out.println("Me A constructor "+(a+b)); 
  
}
  void featureA(){
    System.out.println("Me A hu"); 
  }
}
class B extends A{
  B(){
    new A(10, 20);
    System.out.println("Me B constructor  "); 
  
}
  void featureB(){
    System.out.println("Me B hu"); 
  }
}
class C extends B{
C(){
    System.out.println("Me C constructor  "); 
  
}

  void featureC(){
    System.out.println("Me C hu"); 
  }
}

class Inheritance{
  public static void main(String args[]){
   C c1 = new C(); 
   c1.featureC(); 
  }
}