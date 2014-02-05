using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    static public class ElitismStrategy
    {
        public static List<Individual> basicElitism(List<Individual> _population, int _elitismSize)
        {
            List<Individual> population = new List<Individual>(_population);
            List<double> populationFitness = new List<double>();

            foreach (Individual c in population)
                populationFitness.Add(c.fitness);

            Array acandidates = population.ToArray();
            Array acandidates_fitness = populationFitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            population = acandidates.OfType<Individual>().ToList();
            population.Reverse();
            population.RemoveRange(_elitismSize, population.Count() - _elitismSize);

            return population;
        }

        public static Individual getChampion(List<Individual> _population)
        {
            Individual champ;

            List<Individual> candidates = new List<Individual>();
            List<double> candidates_fitness = new List<double>();

            for (int i = 0; i < _population.Count(); i++)
            {
                candidates.Add(_population[i]);
                candidates_fitness.Add(_population[i].fitness);
            }

            Array acandidates = candidates.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            candidates = acandidates.OfType<Individual>().ToList();
            candidates.Reverse();
            champ = candidates[0];

            return champ;
        }



        private static bool AreEqual<T>(List<T> x, List<T> y)
        {
            // same list or both are null
            if (x == y)
            {
                return true;
            }

            // one is null (but not the other)
            if (x == null || y == null)
            {
                return false;
            }

            // count differs; they are not equal
            if (x.Count != y.Count)
            {
                return false;
            }

            for (int i = 0; i < x.Count; i++)
            {
                if (!x[i].Equals(y[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
