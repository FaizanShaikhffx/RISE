
using System;
// public class DataStore<T>
// {
//   public T data { get; set; }
// }
// public class DataStore<TKey, TValue>
// {
//   public TKey Key { get; set; }
//   public TValue Value { get; set; }
// }

class Program {
  public static void Main(string[] args)
  {
    // DataStore<string> store = new DataStore<string>();
    // store.data = "Faizan";
    // Console.WriteLine(store.data);

    // DataStore<int, string> name = new DataStore<int, string>();
    // name.Key = 1;
    // name.Value = "Faizan";
    // Console.WriteLine(name.Key + " " + name.Value);


    // List<int> numbers = new List<int>();
    // numbers.Add(5);
    // numbers.Add(10);
    // numbers.Add(15);
    // numbers.Add(20);
    // numbers.Add(25);
    // numbers.Add(30);
    // numbers.Remove(30);

    // numbers.Insert(0, 1000);

    // foreach (int i in numbers)
    // {
    //   Console.Write(i + " ");
    // }

    Dictionary<int, string> student = new Dictionary<int, string>();
    student.Add(1, "Faizan");
    student.Add(2, "Rohan");
    student.Add(3, "John");
    student.Add(4, "Franklin");
    student.Add(5, "David");


    Console.WriteLine(student[1]);

    foreach (KeyValuePair<int, string> i in student){ 
      Console.WriteLine(i.Key+" "+i.Value); 
    }
    




    }
  }

