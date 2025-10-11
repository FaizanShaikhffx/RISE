using System;

class Program
{
   private int[] items = new int[5];

  //   public int this[int index]
  // {
  //   get
  //   {
  //     if (index < 0 || index >= items.Length)
  //     {
  //       throw new IndexOutOfRangeException();
  //     } 
  //     return items[index]; 
  //   }
  //   set
  //   {
  //     if (index < 0 || index >= items.Length)
  //     {
  //       throw new IndexOutOfRangeException(); 
  //     }
  //     items[index] = value; 
  //   } 
  //   }

  public int this[int i] => items[i];


  public static void Main(string[] args)
  {
    Program p1 = new Program();
    Console.Write(p1[0]); 
    // p1[0] = 40;
    // p1[1] = 41;
    // p1[2] = 42;
    // p1[3] = 43;



  } 
  
}