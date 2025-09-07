// Console.WriteLine("a" == "a");
// Console.WriteLine("a" == "A");
// Console.WriteLine(1 == 2);

// string myValue = "a";
// Console.WriteLine(myValue == "a");

// string value1 = " a";
// string value2 = "A ";
// Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());


// Console.WriteLine("a" != "a");
// Console.WriteLine("a" != "A");
// Console.WriteLine(1 != 2);

// string myValue = "a";
// Console.WriteLine(myValue != "a");

// These two lines of code will create the same output

// Console.WriteLine(pangram.Contains("fox") == false);
// Console.WriteLine(!pangram.Contains("fox"));

// int a = 7;
// int b = 6;
// Console.WriteLine(a != b); // output: True
// string s1 = "Hello";
// string s2 = "Hello";
// Console.WriteLine(s1 != s2); // output: False


// int saleAmount = 1001;
// int discount = saleAmount > 1000 ? 100 : 50; 
// Console.WriteLine($"Discount: {discount}");

// int saleAmount = 1001;
// // int discount = saleAmount > 1000 ? 100 : 50;

// Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");

// Random dice = new Random();
// Console.WriteLine(dice.Next(0, 2) == 0 ? "Head" : "tail");

string permission = "Admin|Manager";
int level = 55;

if (permission.Contains("Admin"))
{
  if (level > 50)
  {
    Console.WriteLine("Welcome, Super Admin user.");
  }
  else if (level < 50 || level == 50)
  {

    Console.WriteLine("Welcome, Admin user.");
  }
}
if (permission.Contains("Manager"))
{
  if (level > 20)
  {
    Console.WriteLine("Contact an Admin for access.");
  }
  else if (level < 20)
  {
    Console.WriteLine("You do not have sufficient privileges.");

  }
}
else
{ 
    Console.WriteLine("You do not have sufficient privileges.");
  
}