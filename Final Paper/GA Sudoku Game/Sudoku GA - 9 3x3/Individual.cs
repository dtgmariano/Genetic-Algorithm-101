using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using GA;
namespace GA
{
    public class Individual
    {
        public List<List<int>> chromossome;
        //public List<object> chromosssome;
        public double fitness;
        public int penalty;

        public Individual(Random _random)
        {

            chromossome = ChromossomeStrategy.generateGenes(_random);
            penalty = ChromossomeStrategy.calculatePenalty(chromossome);
            fitness = ChromossomeStrategy.calculatesFitness(penalty);
        }

        public Individual(List<List<int>> _gene)
        {
            chromossome = _gene;
            penalty = ChromossomeStrategy.calculatePenalty(chromossome);
            fitness = ChromossomeStrategy.calculatesFitness(penalty);
        }
        

    }
}
