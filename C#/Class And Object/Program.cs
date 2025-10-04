using System;

class Program
{

  public string name; 
  public Program(string name)
  {
    Console.WriteLine(name + " Shaikh"); 
  }

  public static void Main(string[] args)
  {
    Program p1 = new Program("Faizan");

  }
}