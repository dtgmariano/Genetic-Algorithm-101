using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class ChromossomeStrategy
    {
        const int area = 81;
        const int size = 9;

        public static List<List<int>> generateGenes(Random _random)
        {
            List<List<int>> genes = new List<List<int>>();

            for (int i = 0; i < size; i++)
            {
                genes.Add(generateSquare(_random));
            }

            return genes;
        }

        public static List<int> generateMatrix(List<List<int>> genes)
        {
            int [] vector = new int[81];

            for (int i = 0; i < 9; i++) //
            {
                for (int j = 0; j < 9; j++)
                    vector[(3 * (i + 2 * (i - (i % 3)))) + (3 * (j - (j % 3))) + (j % 3)] = genes[i][j];
            }

            ////Test to check the operation!!
            //Console.WriteLine("test");
            //Console.WriteLine("Genes");
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        Console.Write(genes[i][j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine("Vector");

            //for (int i = 0; i < 81; i++)
            //{
            //    Console.Write(vector[i] + " ");
            //    if ((i + 1) % 9 == 0)
            //        Console.WriteLine();
            //}

            List<int> lvector = vector.ToList<int>();
            return lvector;
        }

        //public static List<List<int>> generateUspace(Random _random)
        //{
        //    List<List<int>> Uspace = new List<List<int>>();

        //    for (int i = 0; i < 1000; i++)
        //    {
        //        List<int> squareSample = generateSquare(_random);

        //        for (int j = 0; j < Uspace.Count(); j++)
        //        {
        //            if(squareSample[j] == 
        //        }

        //    }
            

        //    return Uspace;
        //}

        public static List<int> generateSquare(Random _random)
        {
            List<int> square = new List<int>();

            List<int> U = genU();
            for (int i = 0; i < size; i++)
            {
                int index = _random.Next(0, U.Count());
                square.Add(U[index]);
                U.RemoveAt(index);
            }

            return square;
        }

        static List<int> genU()
        {
            List<int> U = new List<int>();
            U.Add(1);
            U.Add(2);
            U.Add(3);
            U.Add(4);
            U.Add(5);
            U.Add(6);
            U.Add(7);
            U.Add(8);
            U.Add(9);
            U.Sort();
            return U;

        }

        public static double calculateFitness2(List<List<int>> _genes)
        {
            List<int> matrix = generateMatrix(_genes);
            double fitness = 0.0;
            int numMissingDigits=0;

            for (int i = 0; i < size; i++)
            {
                calculateNumberMissingDigits(matrix.GetRange(i * size, size));
            }

            return fitness;
        }

        public static int calculateNumberMissingDigits(List<int> list)
        {
            HashSet<int> myRange = new HashSet<int>(Enumerable.Range(0, 10));
            myRange.ExceptWith(list);

            return myRange.Count();
        }



        public static double calculateFitness(int penaltyScore)
        {
            return (100.0 / penaltyScore);
        }

        public static int calculatePenalty(List<List<int>> _genes)
        {
            List<int> matrix = generateMatrix(_genes);
            int penaltyScore = 0;

            for (int i = 0; i < size; i++)
            {
                penaltyScore += CalcLinePenalty(matrix, i);
                penaltyScore += CalcColumnPenalty(matrix, i);
            }
            
            return penaltyScore;
        }

        static int CalcLinePenalty(List<int> _gene, int lineIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = (9*lineIndex); i < (9*lineIndex + size); i++)
            {
                int value = _gene[i];

                bool containsItem = testList.Any(item => item == value);

                if (!containsItem)
                    testList.Add(value);
                else
                    sum++;
            }
            //Console.WriteLine("Line   " + lineIndex + ": " + sum + " errors");
            return sum;
        }

        static int CalcColumnPenalty(List<int> _gene, int columnIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = columnIndex; i < area; i += size)
            {
                int value = _gene[i];
                bool containsItem = testList.Any(item => item == value);

                if (!containsItem)
                    testList.Add(value);
                else
                    sum++;
            }
            //Console.WriteLine("Column " + columnIndex + ": " + sum + " errors");
            return sum;
        }

        //static int CalcSquarePenalty(List<int> _gene, int sqIndex)
        //{
        //    List<int> testList = new List<int>();
        //    int sum = 0;

        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            int index = (sqIndex + i * size) + j;
        //            int value = _gene[index];

        //            bool containsItem = testList.Any(item => item == value);

        //            if (!containsItem)
        //                testList.Add(value);
        //            else
        //                sum++;
        //        }
        //    }
        //    return sum;
        //}
    }
}
