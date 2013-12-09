using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class Equation
    {
        public static double Fx(double x)
        {
            return (x * Math.Sin(x / 5));
        }
    }
}
