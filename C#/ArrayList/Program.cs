using System;
using System.Collections;

class Program
{
  public static void Main(string[] args)
  {
    // ArrayList arrList = new ArrayList(); 
    // var arrList = new ArrayList();
    // arrList.Add(1);
    // arrList.Add(1);
    // arrList.Add(1);
    // arrList.Add(null);

    // foreach(var i in arrList) {
    //   Console.WriteLine(i == null? "true" : i); 
    // }

    Queue q1 = new Queue();
    q1.Enqueue(5);
    q1.Enqueue(10);
    q1.Enqueue(15);
    q1.Dequeue();

    ArrayList arl1 = new ArrayList() { 1, 2, 3, 4};
    ArrayList arl2 = new ArrayList() { 4, 5, 6 };

    // arl1.AddRange(arl2); 
    // arl1.Insert(1, 4);
    // arl1.InsertRange(1, arl2);
    // arl1.RemoveRange(0, 2);
    // foreach (var i in arl1)
    // {
    //   Console.WriteLine(i);
    // }

    Console.WriteLine(arl1.Capacity);






  }

}