using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiolabLibraries;

namespace GA
{
    public class GA
    {
        #region Variables
        /*GA Parameters Variables*/
        public int popsize, numgenerations;
        private double probcrossover, probmutation;
        private int sizeElite, sizeSelection;

        /*GA Lists Variables*/
        public List<Chromossome> population;
        public List<Chromossome> elite;
        public List<Chromossome> parents;
        public List<Chromossome> offsprings;
        public Chromossome champion;

        /*Solution Universe*/
        public List<String> U;

        /*Maintenance of equipments variables*/
        
        public int numEquip_demand;
        public int numEquip_total;
        public double percentageEquip_reserve;
        public int numIntervals;
        public int numServIntervals;

        /*Random variable*/
        Random random;
        #endregion

        #region Class Constructor
        /*Constructor*/
        public GA(int _numEquip_total, int _numEquip_demand, double _percentageEquip_reserve,  int _numIntervals, int _numServIntervals, int _popsize, int _numgenerations, Random _random)
        {
            /*GA Parameters Variables*/
            this.popsize = _popsize;
            this.numgenerations = _numgenerations;
            this.probcrossover = 0.6;
            this.probmutation = 0.01;
            this.sizeElite = 0;
            this.sizeSelection = this.popsize - this.sizeElite;

            /*GA Lists Variables*/
            this.population = new List<Chromossome>();
            this.elite = new List<Chromossome>();
            this.parents = new List<Chromossome>();
            this.offsprings = new List<Chromossome>();

            /*Equipments variables*/
            this.numEquip_total = _numEquip_total;
            this.numEquip_demand = _numEquip_demand;
            this.percentageEquip_reserve = _percentageEquip_reserve;
            this.numIntervals = _numIntervals;
            this.numServIntervals = _numServIntervals;

            this.U = Settings.generateSampleSpace(this.numIntervals, this.numServIntervals);

            /*Random variable*/
            this.random = _random;
        }
        #endregion

        public void BeginStep()
        {
            this.population = generatesRandomPopulation(this.U);
        }

        public void EliteStep()
        {
            this.elite = getElite(this.population, this.sizeElite);
        }

        public void SelectionStep()
        {
            this.parents = tournament(this.population, this.sizeSelection, 2, this.random);
        }

        public void CrossoverStep()
        {
            this.offsprings = crossover(this.parents, this.sizeSelection, this.random);
        }

        public void MutationStep()
        {
            /*Mutation to be implemented*/
        }

        public void NextGenerationStep()
        {
            this.population = getNextGeneration(this.elite, this.offsprings);
        }


        /*Initiates population*/
        public List<Chromossome> generatesRandomPopulation(List<string> U)
        {
            List<Chromossome> population = new List<Chromossome>();

            for(int i=0; i< popsize; i++)
                population.Add(new Chromossome(this.numEquip_total, this.numIntervals, U, this.random));

            return population;
        }

        /*Selects the elite of the population*/
        public List<Chromossome> getElite(List<Chromossome> _population, int _sizeElite)
        {
            List<Chromossome> elite = new List<Chromossome>(_population);
            List<double> elite_fitness = new List<double>();

            foreach(Chromossome c in elite)
            {
                elite_fitness.Add(c.fitness);
            }

            Array acandidates = elite.ToArray();
            Array acandidates_fitness = elite_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            elite = acandidates.OfType<Chromossome>().ToList();
            elite.Reverse();
            this.champion = elite[0];
            elite.RemoveRange(_sizeElite, elite.Count - _sizeElite);

            return elite;
        }

        /*Selects the parents based on tournament method*/
        public List<Chromossome> tournament(List<Chromossome> _population, int _sizeSelection, int _sizeTournament, Random _random)
        {
            List<Chromossome> selection = new List<Chromossome>();
            List<Chromossome> players = new List<Chromossome>();

            for (int i = 0; i < _sizeSelection; i++)
            {
                players.Clear();
                for (int j = 0; j < _sizeTournament; j++)
                    players.Add(_population[_random.Next(0, _population.Count())]);

                selection.Add(getElite(players, 1)[0]);
            }
            return selection;
        }

        /**/
        public List<Chromossome> crossover(List<Chromossome> _parents, int _sizeSelection, Random _random)
        {
            List<Chromossome> offspring = new List<Chromossome>();

            List<Chromossome> parentsCouple = new List<Chromossome>();
            List<Chromossome> offspringCouple;

            if (_sizeSelection % 2 == 0) //even numer of parents
            {
                for (int i = 0; i < _sizeSelection / 2; i++)
                {
                    parentsCouple.Clear();
                    parentsCouple.Add(_parents[i * 2]);
                    parentsCouple.Add(_parents[i * 2 + 1]);
                    offspringCouple = onepoint(parentsCouple, 10, this.random);
                    offspring.Add(offspringCouple[0]);
                    offspring.Add(offspringCouple[1]);
                }
            }
            else //odd numer of parents
            {
                for (int i = 0; i < ( _sizeSelection - 1 ) / 2; i++)
                {
                    parentsCouple.Clear();
                    parentsCouple.Add(_parents[i * 2]);
                    parentsCouple.Add(_parents[i * 2 + 1]);
                    offspringCouple = onepoint(parentsCouple, 10, this.random);
                    offspring.Add(offspringCouple[0]);
                    offspring.Add(offspringCouple[1]);
                }
                offspring.Add(_parents[_sizeSelection - 1]);
            }

            return offspring;
        }

        /*Crossover based on onepoint method*/
        public List<Chromossome> onepoint(List<Chromossome> _couple, int attemptsTolerance, Random _random)
        {
            List<Chromossome> pairParents = new List<Chromossome>(_couple);
            List<Chromossome> pairOffsprings = new List<Chromossome>(_couple);

            int crossoverPoint;

            for (int i = 0; i < attemptsTolerance; i++)
            {
                crossoverPoint = this.random.Next(0, pairParents[0].gene.Count());
                List<string> offspring1_gene = new List<string>();
                List<string> offspring2_gene = new List<string>();

                /*Crossover of 1 points process generates offsprings*/
                for (int j = 0; j < crossoverPoint; j++)
                {
                    offspring1_gene.Add(pairParents[0].gene[j]);
                    offspring2_gene.Add(pairParents[1].gene[j]);
                }


                for (int j = crossoverPoint; j < pairParents[1].gene.Count(); j++)
                {
                    offspring1_gene.Add(pairParents[1].gene[j]);
                    offspring2_gene.Add(pairParents[0].gene[j]);
                }

                /*Offspring validation*/
                if (Validator.geneIsValid(offspring1_gene) == true && Validator.geneIsValid(offspring2_gene) == true)
                {
                    pairOffsprings.Clear();
                    pairOffsprings.Add(new Chromossome(offspring1_gene, this.numEquip_total, this.random));
                    pairOffsprings.Add(new Chromossome(offspring2_gene, this.numEquip_total, this.random));
                    break;
                } 
            }
            return pairOffsprings;
        }

        /*Mutation based on one gene method*/
        public Chromossome onebit(Chromossome _offspring, Random _random)
        {
            Chromossome mutant = new Chromossome(_offspring.gene, this.numEquip_total, this.random);

            return mutant;
        }

        /*Updates the current population with the new population*/
        public List<Chromossome> getNextGeneration(List<Chromossome> _elite, List<Chromossome> _offspring)
        {
            List<Chromossome> population = new List<Chromossome>();

            population.AddRange(_elite);
            population.AddRange(_offspring);

            return population;
        }
    }
}
