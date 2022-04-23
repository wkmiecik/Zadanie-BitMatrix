using System;

namespace zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var m1 = new BitMatrix(5, 6);
            var m2 = new BitMatrix(6, 5);
            Console.WriteLine(m1.Equals(m2));
        }
    }
}
