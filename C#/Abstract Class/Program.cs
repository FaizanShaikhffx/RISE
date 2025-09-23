using System;

abstract class A
{
  public abstract void greet(); 
}
class B : A
{
  public override void greet()
  {
    Console.WriteLine("Good Morning From B");
  }
}
class Program
{
  static void Main(string[] args)
  {
    A a = new B();
    a.greet(); 
  }

}