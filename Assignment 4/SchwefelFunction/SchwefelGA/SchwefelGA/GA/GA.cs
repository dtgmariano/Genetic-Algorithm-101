       //public GA(int _min, int _max, int _res, 
        //    int _popsize, int _numgenerations, double _probcrossover, double _probmutation,
        //    bool _ranking, bool _elitism, double _elitism_percentage, 
        //    int _selec_op, int _cross_op, int _mutan_op, int _optim_op,
        //    Random _random)
        //{
        //    this.min = _min;
        //    this.max = _max;
        //    this.res = _res;

        //    this.popsize = _popsize;
        //    this.numgenerations = _numgenerations;
        //    this.probcrossover = _probcrossover;
        //    this.probmutation = _probmutation;

        //    this.hasRanking = _ranking;
        //    this.hasElitism = _elitism;
        //    this.elitism_percentage = _elitism_percentage;
        //    this.elitism_counter = Convert.ToInt32(Convert.ToDouble(this.popsize) * this.elitism_percentage);

        //    this.selectionMethod = _selec_op;
        //    this.crossoverMethod = _cross_op;
        //    this.mutationMethod = _mutan_op;
        //    this.optimizationMethod = _optim_op;

        //    this.random = _random;
        //}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GA
    {
        /*Chromossome variables*/
        int min, max, res;

        /*GA paremeters variables*/
        public int populationSize, generationsNumber;
        double probabilityCrossover, probabilityMutation;
        int elitismSize, selectionSize, tournamentSize;

        /*GA Lists variables*/
        public List<Individual> population;
        List<Individual> elite;
        List<Individual> parents;
        List<Individual> offsprings;
        List<Individual> mutants;
        public Individual champion;

        /*Random variables*/
        Random random;

        /*Constructors*/
        public GA(int _popsize,
            int _numgenerations,
            double _probcrossover,
            double _probmutation,
            double _elitism_percentage,
            Random _random)
        {
            this.populationSize = _popsize;
            this.elitismSize = Convert.ToInt32(Convert.ToDouble(populationSize) * _elitism_percentage);
            this.selectionSize = this.populationSize - this.elitismSize;
            this.tournamentSize = 2;

            this.generationsNumber = _numgenerations;
            this.probabilityCrossover = _probcrossover;
            this.probabilityMutation = _probmutation;

            this.random = _random;
        }

        public void populateProcedure()
        {
            this.population = PopulateStrategy.populate(this.populationSize, this.random);
            this.champion = ChampionStrategy.getChampion(this.population);
        }

        public void elitismProcedure()
        {
            this.elite = ElitismStrategy.basicElitism(this.population, this.elitismSize);
        }

        public void selectionProcedure()
        {
            //this.parents = SelectionStrategy.RouletteWheel(this.population, this.selectionSize, this.random);
            this.parents = SelectionStrategy.Tournament(this.population, this.selectionSize, this.tournamentSize, this.random);
        }

        public void crossoverProcedure()
        {
            //this.offsprings = CrossoverStrategy.OneGen(this.parents, this.selectionSize, this.probabilityCrossover, this.random);
            this.offsprings = CrossoverStrategy.OnePoint(this.parents, this.selectionSize, this.probabilityCrossover, this.random);
            //this.offsprings = CrossoverStrategy.TwoPoints(this.parents, this.selectionSize, this.probabilityCrossover, this.random);        
        }

        public void mutationProcedure()
        {
            this.mutants = MutationStrategy.InvertBit(this.offsprings, this.probabilityMutation, this.random);
        }

        public void updtadeProcedure()
        {
            this.population = UpdateStrategy.updateGeneration(this.elite, this.mutants);
            this.champion = ChampionStrategy.getChampion(this.population);
        }

    }
}

