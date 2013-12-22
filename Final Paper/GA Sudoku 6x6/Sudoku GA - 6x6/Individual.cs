using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace GA
{
    public class Individual
    {
        public List<int> chromossome;
        public double fitness;
        public int penalty;

        public Individual(Random _random)
        {
            chromossome = ChromossomeStrategy.generateChromossome(_random);
            penalty = ChromossomeStrategy.calculatePenalty(chromossome);
            fitness = ChromossomeStrategy.calculatesFitness(penalty);
        }

        public Individual(List<int> _gene)
        {
            chromossome = new List<int>(_gene);
            penalty = ChromossomeStrategy.calculatePenalty(chromossome);
            fitness = ChromossomeStrategy.calculatesFitness(penalty);
        }

       
    }
}
