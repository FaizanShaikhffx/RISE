
class Employee{

  int id; 
  String name; 
  int salary; 

  Employee(int empID, String empName, int empSalary){
    id = empID; 
    name = empName; 
    salary = empSalary; 
  }

  void getInfo(){
      System.out.println(id + " " + name + " "+ salary); 
  }

  public static void main(String args[]){

    Employee em = new Employee(1, "Faizan", 6000); 
    em.getInfo(); 
  }
}