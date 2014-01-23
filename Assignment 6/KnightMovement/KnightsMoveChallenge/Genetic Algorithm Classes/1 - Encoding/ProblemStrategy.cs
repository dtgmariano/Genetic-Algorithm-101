using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GA
{
    public static class ProblemStrategy
    {
        public static List<Point> GetTrajetory(List<string> _chromossome, Point _startPoint)
        {
            Point currentPoint = new Point(_startPoint.X, _startPoint.Y);
            List<Point> trajetory = new List<Point>() { currentPoint };

            foreach (string s in _chromossome)
            {
                currentPoint = ReturnNextPosition(s, currentPoint);
                trajetory.Add(currentPoint);
            }
            return trajetory;
        }

        public static Point ReturnNextPosition(string move, Point currentPoint)
        {
            int idx = BinaryStringToDecimal(move);
            Point nextPoint = new Point();

            switch (idx)
            {
                case 0:
                    {
                        nextPoint.X = currentPoint.X + 2;
                        nextPoint.Y = currentPoint.Y + 1;
                    }
                    break;
                case 1:
                    {
                        nextPoint.X = currentPoint.X + 1;
                        nextPoint.Y = currentPoint.Y + 2;
                    }
                    break;
                case 2:
                    {
                        nextPoint.X = currentPoint.X - 1;
                        nextPoint.Y = currentPoint.Y + 2;
                    }
                    break;
                case 3:
                    {
                        nextPoint.X = currentPoint.X - 2;
                        nextPoint.Y = currentPoint.Y + 1;
                    }
                    break;
                case 4:
                    {
                        nextPoint.X = currentPoint.X - 2;
                        nextPoint.Y = currentPoint.Y - 1;
                    }
                    break;
                case 5:
                    {
                        nextPoint.X = currentPoint.X - 1;
                        nextPoint.Y = currentPoint.Y - 2;
                    }
                    break;
                case 6:
                    {
                        nextPoint.X = currentPoint.X + 1;
                        nextPoint.Y = currentPoint.Y - 2;
                    }
                    break;
                case 7:
                    {
                        nextPoint.X = currentPoint.X + 2;
                        nextPoint.Y = currentPoint.Y - 1;
                    }
                    break;
            }
            return nextPoint;
        }

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
    }
}
