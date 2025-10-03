// using System;

// class Program
// {

//   // public static string Add(string s1, string s2)
//   //   {
//   //     return s1 + " " + s2;
//   //   }


//   // public static void Main()
//   // {
//   //   Console.WriteLine("Hi there");
//   //   string fullName = Add("Faizan", "Shaikh");
//   //   Console.WriteLine(fullName);

//   // }

//   public static int Add(int a, int b, int c = 0, int d = 0) {
//     return a + b + c + d; 
//   }

//   public static int Add(params int[] arr) //params should always be last
//   {
//     int sum = 0;
//     foreach (int i in arr)
//     {
//       sum = sum + i; 
//     }
//     return sum;
//   }

//   public static void Main()
//   {
//     int n1 = 10;
//     int n2 = 20;
//     int res = Add(n1, n2);
//     res = Add(b: n1, a: n2, d: 25);
//     Console.WriteLine(res);

//     int[] myArr = { 1, 2, 3, 4, 5 };
//     Console.WriteLine(Add(myArr));


//     Console.WriteLine(Add(1, 2, 3, 4));
//     Console.WriteLine(Add(new int[] { 1, 2, 3, 4 }));
//   }
  


// }