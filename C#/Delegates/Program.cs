using System;

public delegate void MyDelegate(string name); 


public class ClassA
{
    public static void MethodA(string message)
    {
        Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
    }
}

public class ClassB
{
    public static void MethodB(string message)
    {
        Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
    }
}
class Program
{
  static void InvokeDelegate(MyDelegate del) // MyDelegate type parameter
  {
      del("Hello World");
  }

  static void Main(string[] args)
  {
    MyDelegate del = ClassA.MethodA;
        InvokeDelegate(del);

        del = ClassB.MethodB;
        InvokeDelegate(del);

        del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
        InvokeDelegate(del);
  }
}