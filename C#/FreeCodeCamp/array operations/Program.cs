// string[] pallets = [ "B14", "A11", "B12", "A13" ];

// Console.WriteLine("Sorted...");
// Array.Sort(pallets);
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }

// string[] pallets = [ "B14", "A11", "B12", "A13" ];

// Console.WriteLine("Sorted...");
// Array.Sort(pallets);
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }

// Console.WriteLine("");
// Console.WriteLine("Reversed...");
// Array.Reverse(pallets);
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }

// string[] pallets = [ "B14", "A11", "B12", "A13" ];
// Console.WriteLine("");

// Console.WriteLine($"Before: {pallets[0]}");
// Array.Clear(pallets, 0, 2);
// Console.WriteLine($"After: {pallets[0]}");

// Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }

// string value = "abc123";
// char[] valueArray = value.ToCharArray();

// foreach(char item in valueArray) { 
// Console.WriteLine(item);
// }


// string value = "abc123";
// char[] valueArray = value.ToCharArray();
// Array.Reverse(valueArray); //321cba
// string result = String.Join(", ", valueArray); //abc123
// Console.WriteLine(result);

// string[] items = result.Split(',');
// foreach (string item in items)
// {
//     Console.WriteLine(item);
// }

// string pangram = "The quick brown fox jumps over the lazy dog";
// string[] result = pangram.Split(" ");


// foreach (string item in result)
// {
//     Console.WriteLine(item);
// }



// ehT kciuq nworb xof spmuj revo eht yzal god


// string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
// string[] splitItems = orderStream.Split(",");

// Array.Sort(splitItems);
// foreach (string item in splitItems)
// {
//     char[] newChar = item.ToCharArray();
//     if (item.Length < 4 || item.Length > 4)
//     {
//         Console.WriteLine(item + "      -Error");
//     }
//     else
//     { 
//         Console.WriteLine(item);
//     }
// }
// char[] itemsArray = orderStream.ToCharArray();
// Array.Sort(itemsArray);

// Console.WriteLine(itemsArray);



// A345
// B123
// B177
// B179
// C15     - Error
// C234
// C235
// G3003   - Error

// string first = "Hello";
// string second = "World";
// // string result = string.Format();
// Console.WriteLine("{0} {1}!", first, second);

// string first = "Hello";
// string second = "World";
// Console.WriteLine("{1} {0}!", first, second);
// Console.WriteLine("{0} {0} {0}!", first, second);

// string first = "Hello";
// string second = "World";
// Console.WriteLine($"{first} {second}!");
// Console.WriteLine($"{second} {first}!");
// Console.WriteLine($"{first} {first} {first}!");

// decimal price = 123.45m;
// int discount = 50;
// Console.WriteLine($"Price: {price:C} (Save {discount:C})");

// decimal measurement = 123456.78912m;
// Console.WriteLine($"Measurement: {measurement:N} units");

// decimal tax = .36785m;
// Console.WriteLine($"Tax rate: {tax:P3}");

// int invoiceNumber = 1201;
// decimal productShares = 25.4568m;
// decimal subtotal = 2750.00m;
// decimal taxPercentage = .15825m;
// decimal total = 3185.19m;

// Console.WriteLine($"Invoice Number: {invoiceNumber}");


// Console.WriteLine($"   Shares: {productShares:N3} Product");

// Console.WriteLine($"     Sub Total: {subtotal:C}");

// Console.WriteLine($"           Tax: {taxPercentage:P2}");

// Console.WriteLine($"     Total Billed: {total:C}");

// string input = "Pad this";
// Console.WriteLine(input.PadLeft(12));
// Console.WriteLine(input.PadLeft(12, '-'));
// Console.WriteLine(input.PadRight(12, '-'));


// string paymentId = "769C";
//  string payeeName = "Mr. Stephen Ortega";
//  string paymentAmount = "$5,000.00";

//  var formattedLine = paymentId.PadRight(6);
//  formattedLine += payeeName.PadRight(24);
//  formattedLine += paymentAmount.PadLeft(10);

//  Console.WriteLine("1234567890123456789012345678901234567890");
//  Console.WriteLine(formattedLine);


// string myWords = "Learning C#";
// Console.WriteLine(myWords.PadLeft(11));
// Console.WriteLine(myWords.PadLeft(12));
// Console.WriteLine(myWords.PadLeft(13));
// Console.WriteLine(myWords.PadLeft(14));

int a = 10;
Console.WriteLine(a);

for (int i = 1; i < 1000000; i++)
{ 
Console.WriteLine(i+" ");
    
}

