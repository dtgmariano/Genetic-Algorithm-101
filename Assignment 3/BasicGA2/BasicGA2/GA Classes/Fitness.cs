using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public static class Fitness
    {
        public static double set(int functionType, int optimizationType, double x)
        {
            double y;
            #region switch cases
            switch (optimizationType)
            {
                case 0:
                {
                    switch (functionType)
                    {
                        case 1:
                            {
                                y = -Equation.F1x(x);
                            }
                            break;

                        case 2:
                            {
                                y = -Equation.F2x(x);
                            }
                            break;

                        case 3:
                            {
                                y = -Equation.F3x(x);
                            }
                            break;

                        case 4:
                            {
                                y = -Equation.F4x(x);
                            }
                            break;

                        case 5:
                            {
                                y = -Equation.F5x(x);
                            }
                            break;

                        default:
                            {
                                y = -Equation.F1x(x);
                            }
                            break;
                    }
                }
                break;

                case 1:
                {
                    switch (functionType)
                    {
                        
                        case 1:
                        {
                            y = Equation.F1x(x);
                        }
                        break;

                        case 2:
                        {
                            y = Equation.F2x(x);
                        }
                        break;

                        case 3:
                        {
                            y = Equation.F3x(x);
                        }
                        break;

                        case 4:
                        {
                            y = Equation.F4x(x);
                        }
                        break;

                        case 5:
                        {
                            y = Equation.F5x(x);
                        }
                        break;

                        default:
                        {
                            y = Equation.F1x(x);
                        }
                        break;
                    }
                }
                break;

                default:
                {
                    switch (functionType)
                    {
                        case 1:
                            {
                                y = -Equation.F1x(x);
                            }
                            break;

                        case 2:
                            {
                                y = -Equation.F2x(x);
                            }
                            break;

                        case 3:
                            {
                                y = -Equation.F3x(x);
                            }
                            break;

                        case 4:
                            {
                                y = -Equation.F4x(x);
                            }
                            break;

                        case 5:
                            {
                                y = -Equation.F5x(x);
                            }
                            break;

                        default:
                            {
                                y = -Equation.F1x(x);
                            }
                            break;
                    }
                }
                break;
            }
            #endregion
            return y;
        }     
    }
}
