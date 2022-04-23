﻿using System;
using System.Collections.Generic;
using System.Collections;

namespace zadanie
{
    public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
    {
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
        public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }
        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {
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
        public BitMatrix(int[,] bits)
        {
            if (bits == null) throw new NullReferenceException();
            if (bits.Length == 0) throw new ArgumentOutOfRangeException();

            data = new BitArray(bits.GetLength(0) * bits.GetLength(1), BitToBool(0));
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);

            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {
                    data[(i * NumberOfColumns) + j] = BitToBool(bits[i, j]);
                }
            }
        }
        public BitMatrix(bool[,] bits)
        {
            if (bits == null) throw new NullReferenceException();
            if (bits.Length == 0) throw new ArgumentOutOfRangeException();

            data = new BitArray(bits.GetLength(0) * bits.GetLength(1), BitToBool(0));
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);

            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {
                    data[(i * NumberOfColumns) + j] = bits[i, j];
                }
            }
        }

        public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
        public static bool BitToBool(int bit) => bit != 0;

        public override string ToString()
        {
            string wynik = "";

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    wynik += BoolToBit(data[(i * NumberOfColumns) + j]);
                }
                wynik += Environment.NewLine;
            }

            return wynik;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BitMatrix);
        }

        public bool Equals(BitMatrix other)
        {
            if (other == null) return false;

            if (this.NumberOfColumns != other.NumberOfColumns || this.NumberOfRows != other.NumberOfRows)
            {
                return false;
            }

            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i] != other.data[i]) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.data.GetHashCode();
        }

        public static bool operator ==(BitMatrix bitM1, BitMatrix bitM2)
        {
            if (((object)bitM1) == null || ((object)bitM2) == null)
                return Object.Equals(bitM1, bitM2);

            return bitM1.Equals(bitM2);
        }
        public static bool operator !=(BitMatrix bitM1, BitMatrix bitM2)
        {
            if (((object)bitM1) == null || ((object)bitM2) == null)
                return !Object.Equals(bitM1, bitM2);

            return !(bitM1.Equals(bitM2));
        }

        public int this[int i, int j]
        {
            get
            {
                if (i >= NumberOfRows || j >= NumberOfColumns || i < 0 || j < 0) throw new IndexOutOfRangeException();
                return BoolToBit(data[(i * NumberOfColumns) + j]);
            }
            set
            {
                if (i >= NumberOfRows || j >= NumberOfColumns || i < 0 || j < 0) throw new IndexOutOfRangeException();
                data[(i * NumberOfColumns) + j] = BitToBool(value);
            }
        }


        public IEnumerator<int> GetEnumerator()
        {
            foreach (bool bit in data)
                yield return BoolToBit(bit);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            var clone = new BitMatrix(NumberOfRows, NumberOfColumns);

            for (int i = 0; i < data.Count; i++)
            {
                clone.data[i] = data[i];
            }

            return clone;
        }
    }
}
