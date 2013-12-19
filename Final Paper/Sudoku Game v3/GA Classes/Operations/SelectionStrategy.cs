using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    static public class SelectionStrategy
    {
        public static List<Chromossome> Tournament(List<Chromossome> _population, int _selectionSize, int _numberofPlayers, Random _random)
        {
            List<Chromossome> population = new List<Chromossome>(_population);
            List<Chromossome> players = new List<Chromossome>();
            List<Chromossome> parents = new List<Chromossome>();

            int dice;

            for (int i = 0; i < _selectionSize; i++)
            {
                players.Clear();
                for (int j = 0; j < _numberofPlayers; j++)
                {
                    dice = _random.Next(0, population.Count());
                    players.Add(population[dice]);
                }
                parents.Add(ElitismStrategy.basicElitism(players, 1)[0]);
            }

            return parents;
        }

        public static List<Chromossome> RouletteWheel(List<Chromossome> _population, int _selectionSize, Random _random)
        {
            List<Chromossome> parents = new List<Chromossome>();

            double total_fitness = 0;

            foreach (Chromossome c in _population)
                total_fitness += c.fitness;

            List<double> ps = new List<double>();
            List<double> psa = new List<double>();

            for (int i = 0; i < _population.Count(); i++)
            {
                ps.Add(_population[i].fitness / total_fitness);
                psa.Add(0.0);

                for (int j = 0; j <= i; j++)
                {
                    psa[i] += ps[j];
                }
            }

            double wheelCounter;

            for (int i = 0; i < _selectionSize; i++)
            {
                //wheelCounter = this.random.Next(Convert.ToInt32(Math.Floor(psa.Max())));
                wheelCounter = _random.NextDouble();
                for (int j = 0; j < _population.Count(); j++)
                {
                    if (wheelCounter <= psa[j])
                    {
                        parents.Add(_population[j]);
                        break;
                    }
                }
            }

            return parents;
        }

    }
}
