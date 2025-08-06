class Employee {  // main ke bahar class banayi
  int id;
  String name;
  int salary;

  Employee(int empID, String empName, int empSalary) {
    id = empID;
    name = empName;
    salary = empSalary;
  }

  void getInfo() {
    System.out.println(id + " " + name + " " + salary);
  }
}

public class MainClass {  // yeh main wali class hai
  public static void main(String args[]) {

    // main ke andar Employee class ka object banaya
    Employee em = new Employee(1, "Faizan", 6000);
    em.getInfo();
  }
}
