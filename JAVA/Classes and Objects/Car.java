class Car{

  String brand;
  String model; 
  int year; 
  
  Car(String carBrand, String carModel, int carYear){
    brand = carBrand;
    model = carModel;
    year = carYear;
  }

  void getInfo(){
    System.out.println(brand+" "+model+" "+year);
  }

  public static void main(String args[]){
    Car cf = new Car("Mecedez", "Mensory", 2024);
    cf.getInfo();

  }
}