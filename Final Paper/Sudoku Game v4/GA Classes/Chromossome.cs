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

        public List<List<int>> gene;

        public double fitness;
        public int penalty;

        public Chromossome(Random _random)
        {
            gene = ChromossomeStrategy.generateGenes(_random);
            penalty = ChromossomeStrategy.calculatePenalty(gene);
            fitness = ChromossomeStrategy.calculateFitness(penalty);
        }

        public Chromossome(List<List<int>> _gene)
        {
            gene = _gene;
            penalty = ChromossomeStrategy.calculatePenalty(gene);
            fitness = ChromossomeStrategy.calculateFitness(penalty);
        }

    }
}
