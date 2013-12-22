using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class MutationStrategy
    {
        public static List<Individual> InvertBit(List<Individual> _offsprings, double probabilityMutation, Random _random)
        {
            List<Individual> mutants = new List<Individual>();
            int size = _offsprings[0].chromossome.Length;

            foreach (Individual c in _offsprings)
            {
                if (_random.NextDouble() <= probabilityMutation)
                {
                    string mutant_gene = c.chromossome;

                    int swappoint = _random.Next(0, size);
                    if (mutant_gene[swappoint] == '1')
                    {
                        System.Text.StringBuilder strBuilderA = new System.Text.StringBuilder(mutant_gene);
                        strBuilderA[swappoint] = '0';
                        mutant_gene = strBuilderA.ToString();
                    }
                    else
                    {
                        System.Text.StringBuilder strBuilderA = new System.Text.StringBuilder(mutant_gene);
                        strBuilderA[swappoint] = '1';
                        mutant_gene = strBuilderA.ToString();
                    }
                    mutants.Add(new Individual(mutant_gene));
                }
                else
                {
                    mutants.Add(c);
                }
            }

            return mutants;
        }
    }
}
