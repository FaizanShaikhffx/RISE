using System;
using System.Data.SqlTypes;

public delegate int MathOperation(int a, int b); 




class Program
{

    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b; 
    }



    // static void Main(string[] args)
    // {
    //     MathOperation add = new MathOperation(Add);
    //     int result = add.Invoke(10, 20);
    //     Console.WriteLine(result);

    //     MathOperation mul = new MathOperation(Multiply);
    //     int multiplication = mul(10, 10);
    //     Console.WriteLine(multiplication); 

    // }
}