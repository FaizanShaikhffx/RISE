using System;

interface ICar
{
  public void showCar();

  public void getCar(string name)
  {
    Console.WriteLine(name+ " from interface"); 
  }


}

class Program : ICar
{

 
  public void showCar()
  {
    Console.WriteLine("I am from Interface");
  }
  public static void Main(string[] args)
  {
    
    ICar c1 = new Program();

    c1.getCar("Mercedez"); 

  }
}