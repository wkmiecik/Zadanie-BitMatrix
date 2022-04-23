using System;

namespace zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            // sprawdzenie, czy tworzona
            // jest niezależna kopia
            var m = new BitMatrix(2, 3);
            var m1 = (BitMatrix)(m.Clone());
            m[0, 0] = 1;
            Console.WriteLine(m[0, 0] != m1[0, 0]);
        }
    }
}
