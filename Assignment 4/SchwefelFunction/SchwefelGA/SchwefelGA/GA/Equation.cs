using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class Equation
    {
        public static double Fxy(double x, double y)
        {
            return ((x * Math.Sin(Math.Abs(x))) + (y * Math.Sin(Math.Abs(y))));
        }
    }
}
