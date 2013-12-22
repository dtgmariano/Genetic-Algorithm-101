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
        const int max = 10;
        public const double maxFitness = 10.0;
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

            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[0], g[1], g[2], g[3], g[4], g[5], g[6], g[7], g[8] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[9], g[10], g[11], g[12], g[13], g[14], g[15], g[16], g[17] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[18], g[19], g[20], g[21], g[22], g[23], g[24], g[25], g[26] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[27], g[28], g[29], g[30], g[31], g[32], g[33], g[34], g[35] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[36], g[37], g[38], g[39], g[40], g[41], g[42], g[43], g[44] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[45], g[46], g[47], g[48], g[49], g[50], g[51], g[52], g[53] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[54], g[55], g[56], g[57], g[58], g[59], g[60], g[61], g[62] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[63], g[64], g[65], g[66], g[67], g[68], g[69], g[70], g[71] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[72], g[73], g[74], g[75], g[76], g[77], g[78], g[79], g[80] }));

            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[0], g[9], g[18], g[27], g[36], g[45], g[54], g[63], g[72] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[1], g[10], g[19], g[28], g[37], g[46], g[55], g[64], g[73] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[2], g[11], g[20], g[29], g[38], g[47], g[56], g[65], g[74] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[3], g[12], g[21], g[30], g[39], g[48], g[57], g[66], g[75] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[4], g[13], g[22], g[31], g[40], g[49], g[58], g[67], g[76] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[5], g[14], g[23], g[32], g[41], g[50], g[59], g[68], g[77] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[6], g[15], g[24], g[33], g[42], g[51], g[60], g[69], g[78] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[7], g[16], g[25], g[34], g[43], g[52], g[61], g[70], g[79] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[8], g[17], g[26], g[35], g[44], g[53], g[62], g[71], g[80] }));

            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[0], g[1], g[2], g[9], g[10], g[11], g[18], g[19], g[20] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[3], g[4], g[5], g[12], g[13], g[14], g[21], g[22], g[23] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[6], g[7], g[8], g[15], g[16], g[17], g[24], g[25], g[26] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[27], g[28], g[29], g[36], g[37], g[38], g[45], g[46], g[47] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[30], g[31], g[32], g[39], g[40], g[41], g[48], g[49], g[50] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[33], g[34], g[35], g[42], g[43], g[44], g[51], g[52], g[53] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[54], g[55], g[56], g[63], g[64], g[65], g[72], g[73], g[74] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[57], g[58], g[59], g[66], g[67], g[68], g[75], g[76], g[77] }));
            penaltyScore += CalcSequencyPenalty(new List<int>(new[] { g[60], g[61], g[62], g[69], g[70], g[71], g[78], g[79], g[80] }));


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
