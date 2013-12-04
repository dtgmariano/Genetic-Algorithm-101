using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public static class Equation
    {
        public static double set(int functionType, double x)
        {
            double y;
            switch (functionType)
            {
                case 1:
                    {
                        y = F1x(x);
                    }
                    break;

                case 2:
                    {
                        y = F2x(x);
                    }
                    break;
                case 3:
                    {
                        y = F3x(x);
                    }
                    break;
                case 4:
                    {
                        y = F4x(x);
                    }
                    break;
                case 5:
                    {
                        y = F5x(x);
                    }
                    break;
                default:
                    {
                        y = F1x(x);
                    }
                    break;
            }
            return y;
        }

        public static double F1x(double x)
        {
            return (-(Math.Abs(x * Math.Sin(Math.Sqrt(Math.Abs(x))))));
        }

        public static double F2x(double x)
        {
            return (x * Math.Sin(x/5));
        }

        public static double F3x(double x)
        {
            return ((100 * Math.Sin(x/5) + 75 * Math.Sin(x/10)) - (50 * Math.Sin(x/10))); 
        }

        public static double F4x(double x)
        {
            return (0.9 * (Math.Pow(x, 1.15)) - (Math.Pow(x, 1.05)) + 50*Math.Sin(x/10));
        }

        public static double F5x(double x)
        {
            return (x * 0.5);
        }
    }
}
