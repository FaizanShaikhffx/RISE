using System;

class Program
{
  enum Days : byte{
    Monday,
    Tuesday,
    Thursday,
    Wednesday,
    Friday,
    Saturday,
    Sunday = 235
  }

  static void Main(string[] args)
  {


    Days d1 = Days.Sunday;

    foreach (var value in Enum.GetValues(typeof(Days)))
    {
      Console.WriteLine(value); 
    }
  }
}