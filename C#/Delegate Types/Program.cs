using System;


class Program
{
  public static double AddNums1(int x, float y, double z)
  {
    return x + y + z;
  }
  public static void AddNums2(int x, float y, double z)
  {
    Console.WriteLine(x + y + z);
  }
  public static bool CheckLength(string str)
  {
    if (str.Length > 5)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public static void Main(string[] args)
  {
    Func<int, float, double, double> obj1 = obj1 = AddNums1;
    double result = obj1(100, 34.5f, 193.465d);
    Console.WriteLine(result);


    Action<int, float, double> obj2 = AddNums2;
    obj2.Invoke(100, 34.5f, 193.465d);

    Predicate<string> obj3 = CheckLength;
    bool isLengthIsFive = obj3.Invoke("Faiz");
    Console.WriteLine(isLengthIsFive); 

  }
}