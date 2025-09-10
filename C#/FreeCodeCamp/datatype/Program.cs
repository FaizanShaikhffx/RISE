// int[] data = new int[3];

// int[] A= new int[1];
// A[0] = 2;

// int[] B = A;
// B[0] = 5;

// Console.WriteLine("--Reference Types--");
// Console.WriteLine($"A[0]: {A[0]}");
// Console.WriteLine($"B[0]: {B[0]}");

// int[] array1 = new int[1];
// array1[0] = 50;
// int[] array2 = array1;
// array2[0] = 100;

// Console.WriteLine("array 1 : " + array1[0]);
// Console.WriteLine("array 2 : " + array2[0]);

// int first = 2;
// string second = "4";
// string result = first + second;
// Console.WriteLine(result);

// int myInt = 3;
// Console.WriteLine($"int: {myInt}");

// decimal myDecimal = myInt;
// Console.WriteLine($"decimal: {myDecimal}");

// int myInt = 3;
// Console.WriteLine($"int: {myInt}");

// decimal myDecimal = myInt;
// Console.WriteLine($"decimal: {myDecimal}");

// int first = 5;
// int second = 7;
// string message = first.ToString() + second.ToString();
// Console.WriteLine(message);


// string first = "5";
// string second = "7";
// int sum = int.Parse(first) + int.Parse(second);
// Console.WriteLine(sum);

// string value1 = "5";
// string value2 = "7";
// int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
// Console.WriteLine(result);

// string name = "Bob";
// Console.WriteLine(int.Parse(name));

// string value = "102";
// int result = 0;
// if (int.TryParse(value, out result))
// {
//    Console.WriteLine($"Measurement: {result}");
// }
// else
// {
//    Console.WriteLine("Unable to report the measurement.");
// }
// Console.WriteLine($"Measurement (w/ offset): {50 + result}");

// string value = "bad";
// int result = 0;
// if (int.TryParse(value, out result))
// {
//    Console.WriteLine($"Measurement: {result}");
// }
// else
// {
//    Console.WriteLine("Unable to report the measurement.");
// }

// if (result > 0)
//    Console.WriteLine($"Measurement (w/ offset): {50 + result}");

// string[] values = { "12.3", "45", "ABC", "11", "DEF" };

// decimal total = 0m;
// string message = "";

// foreach (var value in values)
// {
//   decimal number;
//   if (decimal.TryParse(value, out number))
//   {
//     total = total + number; 
//   }
//   else
//   {
//     message += value;
//   }
// }

// Console.WriteLine($"Message: {message}");
// Console.WriteLine($"Total: {total}");

// int value1 = 11;
// decimal value2 = 6.2m;
// float value3 = 4.3f;

// // Your code here to set result1
// // Hint: You need to round the result to nearest integer (don't just truncate)
// int result1 = value1 / (int)value2;
// Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

// // Your code here to set result2
// decimal result2 = (decimal)value2 / (decimal)value3;
// Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

// // Your code here to set result3
// float result3 = value3 / (float)value1;
// Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");

