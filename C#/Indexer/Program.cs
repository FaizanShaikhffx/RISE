using System;

class Parent
{
  private string[] items = new string[3];

  public virtual string this[int index]
  {
    get {
      Console.WriteLine("Parent");
      return items[index]; }
    set
    {
      items[index] = value;
    }
  }

}

class Child : Parent
{ 
  public override string this[int index]
  {
    get {
       return "Dericed : " + base[index];
    }
    set
    {
      base[index] = value;
    }
  }

}

class Program
{

  static void Main(string[] args)
  {
    Parent p1 = new Parent();
    // Parent p1 = new Child();
    p1[0] = "Faizan";
    Console.WriteLine(p1[0]);
  }

}