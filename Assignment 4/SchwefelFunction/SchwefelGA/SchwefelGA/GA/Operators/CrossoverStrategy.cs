using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class CrossoverStrategy
    {
        public static List<Individual> OnePoint(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        {
            List<Individual> offspring = new List<Individual>();
            
            int sizeChromossome = _parents[0].chromossome.Count();

            if (_selectionSize % 2 != 0)
            {
                offspring.Add(_parents[_selectionSize - 1]);
            }

            for (int i = 0; i < (_selectionSize / 2); i++)
            {
                double dice = _random.NextDouble();

                if (dice <= _crossoverProbability)
                {
                    //Do crossover and generates offsprings
                    int index = i * 2;

                    string offspring_a_gene = "";
                    string offspring_b_gene = "";

                    int crossoverpoint = _random.Next(0, sizeChromossome);

                    offspring_a_gene = ((_parents[(i * 2)]).chromossome).Substring(0, crossoverpoint);
                    offspring_b_gene = ((_parents[(i * 2) + 1]).chromossome).Substring(0, crossoverpoint);
                    offspring_a_gene += ((_parents[(i * 2) + 1]).chromossome).Substring(crossoverpoint, sizeChromossome - crossoverpoint);
                    offspring_b_gene += ((_parents[(i * 2)]).chromossome).Substring(crossoverpoint, sizeChromossome - crossoverpoint);
                    offspring.Add(new Individual(offspring_a_gene));
                    offspring.Add(new Individual(offspring_b_gene));
                }
                else
                {
                    //Mantain parents
                    int index = i * 2;
                    offspring.Add(_parents[index]);
                    offspring.Add(_parents[index + 1]);
                }
            }

            return offspring;
        }


        public static List<Individual> OneGen(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        {
            List<Individual> offsprings = new List<Individual>();
            
            int numberLists = _parents[0].chromossome.Count(); // Count number of List<int>

            if (_selectionSize % 2 != 0)
            {
                offsprings.Add(_parents[_selectionSize - 1]);
            }

            for (int i = 0; i < (_selectionSize / 2); i++)
            {
                double dice = _random.NextDouble();
                int index = i * 2;
                if (dice <= _crossoverProbability)
                {
                    string offspring_a_gene = (_parents[index].chromossome);
                    string offspring_b_gene = (_parents[index + 1].chromossome);
                    int crossoverpoint = _random.Next(0, numberLists);
                    
                    System.Text.StringBuilder strBuilderA = new System.Text.StringBuilder(offspring_a_gene);
                    strBuilderA[crossoverpoint] = offspring_b_gene[crossoverpoint];
                    offspring_a_gene = strBuilderA.ToString();

                    System.Text.StringBuilder strBuilderB = new System.Text.StringBuilder(offspring_b_gene);
                    strBuilderB[crossoverpoint] = offspring_a_gene[crossoverpoint];
                    offspring_b_gene = strBuilderB.ToString();

                    offsprings.Add(new Individual(offspring_a_gene));
                    offsprings.Add(new Individual(offspring_b_gene));
                }
                else
                {
                    offsprings.Add(_parents[index]);
                    offsprings.Add(_parents[index+1]);
                } 
            }

            return offsprings;
        }

        public static List<Individual> TwoPoints(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        {
            List<Individual> offspring = new List<Individual>();

            int sizeCode = _parents[0].chromossome.Count();

            if (_selectionSize % 2 != 0)
            {
                offspring.Add(_parents[_selectionSize - 1]);
            }

            for (int i = 0; i < (_selectionSize / 2); i++)
            {
                double dice = _random.NextDouble();
                if (dice <= _crossoverProbability)
                {
                    //Do crossover and generates offsprings
                    int index = i * 2;

                    string offspring_a_gene = "";
                    string offspring_b_gene = "";

                    List<int> cp = new List<int>();
                    cp.Add(_random.Next(0, sizeCode));
                    cp.Add(_random.Next(0, sizeCode));

                    while (cp[0] == cp[1])
                    {
                        cp.Clear();
                        cp.Add(_random.Next(0, sizeCode));
                        cp.Add(_random.Next(0, sizeCode));
                    }

                    cp.Sort();

                    offspring_a_gene = _parents[index].chromossome.Substring(0, cp[0]);
                    offspring_a_gene += _parents[index + 1].chromossome.Substring(cp[0], cp[1] - cp[0] + 1);
                    if ((cp[1] + 1) <= sizeCode)
                        offspring_a_gene += (_parents[index].chromossome.Substring(cp[1] + 1, sizeCode - cp[1] - 1));

                    offspring_b_gene = (_parents[index + 1].chromossome.Substring(0, cp[0]));
                    offspring_b_gene += (_parents[index].chromossome.Substring(cp[0], cp[1] - cp[0] + 1));
                    if ((cp[1] + 1) <= sizeCode)
                        offspring_b_gene += (_parents[index + 1].chromossome.Substring(cp[1] + 1, sizeCode - cp[1] - 1));

                    offspring.Add(new Individual(offspring_a_gene));
                    offspring.Add(new Individual(offspring_b_gene));
                }
                else
                {
                    //Mantain parents
                    int index = i * 2;
                    offspring.Add(_parents[index]);
                    offspring.Add(_parents[index + 1]);
                }

            }
            return offspring;
        }
    }
}
