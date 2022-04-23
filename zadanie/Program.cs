using System;

namespace zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse, string pusty
            try
            {
                Console.WriteLine(BitMatrix.Parse(string.Empty));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Pass");
                return;
            }
            Console.WriteLine("Fail");
        }
    }
}
