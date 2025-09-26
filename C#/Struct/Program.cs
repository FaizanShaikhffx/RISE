using System;



struct myStruct
{
  public int x;
  public int y;

  public myStruct(int x)
  {
    this.x = x; 
  }

}



  class Program
  {
  static void Main(string[] args)
  {
    myStruct m1 = new myStruct(5, 6);
    Console.Write(m1.x); 
    Console.Write(m1.y); 
  }
  }