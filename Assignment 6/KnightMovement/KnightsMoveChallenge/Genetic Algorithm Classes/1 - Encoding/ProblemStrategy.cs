using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GA
{
    public static class ProblemStrategy
    {
        public static List<string> possibleMovements = new List<string>() { "000", "001", "010", "011", "100", "101", "110", "111"};

        public static List<string> fixMovementSequency(Point _startPoint, 
                                                       List<string> _movementSequency,
                                                       Random _random)
        {
            List<string> movementSequency = _movementSequency;
            

            Point currentPoint;
            string move;
            bool validation;


            currentPoint = new Point(_startPoint.X, _startPoint.Y);
            

            for (int i = 0; i < _movementSequency.Count(); i++)
            {
                validation = isOutOfBoundaries(_movementSequency[i], currentPoint);
                if (!validation)
                {
                    Dictionary<string, int> count = new Dictionary<string, int>();
       
                    for (int j = 0; j < possibleMovements.Count(); j++)
                    {

                    }
                }
            }

            


            move = possibleMovements[_random.Next(0, 9)];
            validation = isOutOfBoundaries(move, currentPoint);

            if (!validation)
            {
                
            }


            return _movementSequency;
        }


        public static List<Point> GetTrajetory(List<string> _chromossome, Point _startPoint)
        {
            Point currentPoint = new Point(_startPoint.X, _startPoint.Y);

            List<Point> trajetory = new List<Point>() { currentPoint };

            for (int i = 0; i < _chromossome.Count(); i++)
            {
                currentPoint = returnNextPosition(_chromossome[i], currentPoint);
                trajetory.Add(currentPoint);
            }

            return trajetory;
        }

        public static bool isOutOfBoundaries(string _nextMovement, Point _currentPoint)
        {
            bool isValid;

            int idx = BinaryStringToDecimal(_nextMovement);
            Point nextPoint = new Point();

            #region nextPoint cases
            switch (idx)
            {
                case 0:
                    {
                        nextPoint.X = _currentPoint.X + 2;
                        nextPoint.Y = _currentPoint.Y + 1;
                    }
                    break;
                case 1:
                    {
                        nextPoint.X = _currentPoint.X + 1;
                        nextPoint.Y = _currentPoint.Y + 2;
                    }
                    break;
                case 2:
                    {
                        nextPoint.X = _currentPoint.X - 1;
                        nextPoint.Y = _currentPoint.Y + 2;
                    }
                    break;
                case 3:
                    {
                        nextPoint.X = _currentPoint.X - 2;
                        nextPoint.Y = _currentPoint.Y + 1;
                    }
                    break;
                case 4:
                    {
                        nextPoint.X = _currentPoint.X - 2;
                        nextPoint.Y = _currentPoint.Y - 1;
                    }
                    break;
                case 5:
                    {
                        nextPoint.X = _currentPoint.X - 1;
                        nextPoint.Y = _currentPoint.Y - 2;
                    }
                    break;
                case 6:
                    {
                        nextPoint.X = _currentPoint.X + 1;
                        nextPoint.Y = _currentPoint.Y - 2;
                    }
                    break;
                case 7:
                    {
                        nextPoint.X = _currentPoint.X + 2;
                        nextPoint.Y = _currentPoint.Y - 1;
                    }
                    break;
            }
            #endregion

            if (nextPoint.X < 0 || nextPoint.X > 8 || nextPoint.Y < 0 || nextPoint.Y > 8)
                isValid = false;
            else 
                isValid = true;

            return isValid;
        }

        public static Point returnNextPosition(string _nextMovement, Point _currentPoint)
        {
            Point nextPoint = new Point();

            int idx = BinaryStringToDecimal(_nextMovement);
            switch (idx)
            {
                case 0:
                    {
                        nextPoint.X = _currentPoint.X + 2;
                        nextPoint.Y = _currentPoint.Y + 1;
                    }
                    break;
                case 1:
                    {
                        nextPoint.X = _currentPoint.X + 1;
                        nextPoint.Y = _currentPoint.Y + 2;
                    }
                    break;
                case 2:
                    {
                        nextPoint.X = _currentPoint.X - 1;
                        nextPoint.Y = _currentPoint.Y + 2;
                    }
                    break;
                case 3:
                    {
                        nextPoint.X = _currentPoint.X - 2;
                        nextPoint.Y = _currentPoint.Y + 1;
                    }
                    break;
                case 4:
                    {
                        nextPoint.X = _currentPoint.X - 2;
                        nextPoint.Y = _currentPoint.Y - 1;
                    }
                    break;
                case 5:
                    {
                        nextPoint.X = _currentPoint.X - 1;
                        nextPoint.Y = _currentPoint.Y - 2;
                    }
                    break;
                case 6:
                    {
                        nextPoint.X = _currentPoint.X + 1;
                        nextPoint.Y = _currentPoint.Y - 2;
                    }
                    break;
                case 7:
                    {
                        nextPoint.X = _currentPoint.X + 2;
                        nextPoint.Y = _currentPoint.Y - 1;
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
