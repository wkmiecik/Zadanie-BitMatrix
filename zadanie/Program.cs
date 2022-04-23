using System;
using System.Collections.Generic;
using System.Collections;

namespace zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            // konwersja `BitMatrix` na `BitArray`
            var m = new BitMatrix(2, 3, 1, 0, 1, 1, 1, 0);
            BitArray bitArr = (BitArray)m;

            Console.WriteLine(m.NumberOfRows * m.NumberOfColumns == bitArr.Count);

            for (int i = 0; i < m.NumberOfRows; i++)
                for (int j = 0; j < m.NumberOfColumns; j++)
                    if (m[i, j] != BitMatrix.BoolToBit(bitArr[i * m.NumberOfColumns + j]))
                    {
                        Console.WriteLine("Fail");
                        return;
                    }

            // czy niezależna kopia
            m[1, 2] = 1;
            Console.WriteLine(m[1, 2] != BitMatrix.BoolToBit(bitArr[5]));
        }
    }
}
