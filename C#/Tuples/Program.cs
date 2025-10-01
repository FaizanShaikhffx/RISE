using System;

class Program
{

  public static (int sum, int product) Calculate(int a, int b)
  {
    return ((a + b), (a * b));
  }

  public static void Main(string[] args)
  {
    //Old-Syntax
    // Tuple<int, string> student = new Tuple<int, string>(1, "Faizan");
    // Console.WriteLine(student.Item1);

    // var name = Tuple.Create(1, "Faizan");
    // Console.Write(name.Item1);

    // var student = (id: 1, name: "Faizan");
    // Console.Write(student.id); 


    // var d = Calculate(10, 20);
    // Console.Write(d);

    var (name, age, rollNumber) = ("Faizan", 23, 1);
    Console.Write(name); 



  }


}