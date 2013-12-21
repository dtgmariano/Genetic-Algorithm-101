using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class MutationStrategy
    {
        /*Mutation method that swap subgrids of a chromossome*/
        public static List<Individual> Swap(List<Individual> _offsprings, double probabilityMutation, Random _random)
        {
            List<Individual> mutants = new List<Individual>();
            int size = _offsprings[0].chromossome.Count();

            foreach (Individual c in _offsprings)
            {
                if (_random.NextDouble() <= probabilityMutation)
                {
                    List<List<int>> mutant_gene = c.chromossome;

                    int swappoint1 = _random.Next(0, size);
                    int swappoint2 = _random.Next(0, size);
                    List<int> value = mutant_gene[swappoint1];
                    mutant_gene[swappoint1] = mutant_gene[swappoint2];
                    mutant_gene[swappoint2] = value;
                    mutants.Add(new Individual(mutant_gene));

                }
                else
                {
                    mutants.Add(c);
                }
            }

            return mutants;
        }

        public static List<Individual> Rand(List<Individual> _offsprings, double probabilityMutation, Random _random)
        {
            List<Individual> mutants = new List<Individual>();
            int size = _offsprings[0].chromossome.Count();

            foreach (Individual c in _offsprings)
            {
                //List<Chromossome> solutions = new List<Chromossome>();
                //solutions.Add(c);

                //List<int> mutant_gene = c.gene;

                //int swappoint1 = _random.Next(0, size);
                //int swappoint2 = _random.Next(0, size);
                //int value = mutant_gene[swappoint1];
                //mutant_gene[swappoint1] = mutant_gene[swappoint2];
                //mutant_gene[swappoint2] = value;
                //solutions.Add(new Chromossome(mutant_gene));

                //mutants.Add(ChampionStrategy.getChampion(solutions));

                if (_random.NextDouble() <= probabilityMutation)
                {
                    List<List<int>> mutant_gene = c.chromossome;
                    List<int> new_alelle = ChromossomeStrategy.generateSubGrid(_random);
                    int mutationpoint = _random.Next(0, size);
                    mutant_gene[mutationpoint] = new_alelle;
                    mutants.Add(new Individual(mutant_gene));

                }
                else
                {
                    mutants.Add(c);
                }
            }

            return mutants;
        }

        /*Mutation method that swap points of a subgrid of the chromossome*/
        public static List<Individual> Naka(List<Individual> _offsprings, double probabilityMutation, Random _random)
        {
            List<Individual> mutants = new List<Individual>();
            int size = _offsprings[0].chromossome.Count();

            foreach (Individual c in _offsprings)
            {
                if (_random.NextDouble() <= probabilityMutation)
                {
                    List<List<int>> mutant_gene = c.chromossome;
                    int mutationallele = _random.Next(0, size);
                    List<int> new_alelle = mutant_gene[mutationallele];

                    List<int> mp = new List<int>();
                    mp.Add(_random.Next(0, size));
                    mp.Add(_random.Next(0, size));
                    while (mp[0] == mp[1])
                    {
                        mp.Clear();
                        mp.Add(_random.Next(0, size));
                        mp.Add(_random.Next(0, size));
                    }
                    mp.Sort();

                    int value = new_alelle[mp[0]];
                    new_alelle[mp[0]] = new_alelle[mp[1]];
                    new_alelle[mp[1]] = value;

                    mutant_gene[mutationallele] = new_alelle;
                    mutants.Add(new Individual(mutant_gene));
                }
                else
                {
                    mutants.Add(c);
                }
            }

            return mutants;
        }

        public static List<Individual> Swaps(List<Individual> _offsprings, double probabilityMutation, Random _random)
        {
            List<Individual> mutants = new List<Individual>();
            int size = _offsprings[0].chromossome.Count();

            foreach (Individual c in _offsprings)
            {
                if (_random.NextDouble() <= probabilityMutation)
                {
                    List<List<int>> mutant_gene = c.chromossome;
                    int mutationallele = _random.Next(0, size);
                    List<int> new_alelle = mutant_gene[mutationallele];

                    List<int> mp = new List<int>();
                    mp.Add(_random.Next(0, size));
                    mp.Add(_random.Next(0, size));
                    while (mp[0] == mp[1])
                    {
                        mp.Clear();
                        mp.Add(_random.Next(0, size));
                        mp.Add(_random.Next(0, size));
                    }
                    mp.Sort();

                    int value = new_alelle[mp[0]];
                    new_alelle[mp[0]] = new_alelle[mp[1]];
                    new_alelle[mp[1]] = value;

                    mp.Clear();
                    mp.Add(_random.Next(0, size));
                    mp.Add(_random.Next(0, size));
                    while (mp[0] == mp[1])
                    {
                        mp.Clear();
                        mp.Add(_random.Next(0, size));
                        mp.Add(_random.Next(0, size));
                    }
                    mp.Sort();

                    value = new_alelle[mp[0]];
                    new_alelle[mp[0]] = new_alelle[mp[1]];
                    new_alelle[mp[1]] = value;

                    mp.Clear();
                    mp.Add(_random.Next(0, size));
                    mp.Add(_random.Next(0, size));
                    while (mp[0] == mp[1])
                    {
                        mp.Clear();
                        mp.Add(_random.Next(0, size));
                        mp.Add(_random.Next(0, size));
                    }
                    mp.Sort();

                    value = new_alelle[mp[0]];
                    new_alelle[mp[0]] = new_alelle[mp[1]];
                    new_alelle[mp[1]] = value;

                    mp.Clear();
                    mp.Add(_random.Next(0, size));
                    mp.Add(_random.Next(0, size));
                    while (mp[0] == mp[1])
                    {
                        mp.Clear();
                        mp.Add(_random.Next(0, size));
                        mp.Add(_random.Next(0, size));
                    }
                    mp.Sort();

                    value = new_alelle[mp[0]];
                    new_alelle[mp[0]] = new_alelle[mp[1]];
                    new_alelle[mp[1]] = value;

                    mutant_gene[mutationallele] = new_alelle;
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
