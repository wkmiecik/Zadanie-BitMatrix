using System;
using System.Collections.Generic;
using System.Collections;

namespace zadanie
{
    public partial class BitMatrix
    {
        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(0));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;

            if (bits != null && bits.Length != 0)
            {
                for (int i = 0; i < bits.Length; i++)
                {
                    if (i < data.Length)
                    {
                        data[i] = BitToBool(bits[i]);
                    }
                }
            }
        }
    }
}
