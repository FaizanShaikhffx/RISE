int n1, n2;

n1 = 10;
n2 = 20;
int max;


// if (n1 > n2)
// {
//   max = n1;
// }
// else
// {
//   max = n2;
// }

// max = (n1 > n2) ? n1 : n2; 

// Console.WriteLine(max);
DayOfWeek dayOfWeek = DayOfWeek.Sat;
dayOfWeek = DayOfWeek.Fri;
int n = (int) dayOfWeek;
Console.WriteLine(dayOfWeek);
Console.WriteLine(n);

enum DayOfWeek
{
  Sun, Mon, Tue, Wed, Thur, Fri, Sat
}



