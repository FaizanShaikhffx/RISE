class Vehicle{
  void rentVehicle(int days){
    System.out.println("Vehicle is renting for "+days+" days");
  }
  void displayDetails(){
    System.out.println("Vehicle is moving");
  }
}

class Car extends Vehicle{
  void rentVehicle(int days, boolean driver){
    System.out.println("Car is renting for "+days+" days with driver");
  }
  void rentVehicle(int days){
    System.out.println("Car is renting for "+days+" days");
  }

   void displayDetails(){
    System.out.println("Car is moving");
  }

}

class Bike extends Vehicle{
  void rentVehicle(int days){
    System.out.println("Bike is renting for "+days+" days");
  }
  void displayDetails(){
    System.out.println("Bike is moving");  
  }
}



public class Task1 {
    public static void main(String[] args) {
        Bike b1 = new Bike();
        b1.rentVehicle(5); 
        b1.displayDetails(); 

        Car c1 = new Car(); 
        c1.rentVehicle(5, true); 
        c1.rentVehicle(6); 
    }
}
