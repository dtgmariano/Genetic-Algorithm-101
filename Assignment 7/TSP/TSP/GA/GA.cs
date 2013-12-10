using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GA
    {
        public World world;

        public int numberOfCities;

        public int popsize, numgenerations;
        public double probcrossover, probmutation;
        public Random random;

        public List<Chromossome> population;
        public List<Chromossome> elite;
        public List<Chromossome> parents;
        public List<Chromossome> offspring;
        public List<Chromossome> mutants;

        public Chromossome champion;
       
        public double elitismPctg;
        public bool elitismCheck;
        public int elitismCount;

        public int selectionMethod;
        public int crossoverMethod;
        public int mutationMethod;
        public int tournamentNumPlayers;

        /*Constructor*/
        public GA(World _world,
            int _popsize, int _numgenerations, double _probcrossover, double _probmutation, double _elitism_percentage,
            int _selec_op, int _cross_op, int _mutan_op, Random _random)
        {
            this.random = _random;
            this.world = _world;
            this.numberOfCities = world.citiesList.Count();

            this.popsize = _popsize;
            this.numgenerations = _numgenerations;
            this.probcrossover = _probcrossover;
            this.probmutation = _probmutation;

            this.elitismPctg = _elitism_percentage;
            this.elitismCount = Convert.ToInt32(Convert.ToDouble(this.popsize) * this.elitismPctg);

            this.selectionMethod = _selec_op;
            this.crossoverMethod = _cross_op;
            this.mutationMethod = _mutan_op;
        }

        #region Start Methods

        public void beginStep()
        {
            population = startPopulation();
            champion = getChampion(population);
            parents = new List<Chromossome>();
            offspring = new List<Chromossome>();
        }

        public List<Chromossome> startPopulation()
        {
            List<Chromossome> population = new List<Chromossome>();
            for (int i = 0; i < this.popsize; i++)
                population.Add(new Chromossome(this.world.citiesList, this.random));
            return population;
        }

        #endregion

        #region Elitism Methods
        public void elitismStep()
        {
            elite = basicElitism(this.population, this.elitismCount);
        }

        public List<Chromossome> basicElitism(List<Chromossome> _population, int _elitismCount)
        {
            List<Chromossome> population = _population;
            List<double> populationFitness = new List<double>();

            for (int i = 0; i < population.Count(); i++)
                populationFitness.Add(population[i].fitness);

            Array acandidates = population.ToArray();
            Array acandidates_fitness = populationFitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            population = acandidates.OfType<Chromossome>().ToList();
            population.Reverse();
            population.RemoveRange(elitismCount, population.Count() - elitismCount);

            return population;
        }
        #endregion

        #region Selection Methods
        /*Selection methods*/
        public void selectionStep()
        {
            switch (selectionMethod)
            {
                case 0:
                    {
                        rouletteWheel();
                        break;
                    }
                case 1:
                    {
                        tournament(tournamentNumPlayers);
                        break;
                    }
                default:
                    {
                        rouletteWheel();
                        break;
                    }
            }
        }

        public void rouletteWheel()
        {
            double total_fitness = 0;

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

            for (int i = 0; i < (this.popsize - this.elitismCount); i++)
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

            for (int i = 0; i < (this.popsize - this.elitismCount); i++)
            {
                //Select players
                players.Clear();
                for (int j = 0; j < n; j++)
                {
                    dice = this.random.Next(0, this.population.Count());
                    players.Add(population[dice]);
                }
                if (players.Count() == 0)
                {
                }
                this.parents.Add(getChampion(players));
            }
        }
        #endregion

        #region Crossover Methods
        public void crossoverStep()
        {
            double dice;

            offspring.Clear();

            if (parents.Count() % 2 == 0) // Even number of parents
            {
                for (int i = 0; i < (parents.Count() / 2); i++)
                {
                    dice = this.random.NextDouble();
                    if (dice <= this.probcrossover)
                    {
                        offspring.Add(onepointProcedure(parents[i * 2], parents[i * 2 + 1]));
                        offspring.Add(onepointProcedure(parents[i * 2 + 1], parents[i * 2]));
                    }
                    else
                    {
                        offspring.Add(parents[i * 2]);
                        offspring.Add(parents[i * 2 + 1]);
                    }
                }
            }
            else // Odd number of parents
            {
                for (int i = 0; i < ((parents.Count() - 1 )/ 2); i++)
                {
                    dice = this.random.NextDouble();
                    if (dice <= this.probcrossover)
                    {
                        offspring.Add(onepointProcedure(parents[i * 2], parents[i * 2 + 1]));
                        offspring.Add(onepointProcedure(parents[i * 2 + 1], parents[i * 2]));
                    }
                    else
                    {
                        offspring.Add(parents[i * 2]);
                        offspring.Add(parents[i * 2 + 1]);
                    }
                }
                offspring.Add(parents[parents.Count() - 1]);
            }
        }

        public Chromossome onepointProcedure(Chromossome A, Chromossome B)
        {
            int stopCondition = 0;
            List<City> newCode = new List<City>(A.code);
            
            while (stopCondition <= 100000)
            {
                int crossoverpoint = random.Next(0, A.code.Count());
                newCode.Clear();

                for (int i = 0; i < crossoverpoint; i++)
                    newCode.Add(A.code[i]);
                for (int i = crossoverpoint; i < B.code.Count(); i++)
                    newCode.Add(B.code[i]);

                if (validateChromossomeCode(newCode) == false)
                {
                    stopCondition++;
                    newCode = new List<City>(A.code);
                }
                else
                {
                    break;
                }
            }

            Chromossome newOffspring = new Chromossome(newCode, world.citiesList, random);
            return newOffspring;
        }

        public bool validateChromossomeCode(List<City> _code)
        {
            bool isValid = false;
            int check = 0;

            for (int i = 0; i < _code.Count(); i++)
            {
                for (int j = i; j < _code.Count(); j++)
                {
                    if (_code[i].id != _code[j].id)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
        #endregion

        #region Other Methods
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
        #endregion  

    }
}