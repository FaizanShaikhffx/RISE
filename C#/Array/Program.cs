// int[] arr = new int[10];
// arr = new int[10];
// arr = new int[] { 1, 2, 3, 4, 5, 6 };

// arr = new int[] { }; //Empty Array
// arr = new int[] { 1, 2, 3, 4, 5 };

// bool[] b1 = new bool[] { }; //Empty Array
// bool[] b2 = new bool[5] { true, true, true, true, true }; //Empty Array

// object ob = new object[5] { 1, true, 'A', 10d, false };


Console.Write("Enter the NUmber Of Element : ");
int n = int.Parse(Console.ReadLine());
int[] arr = new int[n];
for (int i = 0; i < arr.Length; i++) {
  Console.Write("Enter a Number : ");
  arr[i] = int.Parse(Console.ReadLine());  
}
int sum = 0;
for (int i = 0; i < arr.Length; i++)
{
  sum = sum + arr[i];
  // Console.Write(arr[i] + " ");
}
Console.WriteLine("Sum is : " + sum); 
Console.WriteLine("Average is : " +(1.0 * sum / n));

for (int i = arr.Length - 1; i >= 0; i--)
{
  Console.WriteLine(arr[i] + " "); 
}