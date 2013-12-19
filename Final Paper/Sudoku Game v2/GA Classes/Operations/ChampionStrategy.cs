using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class ChampionStrategy
    {
        public static Chromossome getChampion(List<Chromossome> _population)
        {
            Chromossome champ;

            List<Chromossome> candidates = new List<Chromossome>();
            List<double> candidates_fitness = new List<double>();

            for (int i = 0; i < _population.Count(); i++)
            {
                candidates.Add(_population[i]);
                candidates_fitness.Add(_population[i].fitness);
            }

            Array acandidates = candidates.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            candidates = acandidates.OfType<Chromossome>().ToList();
            candidates.Reverse();
            champ = candidates[0];

            return champ;
        }

    }
}
