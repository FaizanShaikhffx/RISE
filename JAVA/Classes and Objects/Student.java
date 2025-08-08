class Student {

  int rollNumber; 
  String name; 
  String course; 

  Student(int studentRollno, String studentName, String StudentCourse){
    rollNumber = studentRollno;
    name = studentName;
    course = StudentCourse;
  }

  void getInfo(){
    System.out.println(rollNumber+" "+ name + " "+ course);
  }

  public static void main(String args[]){
    Student s1 = new Student(1, "Pablo", "CS"); 
    s1.getInfo(); 
  }
}