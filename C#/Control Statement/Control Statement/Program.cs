// int n1, n2;
// n1 = n2 = 10;

// if (n1 > n2)
// {
//   Console.WriteLine("N1 is Greater");
// }
// else
// { 
//   Console.WriteLine("N2 is Greater")
// }

// int n1;
// n1 = int.Parse(args[0]);
// if (n1 % 2 == 0)
// {
//   Console.WriteLine("Is Even");
// }
// else
// { 
//   Console.WriteLine("Is Odd");
// }

// int n;
// Console.WriteLine("Enter Rating (1-10): ");
// n = int.Parse(Console.ReadLine());

// switch (n)
// {
//   case 1:
//   case 2:
//   case 3:
//     Console.WriteLine("Poor");
//     break;
//   case 4:
//   case 5:
//   case 6:
//     Console.WriteLine("Average");
//     break;
//   case 7:
//   case 8:
//     System.Console.WriteLine("Good");
//     break;
//   case 9:
//   case 10:
//     System.Console.WriteLine("Excellent");
//     break;
//   default:
//     System.Console.WriteLine("Invalid Grade");
//     break;
// }

using System.Numerics;

int n;
System.Console.WriteLine("Table Of : ");
n = int.Parse(Console.ReadLine());
string s = "";
for (int i = 1; i <= 10; i++)
{ 
  s = s + n+" x "+i+" = "+(n*i)+"\n"; 
  System.Console.WriteLine(s);
}

