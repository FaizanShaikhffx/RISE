using System;

class Program
{



  public static void Main()
  {
    Console.WriteLine("Hi there");
    string fullName = Add("Faizan", "Shaikh");
    Console.WriteLine(fullName);
    
  }
  public static string Add(string s1, string s2)
  {
    return s1 + " " + s2;
  }


}