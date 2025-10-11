using System;

class Program
{
  public void AddNums(int a, int b)
  {
    Console.WriteLine(a + b); 
  }

  public delegate void AddDelegate(int a, int b);

  public static string sayHello(string name)
  {
    return "Hello " + name;
  }
  public static void Main(string[] args)
  {
    Program p1 = new Program();
    AddDelegate ad = new AddDelegate(p1.AddNums);
    ad(10, 20);   

    string str = sayHello("Faizan");
    Console.WriteLine(str);  
  }
  
 }