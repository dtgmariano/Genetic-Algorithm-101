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
        public double elitism_percentage;
        public bool hasRanking, hasElitism;
        public double probcrossover, probmutation;
        public int countcrossover, countmutation;
        public int selectionMethod, crossoverMethod, mutationMethod, optimizationMethod;

        /*GA Lists variables*/
        public List<Chromossome> population;
        public List<Chromossome> elite;
        public List<Chromossome> parents;
        public List<Chromossome> offspring;
        public List<Chromossome> mutant;
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
            bool _ranking, bool _elitism, double _elitism_percentage, 
            Random _random)
        {
            this.min = _min;
            this.max = _max;
            this.res = _res;

            this.popsize = _popsize;
            this.numgenerations = _numgenerations;
            this.probcrossover = _probcrossover;
            this.probmutation = _probmutation;

            this.hasRanking = _ranking;
            this.hasElitism = _elitism;
            this.elitism_percentage = _elitism_percentage;
            this.elitism_counter = Convert.ToInt32(Convert.ToDouble(this.popsize) * this.elitism_percentage);

            this.random = _random;
        }

        public GA(int _min, int _max, int _res, 
            int _popsize, int _numgenerations, double _probcrossover, double _probmutation,
            bool _ranking, bool _elitism, double _elitism_percentage, 
            int _selec_op, int _cross_op, int _mutan_op, int _optim_op,
            Random _random)
        {
            this.min = _min;
            this.max = _max;
            this.res = _res;

            this.popsize = _popsize;
            this.numgenerations = _numgenerations;
            this.probcrossover = _probcrossover;
            this.probmutation = _probmutation;

            this.hasRanking = _ranking;
            this.hasElitism = _elitism;
            this.elitism_percentage = _elitism_percentage;
            this.elitism_counter = Convert.ToInt32(Convert.ToDouble(this.popsize) * this.elitism_percentage);

            this.selectionMethod = _selec_op;
            this.crossoverMethod = _cross_op;
            this.mutationMethod = _mutan_op;
            this.optimizationMethod = _optim_op;

            this.random = _random;
        }

        /*GA Processes*/
        public void processesGA()
        {
            rankingStep();
            elitismStep();
            selectionStep();
            crossoverStep();
            mutationStep();
            updateStep();
        }

        /*GA Steps*/
        public void beginStep()
        {
            population = new List<Chromossome>();
            elite = new List<Chromossome>();
            parents = new List<Chromossome>();
            offspring = new List<Chromossome>();
            mutant = new List<Chromossome>();

            for (int i = 0; i < this.popsize; i++)
                population.Add(new Chromossome(this.min, this.max, this.res, this.optimizationMethod, this.random));
            if (population.Count() == 0)
            {
            }
            champion = getChampion(population);
        }

        public void rankingStep()
        {
            if (hasRanking == true)
                linearRanking(); 
        }

        public void elitismStep()
        {
            if (hasElitism == true)
            {
                if (hasRanking == true)
                    rankingElitism();
                else
                    basicElitism();
            }
        }

        public void selectionStep()
        {
            switch (selectionMethod)
            {
                case 0:
                    {
                        roulette_wheel();
                        break;
                    }
                case 1:
                    {
                        tournament(3);
                        break;
                    }
                default:
                    {
                        roulette_wheel();
                        break;
                    }

            }
        }

        public void crossoverStep()
        {
            this.countcrossover = 0;
            switch (crossoverMethod)
            {
                case 0:
                    {
                        one_point();
                        break;
                    }
                default:
                    {
                        one_point();
                        break;
                    }

            }
        }

        public void mutationStep()
        {
            this.countmutation = 0;
            switch (mutationMethod)
            {
                case 0:
                    {
                        singlebit();
                        break;
                    }
                default:
                    {
                        singlebit();
                        break;
                    }
            }
        }

        public void updateStep()
        {
            population.Clear();
            foreach (Chromossome c in mutant)
                population.Add(c);
            foreach (Chromossome c in elite)
                population.Add(c);
            if (population.Count() == 0)
            {
            }
            champion = getChampion(population);
        }

        /*Ranking Methods*/
        public void linearRanking()
        {
            List<double> population_fitness = new List<double>();

            for (int i = 0; i < population.Count(); i++)
            {
                population_fitness.Add(population[i].fitness);
            }

            Array apopulation = population.ToArray();
            Array apopulation_fitness = population_fitness.ToArray();
            Array.Sort(apopulation_fitness, apopulation);

            population = apopulation.OfType<Chromossome>().ToList();
            //candidates_fitness = acandidates_fitness.OfType<double>().ToList();

            population.Reverse();
            //candidates_fitness.Reverse();

            elite.Clear();
            int score = population.Count();

            foreach (Chromossome c in population)
            {
                c.avaliationBasedOnRanking(score);
                score--;
            }
        }

        /*Elitism methods*/
        public void basicElitism()
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

            if (candidates[0].code == "")
                Console.WriteLine("");

            champion = candidates[0];

            elite.Clear();
            for (int i = 0; i < elitism_counter; i++)
                elite.Add(candidates[i]);
        }

        public void rankingElitism()
        {
            elite.Clear();
            for (int i = 0; i < elitism_counter; i++)
                elite.Add(population[i]);
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
            List<Chromossome> players = new List<Chromossome>();
            int dice;

            if (n <= 1)
                n = 2;

            this.parents.Clear();

            for (int i = 0; i < (this.popsize - this.elitism_counter); i++)
            {
                //Select players
                players.Clear();
                for (int j = 0; j < n; j++)
                {
                    dice = this.random.Next(0,this.population.Count());
                    players.Add(population[dice]);
                }
                if (players.Count() == 0)
                {
                }
                this.parents.Add(getChampion(players));
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
                        genes_offspring1 =  ((parents[(i * 2)    ]).code).Substring(0, crossoverpoint);
                        genes_offspring2 =  ((parents[(i * 2) + 1]).code).Substring(0, crossoverpoint);
                        genes_offspring1 += ((parents[(i * 2) + 1]).code).Substring(crossoverpoint, size - crossoverpoint);
                        genes_offspring2 += ((parents[(i * 2)    ]).code).Substring(crossoverpoint, size - crossoverpoint);
                        offspring.Add(new Chromossome(genes_offspring1, this.min, this.max, this.res, this.optimizationMethod, this.random));
                        offspring.Add(new Chromossome(genes_offspring2, this.min, this.max, this.res, this.optimizationMethod, this.random));
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
                        genes_offspring1 = ((parents[(i * 2)]).code).Substring(0, crossoverpoint);
                        genes_offspring2 = ((parents[(i * 2) + 1]).code).Substring(0, crossoverpoint);
                        genes_offspring1 += ((parents[(i * 2) + 1]).code).Substring(crossoverpoint, size - crossoverpoint);
                        genes_offspring2 += ((parents[(i * 2)]).code).Substring(crossoverpoint, size - crossoverpoint);
                        offspring.Add(new Chromossome(genes_offspring1, this.min, this.max, this.res, this.optimizationMethod, this.random));
                        offspring.Add(new Chromossome(genes_offspring2, this.min, this.max, this.res, this.optimizationMethod, this.random));
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

            mutant.Clear();

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
                    else
                    {
                        genes_mutant = (c.code).Substring(0, mutationpoint);
                        genes_mutant += '0';
                        genes_mutant += (c.code).Substring(mutationpoint + 1);
                    }
                    mutant.Add(new Chromossome(genes_mutant, this.min, this.max, this.res, this.optimizationMethod, this.random));
                }
                else
                {
                    mutant.Add(c);
                }
                
            }
        }

        /*Other methods*/
        public double getAverageValue()
        {
            double avgvalue=0;

            foreach(Chromossome c in population)
            {
                avgvalue += c.x;
            }

            avgvalue /= population.Count();

            return avgvalue;

        }

        public double getAverageResponse()
        {
            double avgresponse = 0;

            foreach (Chromossome c in population)
            {
                avgresponse += Equation.Fx(c.x);
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

        //public Chromossome getChampion()
        //{
        //    Chromossome champ;

        //    List<Chromossome> candidates = new List<Chromossome>();
        //    List<double> candidates_fitness = new List<double>();

        //    for(int i=0; i<population.Count(); i++)
        //    {
        //        candidates.Add(population[i]);
        //        candidates_fitness.Add(population[i].fitness);
        //    }

        //    Array acandidates = candidates.ToArray();
        //    Array acandidates_fitness = candidates_fitness.ToArray();
        //    Array.Sort(acandidates_fitness, acandidates);

        //    candidates = acandidates.OfType<Chromossome>().ToList();
        //    candidates.Reverse();
        //    champ = candidates[0];

        //    return champ;
        //}

        public Chromossome getChampion(List<Chromossome> _population)
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
