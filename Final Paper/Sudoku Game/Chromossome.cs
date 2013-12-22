using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace GA
{
    public class Chromossome
    {
        const int nrow = 9;
        const int ncol = 9;
        const int size = nrow * ncol;
        const int minValue = 1;
        const int maxValue = 10;

        public List<int> gene;
        public double fitness;
        public int penalty;

        public Chromossome(Random _random)
        {
            gene = generatesSlots(_random);
            penalty = CalcPenalty(gene);
            fitness = calculateFitness(penalty);

        }

        public Chromossome(List<int> _gene)
        {
            if (_gene.Count() > 81)
            {
                Console.Write(true);
            }
            gene = new List<int>(_gene);
            penalty = CalcPenalty(gene);
            fitness = calculateFitness(penalty);
        }

        public List<int> generatesSlots(Random _random)
        {
            List<int> slots = new List<int>();

            for (int i = 0; i < size; i++)
            {
                slots.Add(_random.Next(minValue, maxValue));
            }
            return slots;
        }

        int CalcPenalty(List<int> _gene)
        {
            int penaltyScore = 0;

            for(int i=0; i<nrow; i++)
            {
                penaltyScore += CalcLinePenalty(_gene, i);
                penaltyScore += CalcColumnPenalty(_gene, i);
            }

            int count=0;

            while (count < 60)
            {
                penaltyScore += CalcSquarePenalty(_gene, count);
                penaltyScore += CalcSquarePenalty(_gene, count + 3);
                penaltyScore += CalcSquarePenalty(_gene, count + 6);
                count += 27;
            }
            return penaltyScore;
        }

        int CalcLinePenalty(List<int> _gene, int lineIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for(int i=0; i<ncol; i++)
            {
                int index = lineIndex * ncol + i;
                int value = _gene[index];

                bool containsItem = testList.Any(item => item == value);

                if (!containsItem)
                    testList.Add(value);
                else
                    sum++;
            }
            return sum;
        }

        int CalcColumnPenalty(List<int> _gene, int columnIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = columnIndex; i < nrow; i+=ncol)
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

        int CalcSquarePenalty(List<int> _gene, int sqIndex)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index = (sqIndex + i * ncol) + j;
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


        double calculateFitness(int penalty)
        {
            double fitness = 1000.0;

            if (penalty == 0)
                fitness = 1000.0;
            else
                fitness /= penalty;
            return fitness;
        }
    }
}
