using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public static class Settings
    {
        public static List<string> generateSampleSpace(int _numIntervals, int _numInterruptions)
        {
            List<string> U = new List<String>();
            string binary;

            for (int i = 0; i < Math.Pow(2, _numIntervals); i++)
            {
                binary = BinaryOperators.DecimalToBinaryString(i, _numIntervals);
                if (countNumberOne(binary) == _numInterruptions)
                    U.Add(binary);
            }

            return U;
        }

        public static int countNumberOne(string bin)
        {
            int count = 0;

            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == '1')
                    count++;
            }

            return count;
        }

        public static string[] U_3stops = { "000100010001", "001000100010", "010001000100", "100010001000"};
                                            
        public static int numIntervals = 12;


    }
}
