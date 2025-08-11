
class Animal {
  int Sound(int a , int b){
    System.out.println("Me Animal kaa parent hu");
    System.out.println(a+b);
    return 1; 
  }
}

class Cat extends Animal {
  void Sound(){
    System.out.println("Me Cat hu");
  }
}

class Dog extends Animal {
  int Sound(int a, int b){
    System.out.println("Me Dog hu");
    System.out.println(a*b);
    return 1; 
  }
}


public class Inheritance2 {

  public static void main(String args[]){

    Dog d1 = new Dog(); 
    d1.Sound(5, 5); 

  }
}