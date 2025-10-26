// List<string> str = new List<string>();

// str.Add("aarav"); 
// str.Add("faizan"); 
// str.Add("rohn"); 
// str.Add("ali"); 
// str.Add("pablo");
// str.Add("adolf");

// var res = str.Where(x => x.Contains("a")).ToList(); 

// foreach (var i in res)
// {
//   System.Console.WriteLine(i + " ");
// }


// List<int> integer = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// var result = integer.Where(x => x % 2 == 0);


// foreach (var i in result)
// {
//   Console.WriteLine(i); 

// }

// List<string> str = new List<string>();

// str.Add("aarav"); 
// str.Add("faizan"); 
// str.Add("rohn"); 
// str.Add("ali"); 
// str.Add("pablo");
// str.Add("adolf");

// var result = str.Select(x => x.ToUpper()); 

// foreach (var i in result)
// {
//   Console.WriteLine(i); 
// }



// List<int> integer = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// var result = integer.OrderByDescending(n => n); 


// foreach (var i in result)
// {
//   Console.WriteLine(i); 

// }

// List<string> str = new List<string>();

// str.Add("aarav"); 
// str.Add("faizan"); 
// str.Add("rohn"); 
// str.Add("ali"); 
// str.Add("pablo");
// str.Add("adolf");

// var result = str.Where(x => x.Length > 4).ToList(); 

// foreach (var i in result)
// {
//   Console.WriteLine(i); 
// }



// List<int> integer = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// var result = integer.Where(x => x > 5).OrderByDescending(x =>x); 


// foreach (var i in result)
// {
//   Console.WriteLine(i); 
// }


// List<string> str = new List<string>();

// str.Add("aarav"); 
// str.Add("faizan"); 
// str.Add("rohn"); 
// str.Add("ali"); 
// str.Add("pablo");
// str.Add("adolf");

// var result = str.Where(x => x.Contains("a")).Select(x => x.ToUpper());  

// foreach (var i in result)
// {
//   Console.WriteLine(i); 
// }



// List<int> scores = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// var result = scores.OrderByDescending(n => n).Take(3);  


// foreach (var i in result)
// {
//   Console.WriteLine(i); 
// }


// List<string> str = new List<string>();

// str.Add("aarav"); 
// str.Add("faizan"); 
// str.Add("rohn"); 
// str.Add("ali"); 
// str.Add("pablo");
// str.Add("adolf");

// var result = str.Where(x => x.Length > 5).Count();

// Console.Write(result); 




public  class Program
{
  public static void Main(string[] args)
  {
    List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 800, Category = "Electronics" },
            new Product { Id = 2, Name = "Mouse", Price = 20, Category = "Electronics" },
            new Product { Id = 3, Name = "Shirt", Price = 35, Category = "Clothing" },
            new Product { Id = 4, Name = "Phone", Price = 600, Category = "Electronics" },
            new Product { Id = 5, Name = "Shoes", Price = 90, Category = "Footwear" },
            new Product { Id = 6, Name = "Headphones", Price = 120, Category = "Electronics" },
            new Product { Id = 7, Name = "Watch", Price = 150, Category = "Accessories" },
            new Product { Id = 8, Name = "Keyboard", Price = 45, Category = "Electronics" },
            new Product { Id = 9, Name = "Jacket", Price = 80, Category = "Clothing" },
            new Product { Id = 10, Name = "Tablet", Price = 300, Category = "Electronics" }
        };

        List<Employee> emp = new List<Employee>
    {
      new Employee {Id = 1, Name = "Faizan" },
      new Employee {Id = 2, Name = "Rohan" },
      new Employee {Id = 3, Name = "Pablo" },
    };


    var result = products.Join(emp);




    

    foreach (var group in result)
    {
      Console.WriteLine("Category: " + group.Key +" | "+ group.Count());
      foreach (var item in group)
      {
        Console.WriteLine($"Name: {item.Name} | Price: {item.Price} | Category: {item.Category}"); 
      }
    }


  }
}

