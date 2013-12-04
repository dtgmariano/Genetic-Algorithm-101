using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GA
    {
        /*Chromossomes Paremeters Variables*/
        public int min, max, res;

        /*GA Parameters Variables*/
        public int popsize, numgenerations, elitism_counter;
        public double probcrossover, probmutation;

        /*GA Lists Variables*/
        public List<Chromossome> population;
        public List<Chromossome> elite;
        public List<Chromossome> parents;


        public List<string> population_values;
        public List<string> elite_population_values;
        public List<string> selec_population_values;
        public List<string> co_population_values;
        public List<string> mt_population_values;

        public List<double> population_fitness;
        public List<double> elite_population_fitness;
        public List<double> selec_population_fitness;
        public List<double> co_population_fitness;
        public List<double> mt_population_fitness;
        
        
        /*Random Variable*/
        Random random;

        public GA()
        {
            
        }

        public GA(Random _random)
        {
            this.min = 0;
            this.max = 15;
            this.res = 0;

            this.popsize = 10;
            this.numgenerations = 4;
            this.elitism_counter = 4;
            this.probcrossover = 0.6;
            this.probmutation = 0.01;

            this.random = _random; 
        }

        /*GA Steps*/
        public void beginStep()
        {
            population = new List<Chromossome>();
            elite = new List<Chromossome>();
            parents = new List<Chromossome>();

            for (int i = 0; i < this.popsize; i++)
                population.Add(new Chromossome(this.min, this.max, this.res, this.random));
        }

        public void elitismStep()
        {
            List<int> candidates_index = new List<int>();
            List<double> candidates_fitness = new List<double>();

            for(int i=0; i<population.Count(); i++)
            {
                candidates_index.Add(i);
                candidates_fitness.Add(population[i].fitness);
            }

            Array acandidates_index = candidates_index.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates_index);

            candidates_index = acandidates_index.OfType<int>().ToList();
            //candidates_fitness = acandidates_fitness.OfType<double>().ToList();

            candidates_index.Reverse();
            //candidates_fitness.Reverse();

            elite.Clear();
            for (int i = 0; i < elitism_counter; i++)
                elite.Add(population[candidates_index[i]]);
        }

        public void selectionStep()
        {
            roulette_wheel();
        }

        public void crossoverStep()
        { 
        }

        public void mutationStep()
        {
        }

        public void updateStep()
        { 
        }

        /*Selection Methods*/
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


    }
}
