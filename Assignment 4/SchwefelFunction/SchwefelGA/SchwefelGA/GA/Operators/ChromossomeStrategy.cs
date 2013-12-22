using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GA
{
    public static class ChromossomeStrategy
    {
        public static string generateChromossome(Random _random, int _chromossomeSize)
        {
            string chromossome = "";

            while (chromossome.Length <= _chromossomeSize)
                chromossome += (_random.Next(0,2)).ToString();

            return chromossome;
        }

        public static double calculateFitness(string _chromossome, int _min, int _max, int _res, int _nbits)
        {
            return Fxy(calculateCoords(_chromossome, _min, _max, _res, _nbits));
        }

        public static double Fxy(List<double> _coords)
        {
            return ((-_coords[0] * Math.Sin(Math.Sqrt(Math.Abs(_coords[0])))) + (-_coords[1] * Math.Sin(Math.Sqrt(Math.Abs(_coords[1])))));
        }

        public static List<double> calculateCoords(string _chromossome, int _min, int _max, int _res, int _nbits)
        {
            List<double> coords = new List<double>();

            int x_bin = BinaryStringToDecimal(_chromossome.Substring(0, _chromossome.Length / 2));
            int y_bin = BinaryStringToDecimal(_chromossome.Substring((_chromossome.Length / 2), _chromossome.Length / 2));

            coords.Add(_min + (_max - _min) * (x_bin) / (Math.Pow(2, _nbits + _res)));
            coords.Add(_min + (_max - _min) * (y_bin) / (Math.Pow(2, _nbits + _res)));

            return coords;
        }

        public static int BinaryStringToDecimal(string _code)
        {
            int Rslt = 0;
            int Mask = 1;
            for (int i = _code.Length - 1; i >= 0; --i, Mask <<= 1)
            {
                if (_code[i] != '0')
                {
                    Rslt |= Mask;
                }
            }
            return (Rslt);
        }
    }
}
