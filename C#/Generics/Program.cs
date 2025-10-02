
using System;
public class DataStore<T>
{
  public T data { get; set; }
}
public class DataStore<TKey, TValue>
{
  public TKey Key { get; set; }
  public TValue Value { get; set; }
}

class Program {
  public static void Main(string[] args)
  {
    // DataStore<string> store = new DataStore<string>();
    // store.data = "Faizan";
    // Console.WriteLine(store.data);

    DataStore<int, string> name = new DataStore<int, string>();
    name.Key = 1;
    name.Value = "Faizan";
    Console.WriteLine(name.Key + " " + name.Value);
    
  }
}

