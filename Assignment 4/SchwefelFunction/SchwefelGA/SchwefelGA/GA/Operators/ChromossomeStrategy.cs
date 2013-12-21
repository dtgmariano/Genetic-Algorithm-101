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

        public static List<object> generateChromossome(Random _random, int _chromossomeSize)
        {
            List<object> chromossome = new List<object>();

            while (chromossome.Count() <= _chromossomeSize)
                chromossome.Add(_random.Next(0,2));

            return chromossome;
        }


        /*Returns the fitness based on the Chromossome's number of penalties*/
        public static double calculatesFitness(List<object> chromossome)
        {
            return 100.0 / penaltyScore;
        }

    }
}
