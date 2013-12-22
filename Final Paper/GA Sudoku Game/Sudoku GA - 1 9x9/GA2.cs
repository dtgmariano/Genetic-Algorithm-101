﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GA2
    {
        /*Variables declaration*/

        /*GA paremeters variables*/
        public int popsize, numgenerations, elitism_counter;
        public double elitism_percentage;
        public bool hasRanking, hasElitism;
        public double probcrossover, probmutation;
        public int countcrossover, countmutation;
        public int selectionMethod, crossoverMethod, mutationMethod;

        /*GA Lists variables*/
        public List<Individual2> population;
        public List<Individual2> elite;
        public List<Individual2> parents;
        public List<Individual2> offspring;
        public List<Individual2> mutant;
        public Individual2 champion;

        /*Random variables*/
        Random random;

        /*Constructors*/
        public GA2(int _popsize, int _numgenerations, double _probcrossover, double _probmutation,
            double _elitism_percentage, int _selec_op, int _cross_op, int _mutan_op, Random _random)
        {
           
            this.popsize = _popsize;
            this.numgenerations = _numgenerations;
            this.probcrossover = _probcrossover;
            this.probmutation = _probmutation;

            this.elitism_percentage = _elitism_percentage;
            this.elitism_counter = Convert.ToInt32(Convert.ToDouble(this.popsize) * this.elitism_percentage);

            this.selectionMethod = _selec_op;
            this.crossoverMethod = _cross_op;
            this.mutationMethod = _mutan_op;

            this.random = _random;
        }

        /*GA Processes*/
        public void processesGA()
        {
            elitismStep();
            selectionStep();
            crossoverStep();
            mutationStep();
            updateStep();
        }

        /*GA Steps*/
        public void beginStep()
        {
            population = new List<Individual2>();
            elite = new List<Individual2>();
            parents = new List<Individual2>();
            offspring = new List<Individual2>();
            mutant = new List<Individual2>();

            for (int i = 0; i < this.popsize; i++)
                population.Add(new Individual2(this.random));
            champion = getChampion(population);
        }

        public void elitismStep()
        {
            if (hasElitism == true)
            {
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
            foreach (Individual2 c in mutant)
                population.Add(c);
            foreach (Individual2 c in elite)
                population.Add(c);
            champion = getChampion(population);
        }

        /*Elitism methods*/
        public void basicElitism()
        {
            List<Individual2> candidates = new List<Individual2>();
            List<double> candidates_fitness = new List<double>();

            for (int i = 0; i < population.Count(); i++)
            {
                candidates.Add(population[i]);
                candidates_fitness.Add(population[i].fitness);
            }

            Array acandidates = candidates.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            candidates = acandidates.OfType<Individual2>().ToList();
            //candidates_fitness = acandidates_fitness.OfType<double>().ToList();

            candidates.Reverse();
            //candidates_fitness.Reverse();

            champion = candidates[0];

            elite.Clear();
            for (int i = 0; i < elitism_counter; i++)
                elite.Add(candidates[i]);
        }


        /*Selection methods*/
        public void roulette_wheel()
        {
            double total_fitness = 0;

            foreach (Individual2 c in population)
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
            List<Individual2> players = new List<Individual2>();
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
                    dice = this.random.Next(0, this.population.Count());
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
            int size = population[0].gene.Count();
            List<int> genes_offspring1 = new List<int>();
            List<int> genes_offspring2 = new List<int>();

            this.offspring.Clear();

            if (parents.Count() % 2 == 0) // Even number of parents
            {
                for (int i = 0; i < (parents.Count() / 2); i++)
                {
                    dice = random.NextDouble();
                    genes_offspring1.Clear();
                    genes_offspring2.Clear();
                    if (dice <= this.probcrossover)
                    {
                        this.countcrossover++;
                        crossoverpoint = random.Next(0, size);

                        genes_offspring1.AddRange(parents[(i * 2)].gene.GetRange(0, crossoverpoint));
                        genes_offspring1.AddRange(parents[(i * 2) + 1].gene.GetRange(crossoverpoint, size - crossoverpoint));
                        genes_offspring2.AddRange(parents[(i * 2) + 1].gene.GetRange(0, crossoverpoint));
                        genes_offspring2.AddRange(parents[(i * 2)].gene.GetRange(crossoverpoint, size - crossoverpoint));

                        offspring.Add(new Individual2(genes_offspring1));
                        offspring.Add(new Individual2(genes_offspring2));
                    }
                    else
                    {
                        offspring.Add(parents[(i * 2)]);
                        offspring.Add(parents[(i * 2) + 1]);
                    }
                }
            }
            else //Odd number of parents
            {
                for (int i = 0; i < ((parents.Count() - 1) / 2); i++)
                {
                    dice = random.NextDouble();
                    genes_offspring1.Clear();
                    genes_offspring2.Clear();
                    if (dice <= this.probcrossover)
                    {
                        this.countcrossover++;
                        crossoverpoint = random.Next(0, size);
                        genes_offspring1.AddRange(parents[(i * 2)].gene.GetRange(0, crossoverpoint));
                        genes_offspring1.AddRange(parents[(i * 2) + 1].gene.GetRange(crossoverpoint, size - crossoverpoint));
                        genes_offspring2.AddRange(parents[(i * 2) + 1].gene.GetRange(0, crossoverpoint));
                        genes_offspring2.AddRange(parents[(i * 2)].gene.GetRange(crossoverpoint, size - crossoverpoint));

                        offspring.Add(new Individual2(genes_offspring1));
                        offspring.Add(new Individual2(genes_offspring2));
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
            int size = population[0].gene.Count();
            List<int> genes_mutant = new List<int>();

            mutant.Clear();

            //foreach (Chromossome c in offspring)
            //{
            //    dice = this.random.NextDouble();
            //    if (dice <= this.probmutation)
            //    {
            //        this.countmutation++;
            //        mutationpoint = this.random.Next(0, size);
            //        genes_mutant.AddRange(c.gene.GetRange(0, mutationpoint));
            //        //genes_mutant.Add(this.random.Next(0,size

                    
            //        mutant.Add(new Chromossome(genes_mutant));
            //    }
            //    else
            //    {
            //        mutant.Add(c);
            //    }

            //}

            mutant = new List<Individual2>(offspring);
        }


        public double getAverageFitness()
        {
            double avgfitness = 0;

            foreach (Individual2 c in population)
            {
                avgfitness += c.fitness;
            }

            avgfitness /= population.Count();

            return avgfitness;
        }

        public Individual2 getChampion(List<Individual2> _population)
        {
            Individual2 champ;

            List<Individual2> candidates = new List<Individual2>();
            List<double> candidates_fitness = new List<double>();

            for (int i = 0; i < _population.Count(); i++)
            {
                candidates.Add(_population[i]);
                candidates_fitness.Add(_population[i].fitness);
            }

            Array acandidates = candidates.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            candidates = acandidates.OfType<Individual2>().ToList();
            candidates.Reverse();
            champ = candidates[0];

            return champ;
        }

    }
}