using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class ChromossomeStrategy
    {
        const int area = 36;
        const int size = 6;
        const int max = 7;
        public const double maxFitness = 100.0;
        /*Returns the gene of the Chromossome: List of 3x3 subgrids */
        public static List<int> generateChromossome(Random _random)
        {
            List<int> chromossome = new List<int>();
            //List<int> U = new List<int>(Enumerable.Range(1, 9));
            
            //while(U.Count()>0)
            //{
            //    int idx = _random.Next(0, U.Count());
            //    chromossome.Add(U[idx]);
            //    U.RemoveAt(idx);
            //}

            while (chromossome.Count() < area)
            {
                chromossome.Add(_random.Next(1, max));
            }
            
            return chromossome;
        }

        /*Returns the sum of the number of missing digits from each row and column from a grid*/
        public static int calculatePenalty(List<int> g)
        {
            int penaltyScore = 0;

            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[0], g[1], g[2], g[3], g[4], g[5] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[6], g[7], g[8], g[9], g[10], g[11] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[12], g[13], g[14], g[15], g[16], g[17] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[18], g[19], g[20], g[21], g[22], g[23] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[24], g[25], g[26], g[27], g[28], g[29] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[30], g[31], g[32], g[33], g[34], g[35] }));

            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[0], g[6], g[12], g[18], g[24], g[30] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[1], g[7], g[13], g[19], g[25], g[31] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[2], g[8], g[14], g[20], g[26], g[32] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[3], g[9], g[15], g[21], g[27], g[33] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[4], g[10], g[16], g[22], g[28], g[34] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[5], g[11], g[17], g[23], g[29], g[35] }));


            return penaltyScore;
        }

        public static int CalcSequencyPenalty(List<int> seq)
        {
            List<int> testList = new List<int>();
            int sum = 0;

            for (int i = 0; i < seq.Count(); i++)
            {
                int value = seq[i];
                bool containsItem = testList.Any(item => item == value);

                if (!containsItem)
                    testList.Add(value);
                else
                    sum++;
            }
            return sum;
        }

        /*Returns the fitness based on the Chromossomes's gene*/
        public static double calculatesFitness(List<int> _grid3x3)
        {
            double fitness = 0.0;

            double penalty = calculatePenalty(_grid3x3);

            if(penalty!=0)
                fitness = maxFitness / penalty;
            else
                fitness = maxFitness;
            
            return fitness;
        }

        /*Returns the fitness based on the Chromossomes's penalty*/
        public static double calculatesFitness(int _penalty)
        {
            double fitness = 0.0;

            double penalty = _penalty;

            if (penalty != 0)
                fitness = maxFitness / penalty;
            else
                fitness = maxFitness;

            return fitness;
        }
    }
}
