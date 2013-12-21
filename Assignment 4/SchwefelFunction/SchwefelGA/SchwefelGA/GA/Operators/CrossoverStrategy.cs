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

                    List<List<int>> offspring_a_gene = new List<List<int>>();
                    List<List<int>> offspring_b_gene = new List<List<int>>();

                    int crossoverpoint = _random.Next(0, sizeChromossome);
                    offspring_a_gene.AddRange(_parents[index].chromossome.GetRange(0, crossoverpoint));
                    offspring_a_gene.AddRange(_parents[index + 1].chromossome.GetRange(crossoverpoint, sizeChromossome - crossoverpoint));
                    offspring_b_gene.AddRange(_parents[index + 1].chromossome.GetRange(0, crossoverpoint));
                    offspring_b_gene.AddRange(_parents[index].chromossome.GetRange(crossoverpoint, sizeChromossome - crossoverpoint));

                    List<Individual> candidates = new List<Individual>();
                    candidates.Add(_parents[index]);
                    candidates.Add(_parents[index + 1]);
                    candidates.Add(new Individual(offspring_a_gene));
                    candidates.Add(new Individual(offspring_b_gene));

                    offspring.AddRange(ElitismStrategy.basicElitism(candidates, 2));
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
                    List<List<int>> offspring_a_gene = new List<List<int>>(_parents[index].chromossome);
                    List<List<int>> offspring_b_gene = new List<List<int>>(_parents[index + 1].chromossome);
                    int crossoverpoint = _random.Next(0, numberLists);
                    
                    List<int> allele = offspring_a_gene[crossoverpoint];
                    offspring_a_gene[crossoverpoint] = offspring_b_gene[crossoverpoint];
                    offspring_b_gene[crossoverpoint] = allele;

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

                    List<List<int>> offspring_a_gene = new List<List<int>>();
                    List<List<int>> offspring_b_gene = new List<List<int>>();

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

                    offspring_a_gene.AddRange(_parents[index].chromossome.GetRange(0, cp[0]));
                    offspring_a_gene.AddRange(_parents[index + 1].chromossome.GetRange(cp[0], cp[1] - cp[0] + 1));
                    if ((cp[1] + 1) <= sizeCode)
                        offspring_a_gene.AddRange(_parents[index].chromossome.GetRange(cp[1] + 1, sizeCode - cp[1] - 1));

                    offspring_b_gene.AddRange(_parents[index + 1].chromossome.GetRange(0, cp[0]));
                    offspring_b_gene.AddRange(_parents[index].chromossome.GetRange(cp[0], cp[1] - cp[0] + 1));
                    if ((cp[1] + 1) <= sizeCode)
                        offspring_b_gene.AddRange(_parents[index + 1].chromossome.GetRange(cp[1] + 1, sizeCode - cp[1] - 1));

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


        public static List<Individual> OneGen2(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        {
            List<Individual> offsprings = new List<Individual>();

            int numberLists = _parents[0].chromossome.Count(); // Count number of List<int>

            if (_selectionSize % 2 != 0)
            {
                offsprings.Add(_parents[_selectionSize - 1]);
            }

            for (int i = 0; i < (_selectionSize / 2); i++)
            {
                //double dice = _random.NextDouble();
                //if (dice <= _crossoverProbability)
                //{
                //    //Do crossover and generates offsprings
                //}
                //else
                //{
                //    //Mantain parents
                //}

                int index = i * 2;

                List<List<int>> offspring_a_gene = new List<List<int>>(_parents[index].chromossome);
                List<List<int>> offspring_b_gene = new List<List<int>>(_parents[index + 1].chromossome);
                int crossoverpoint = _random.Next(0, numberLists);
                List<int> allele = offspring_a_gene[crossoverpoint];

                offspring_a_gene[crossoverpoint] = offspring_b_gene[crossoverpoint];
                offspring_b_gene[crossoverpoint] = allele;
                List<Individual> candidates = new List<Individual>();
                candidates.Add(_parents[index]);
                candidates.Add(_parents[index + 1]);
                candidates.Add(new Individual(offspring_a_gene));
                candidates.Add(new Individual(offspring_b_gene));
                List<Individual> selected = new List<Individual>(ElitismStrategy.basicElitism(candidates, 2));
                offsprings.AddRange(selected);
            }

            return offsprings;
        }

        public static List<Individual> TwoPoints2(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        {
            List<Individual> offspring = new List<Individual>();

            int sizeCode = _parents[0].chromossome.Count();

            if (_selectionSize % 2 != 0)
            {
                offspring.Add(_parents[_selectionSize - 1]);
            }

            for (int i = 0; i < (_selectionSize / 2); i++)
            {
                int index = i * 2;

                List<List<int>> offspring_a_gene = new List<List<int>>();
                List<List<int>> offspring_b_gene = new List<List<int>>();

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

                offspring_a_gene.AddRange(_parents[index].chromossome.GetRange(0, cp[0]));
                offspring_a_gene.AddRange(_parents[index + 1].chromossome.GetRange(cp[0], cp[1] - cp[0] + 1));
                if ((cp[1] + 1) <= sizeCode)
                    offspring_a_gene.AddRange(_parents[index].chromossome.GetRange(cp[1] + 1, sizeCode - cp[1]));

                offspring_b_gene.AddRange(_parents[index + 1].chromossome.GetRange(0, cp[0]));
                offspring_b_gene.AddRange(_parents[index].chromossome.GetRange(cp[0], cp[1] - cp[0] + 1));
                if ((cp[1] + 1) <= sizeCode)
                    offspring_b_gene.AddRange(_parents[index + 1].chromossome.GetRange(cp[1] + 1, sizeCode - cp[1]));

                List<Individual> candidates = new List<Individual>();
                candidates.Add(_parents[index]);
                candidates.Add(_parents[index + 1]);
                candidates.Add(new Individual(offspring_a_gene));
                candidates.Add(new Individual(offspring_b_gene));

                offspring.AddRange(ElitismStrategy.basicElitism(candidates, 2));

            }

            return offspring;
        }   
    }
}
