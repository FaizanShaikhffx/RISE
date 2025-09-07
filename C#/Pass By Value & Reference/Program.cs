using System;

class Program
{
  public static void Main()
  {
    int a, b, c, d;
    a = b = c = d = 10;
    Foo(a, out b, ref c, in d);
    Console.WriteLine($"{a} {b} {c} {d}");

  }

  static void Foo(int n1, out int n2, ref int n3, in int n4)
  {
    n2 = 10; 
  }
  
}