using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GA
    {
        /*Variables declaration*/

        /*Chromossomes paremeters variables*/
        public int min, max, res;
        /*GA paremeters variables*/
        public int popsize, numgenerations, elitism_counter;
        public bool ranking, elitism;
        public double probcrossover, probmutation;
        public int countcrossover, countmutation;
        public int selectionMethod, crossoverMethod, optimizationMethod;

        /*GA Lists variables*/
        public List<Chromossome> population;
        public List<Chromossome> elite;
        public List<Chromossome> parents;
        public List<Chromossome> offspring;

        public Chromossome champion;

        /*Random variables*/
        Random random;

        /*Constructors*/
        public GA(Random _random)
        {
            this.min = 0;
            this.max = 8;
            this.res = 0;

            this.popsize = 10;
            this.numgenerations = 4;
            this.elitism_counter = 5;
            this.probcrossover = 0.6;
            this.probmutation = 0.01;

            this.random = _random; 
        }

        public GA(int _min, int _max, int _res,
            int _popsize, int _numgenerations, double _probcrossover, double _probmutation, 
            bool _ranking, bool _elitism, int _elitism_counter, 
            int _selectionMethod, int _crossoverMethod, int _optimizationMethod, Random _random)
        {
            this.min = _min;
            this.max = _max;
            this.res = _res;

            this.popsize = _popsize;
            this.numgenerations = _numgenerations;
            this.probcrossover = _probcrossover;
            this.probmutation = _probmutation;

            this.ranking = _ranking;
            this.elitism = _elitism;
            this.elitism_counter = _elitism_counter;

            this.selectionMethod = _selectionMethod;
            this.crossoverMethod = _crossoverMethod;
            this.optimizationMethod = _optimizationMethod;
            this.random = _random;
        }

        public GA(int _min, int _max, int _res,
            int _popsize, int _numgenerations, double _probcrossover, double _probmutation, 
            bool _ranking, bool _elitism, int _elitism_counter, 
            Random _random)
        {
            this.min = _min;
            this.max = _max;
            this.res = _res;

            this.popsize = _popsize;
            this.numgenerations = _numgenerations;
            this.probcrossover = _probcrossover;
            this.probmutation = _probmutation;

            this.ranking = _ranking;
            this.elitism = _elitism;
            this.elitism_counter = _elitism_counter;

            this.random = _random;
        }

        /*GA Steps*/
        public void beginStep()
        {
            population = new List<Chromossome>();
            elite = new List<Chromossome>();
            parents = new List<Chromossome>();
            offspring = new List<Chromossome>();

            for (int i = 0; i < this.popsize; i++)
                population.Add(new Chromossome(this.min, this.max, this.res, this.random));
        }

        public void elitismStep()
        {
            List<Chromossome> candidates = new List<Chromossome>();
            List<double> candidates_fitness = new List<double>();

            for(int i=0; i<population.Count(); i++)
            {
                candidates.Add(population[i]);
                candidates_fitness.Add(population[i].fitness);
            }

            Array acandidates = candidates.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            candidates = acandidates.OfType<Chromossome>().ToList();
            //candidates_fitness = acandidates_fitness.OfType<double>().ToList();

            candidates.Reverse();
            //candidates_fitness.Reverse();

            champion = candidates[0];

            elite.Clear();
            for (int i = 0; i < elitism_counter; i++)
                elite.Add(candidates[i]);
        }

        public void elitismWithRankingStep()
        {
            List<Chromossome> candidates = new List<Chromossome>();
            List<double> candidates_fitness = new List<double>();

            for (int i = 0; i < population.Count(); i++)
            {
                candidates.Add(population[i]);
                candidates_fitness.Add(population[i].fitness);
            }

            Array acandidates = candidates.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            candidates = acandidates.OfType<Chromossome>().ToList();
            //candidates_fitness = acandidates_fitness.OfType<double>().ToList();

            candidates.Reverse();
            //candidates_fitness.Reverse();

            elite.Clear();
            int score = candidates.Count();

            foreach (Chromossome c in candidates)
            {
                c.avaliationBasedOnRanking(score);
                score--;
            }

            population = candidates;

            for (int i = 0; i < elitism_counter; i++)
                elite.Add(population[i]);
        }

        public void selectionStep()
        {
            //roulette_wheel();
            tournament(2);
        }

        public void crossoverStep()
        {
            this.countcrossover = 0;
            one_point();
        }

        public void mutationStep()
        {
            this.countmutation = 0;
            singlebit();
        }

        public void updateStep()
        {
            foreach (Chromossome c in elite)
            {
                population.Add(c);
            }
        }

        /*Selection methods*/
        public void roulette_wheel()
        {
            double total_fitness = 0 ;

            foreach (Chromossome c in population)
                total_fitness += c.fitness;

            List<double> ps = new List<double>();
            List<double> psa = new List<double>();

            for (int i = 0; i < popsize; i++)
            {
                ps.Add(population[i].fitness / total_fitness);
                psa.Add(0.0);
                
                for (int j = 0; j <= i; j++)
                {
                    psa[i] += ps[j];
                }
            }
 
            double wheelCounter;

            this.parents.Clear();

            for (int i = 0; i < (this.popsize - this.elitism_counter); i++)
            {
                //wheelCounter = this.random.Next(Convert.ToInt32(Math.Floor(psa.Max())));
                wheelCounter = this.random.NextDouble();
                for (int j = 0; j < this.popsize; j++)
                {
                    if (wheelCounter <= psa[j])
                    {
                        this.parents.Add(population[j]);
                        break;
                    }
                }
            }
        }

        public void tournament(int n)
        {
            List<int> players_index = new List<int>();
            List<double> players_fitness = new List<double>();

            this.parents.Clear();
            int dice;

            if (n <= 1)
                n = 2;

            for (int i = 0; i < (this.popsize - this.elitism_counter); i++)
            {
                //Select players
                players_index.Clear();
                players_fitness.Clear();

                for (int j = 0; j < n; j++)
                {
                    dice = this.random.Next(0,this.population.Count());
                    players_index.Add(dice);
                    players_fitness.Add(population[dice].fitness);
                }

                Array aplayers_index = players_index.ToArray();
                Array aplayers_fitness = players_fitness.ToArray();
                Array.Sort(aplayers_fitness, aplayers_index);
                players_index = aplayers_index.OfType<int>().ToList();
                //players_fitness = aplayers_fitness.OfType<double>().ToList();
                players_index.Reverse();
                //players_fitness.Reverse();
                this.parents.Add(population[players_index[0]]);
            }
        }

        /*Crossover methods*/
        public void one_point()
        {
            double dice;
            int crossoverpoint;
            int size = population[0].nbits; ;
            string genes_offspring1, genes_offspring2;
            this.offspring.Clear();

            if (parents.Count() % 2 == 0) // Even number of parents
            {
                for (int i = 0; i < (parents.Count()/2); i++)
                {
                    dice = random.NextDouble();
                    if (dice <= this.probcrossover)
                    {
                        this.countcrossover++;
                        crossoverpoint = random.Next(0, size);
                        genes_offspring1 =  (parents[(i * 2)    ].code).Substring(0, crossoverpoint);
                        genes_offspring2 =  (parents[(i * 2) + 1].code).Substring(0, crossoverpoint);
                        genes_offspring1 += (parents[(i * 2) + 1].code).Substring(crossoverpoint, size - crossoverpoint);
                        genes_offspring2 += (parents[(i * 2)    ].code).Substring(crossoverpoint, size - crossoverpoint);
                        offspring.Add(new Chromossome(genes_offspring1, this.min, this.max, this.res, this.random));
                        offspring.Add(new Chromossome(genes_offspring2, this.min, this.max, this.res, this.random));
                    }
                    else
                    {
                        offspring.Add(parents[(i * 2)    ]);
                        offspring.Add(parents[(i * 2) + 1]);
                    }
                }
            }
            else //Odd number of parents
            {
                for (int i = 0; i < ((parents.Count() - 1) / 2); i++)
                {
                    dice = random.NextDouble();
                    if (dice <= this.probcrossover)
                    {
                        this.countcrossover++;
                        crossoverpoint = this.random.Next(0, size);
                        genes_offspring1 = (parents[(i * 2)].code).Substring(0, crossoverpoint);
                        genes_offspring2 = (parents[(i * 2) + 1].code).Substring(0, crossoverpoint);
                        genes_offspring1 += (parents[(i * 2) + 1].code).Substring(crossoverpoint, size - crossoverpoint);
                        genes_offspring2 += (parents[(i * 2)].code).Substring(crossoverpoint, size - crossoverpoint);
                        offspring.Add(new Chromossome(genes_offspring1, this.min, this.max, this.res, this.random));
                        offspring.Add(new Chromossome(genes_offspring2, this.min, this.max, this.res, this.random));
                    }
                    else
                    {
                        offspring.Add(parents[(i * 2)]);
                        offspring.Add(parents[(i * 2) + 1]);
                    }
                }
                offspring.Add(parents[parents.Count() - 1]);
            }
        }

        /*Mutation methods*/
        public void singlebit()
        {
            double dice;
            int mutationpoint;
            int size = population[0].nbits;;
            string genes_mutant = "";

            population.Clear();

            foreach (Chromossome c in offspring)
            {
                dice = this.random.NextDouble();
                if (dice <= this.probmutation)
                {
                    this.countmutation++;
                    mutationpoint = this.random.Next(0, size);
                    if ((c.code)[mutationpoint] == '0')
                    {
                        genes_mutant = (c.code).Substring(0, mutationpoint);
                        genes_mutant += '1';
                        genes_mutant += (c.code).Substring(mutationpoint + 1);
                    }
                    population.Add(new Chromossome(genes_mutant,this.min,this.max,this.res,this.random));
                }
                else
                {
                    population.Add(c);
                }
                
            }
        }

        /*Other methods*/
        public double getAverageValue()
        {
            double avgvalue=0;

            foreach(Chromossome c in population)
            {
                avgvalue += c.value;
            }

            avgvalue /= population.Count();

            return avgvalue;

        }

        public double getAverageResponse()
        {
            double avgresponse = 0;

            foreach (Chromossome c in population)
            {
                avgresponse += Equation.Fx(c.value);
            }

            avgresponse /= population.Count();

            return avgresponse;
        }

        public double getAverageFitness()
        {
            double avgfitness=0;

            foreach(Chromossome c in population)
            {
                avgfitness += c.fitness;
            }

            avgfitness /= population.Count();

            return avgfitness;
        }

        public Chromossome getChampion()
        {
            Chromossome champ;

            List<Chromossome> candidates = new List<Chromossome>();
            List<double> candidates_fitness = new List<double>();

            for(int i=0; i<population.Count(); i++)
            {
                candidates.Add(population[i]);
                candidates_fitness.Add(population[i].fitness);
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
