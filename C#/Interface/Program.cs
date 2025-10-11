using System;

interface ICar
{
  public void showCar();



}

class Program : ICar
{

  public void showCar()
  {
    Console.WriteLine("I am from Interface");
  }
  public static void Main(string[] args)
  {
    
    Program c1 = new Program();

    c1.showCar(); 

  }
}