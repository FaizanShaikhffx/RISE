using System;
using System.Net.Security;

class Student
{

  private string name;

  private int age; 
  public string Name
  {
    get
    {
      return name;
    }
    set
    {
      name = value;
    }
  }
  public int Age
  {
    get {
      return age; 
    }
    set
    {
      age = value; 
    }
  }
  public static void Main(string[] args)
  {
    Student s1 = new Student();
    s1.Name = "Faizan";
    s1.Age = 23;

    Console.WriteLine(s1.Name + " " + s1.age);

  }
}