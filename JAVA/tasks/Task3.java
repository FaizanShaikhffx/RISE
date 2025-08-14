class Course{
  void enroll(){
      System.out.println("Available Courses are CSE, IT, EE, EC"); 
  }

  void courseDetails(){
    System.out.println("Course duration 4 year, there are good faculties for each course, there is good placements");
  }
}

class ProgrammingCourse extends Course{
  void enroll(String courseName, int discount){
    System.out.println("Course name : " + courseName + "Discount : "+discount);
  }
  void courseDetails(String courseName){
    System.out.println("I enrolled in :" + courseName);
    
  }
}

class DesigningCourse extends Course{
  void enroll(String courseName, int discount){
    System.out.println("Course name : " + courseName + "and I got Discount of : "+discount+" %");
  }
 void courseDetails(String courseName){
    System.out.println("I enrolled in :" + courseName);
    
  }
}


public class task3{
  public static void main(String args[]){
    DesigningCourse d1 = new DesigningCourse();
    d1.enroll("Interior design", 10); 
  }
}
