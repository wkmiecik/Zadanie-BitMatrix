using System;

namespace zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            BitMatrix m = new BitMatrix(4,3);
            m[3, 2] = true;
            Console.WriteLine(m[3,2]);
            Console.WriteLine(m);
        }
    }
}
