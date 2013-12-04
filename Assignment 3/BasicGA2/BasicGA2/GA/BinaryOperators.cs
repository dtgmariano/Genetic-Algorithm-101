using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class BinaryOperators
    {
        public static string GeneratesBinaryString(Random _random, int NBits)
        {
            string binary = "";
            for (int i = 0; i < NBits; i++)
            {
                if (_random.Next(0, 2) == 0)
                    binary = "0" + binary;
                else
                    binary = "1" + binary;
            }

            return binary;
        }
        /*Convert a Decimal number to a Binary String*/
        public static string DecimalToBinaryString(int Decimal, int NBits)
        {
            string binary = "";
            int mask = 1;
            for (int i = 0; i < NBits; i++)
            {
                if ((mask & Decimal) >= 1)
                    binary = "1" + binary;
                else
                    binary = "0" + binary;
                mask <<= 1;
            }
            return binary;
        }

        /*Convert a Binary String into a Decimal number*/
        public static int BinaryStringToDecimal(string a)
        {
            int Rslt = 0;
            int Mask = 1;
            for (int i = a.Length - 1; i >= 0; --i, Mask <<= 1)
            {
                if (a[i] != '0')
                {
                    Rslt |= Mask;
                }
            }
            return (Rslt);
        }

        /*Reverse a Binary String*/
        public static string InvertBinaryString(string _firstBinaryString)
        {
            int result = Convert.ToInt32(_firstBinaryString, 2);
            string complementedBinaryNumber = Convert.ToString(~result, 2);
            complementedBinaryNumber = complementedBinaryNumber.Remove(0, complementedBinaryNumber.Length - _firstBinaryString.Length);
            return complementedBinaryNumber;
        }
    }
}
