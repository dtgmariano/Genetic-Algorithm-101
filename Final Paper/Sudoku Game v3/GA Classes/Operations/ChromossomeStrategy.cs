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

        public static List<int> firstChild(Random _random)
        {
            List<int> genes = new List<int>();
            genes = generateGenes(_random);
            return genes;
        }

        public static List<int> generateGenes(Random _random)
        {
            List<int> slots = new List<int>();

            for (int i = 0; i < size; i++)
            {
                List<int> U = genU();
                for (int j = 0; j < size; j++)
                {
                    int index = _random.Next(0, U.Count());
                    slots.Add(U[index]);
                    U.RemoveAt(index);
                }
            }

            return slots;
        }

        static bool ValidatesGene(List<int> _gene)
        {
            bool isValid = true;

            for (int i = 0; i < size; i++)
            {
                if (CalcLinePenalty(_gene, i) > 0)
                {
                    isValid = false;
                    break;
                }

                if (CalcColumnPenalty(_gene, i) > 0)
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        static int CalcPenalty(List<int> _gene)
        {
            int penaltyScore = 0;

            for (int i = 0; i < size; i++)
            {
                penaltyScore += CalcLinePenalty(_gene, i);
                penaltyScore += CalcColumnPenalty(_gene, i);
            }

            int count = 0;

            while (count < 60)
            {
                penaltyScore += CalcSquarePenalty(_gene, count);
                penaltyScore += CalcSquarePenalty(_gene, count + 3);
                penaltyScore += CalcSquarePenalty(_gene, count + 6);
                count += 27;
            }
            return penaltyScore;

        }
        static int CalcLinePenalty(List<int> _gene, int lineIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                int index = lineIndex * size + i;
                int value = _gene[index];

                bool containsItem = testList.Any(item => item == value);

                if (!containsItem)
                    testList.Add(value);
                else
                    sum++;
            }
            return sum;
        }

        static int CalcColumnPenalty(List<int> _gene, int columnIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = columnIndex; i < size; i += size)
            {
                int value = _gene[i];
                bool containsItem = testList.Any(item => item == value);

                if (!containsItem)
                    testList.Add(value);
                else
                    sum++;
            }
            return sum;
        }

        static int CalcSquarePenalty(List<int> _gene, int sqIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index = (sqIndex + i * size) + j;
                    int value = _gene[index];

                    bool containsItem = testList.Any(item => item == value);

                    if (!containsItem)
                        testList.Add(value);
                    else
                        sum++;
                }
            }
            return sum;
        }

        static List<int> genUsel()
        {
            List<int> U = new List<int>();
            U.AddRange(genU());
            U.AddRange(genU());
            U.AddRange(genU());
            U.AddRange(genU());
            U.AddRange(genU());
            U.AddRange(genU());
            U.AddRange(genU());
            U.AddRange(genU());
            U.AddRange(genU());
            U.Sort();
            return U;
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
    }
}
