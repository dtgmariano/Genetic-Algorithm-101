using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GA
{
    public static class ChromossomeStrategy
    {
        /*Returns the gene of the Chromossome: List of 3x3 subgrids */
        public static List<string> generateChromossome(Random _random)
        {
            List<string> chromossome = new List<string>();
            int nmov = 63;
            while(nmov>0)
            {
                string move = Math.Round(_random.NextDouble(), 0) + "" +
                              Math.Round(_random.NextDouble(), 0) + "" + 
                              Math.Round(_random.NextDouble(), 0) + "" ;
                chromossome.Add(move);
                nmov--;
            }
            
            return chromossome;
        }
    

        /*Returns the fitness based on the Chromossomes's gene*/
        public static double calculatesFitness(List<string> _chromossome,Point _startPoint)
        {
            double fitness = 0.0;
            List<Point> trajetory = ProblemStrategy.GetTrajetory(_chromossome, _startPoint);

            var vTrajetory = new List<Point>(trajetory);
            var uniqueTrajetory = new HashSet<Point>(vTrajetory);

            trajetory = uniqueTrajetory.ToList();

            for (int idx = 0; idx < trajetory.Count(); idx++)
            {
                if (trajetory[idx].X < 0 || trajetory[idx].X > 7 || trajetory[idx].Y < 0 || trajetory[idx].Y > 7)
                {
                    trajetory.RemoveAt(idx);
                    idx--;
                }
            }

            fitness = trajetory.Count();

            return fitness;
        }

    }
}
