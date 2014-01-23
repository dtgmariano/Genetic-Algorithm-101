﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GeneticAlgorithm
    {
        /*Variables declaration*/

        /*GA paremeters variables*/
        public int populationSize, generationsNumber;
        public double probabilityCrossover, probabilityMutation;
        public int elitismSize, selectionSize, tournamentSize;

        /*GA Lists variables*/
        public List<Individual> population;
        public List<Individual> elite;
        public List<Individual> parents;
        public List<Individual> offsprings;
        public List<Individual> mutants;
        public Individual champion;

        /*Random variables*/
        Random random;

        /*Constructors*/
        public GeneticAlgorithm(int _popsize, 
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

        //public void elitismProcedure()
        //{
        //    this.elite = ElitismStrategy.basicElitism(this.population, this.elitismSize);
        //}

        //public void selectionProcedure()
        //{
        //    //this.parents = SelectionStrategy.RouletteWheel(this.population, this.selectionSize, this.random);
        //    this.parents = SelectionStrategy.Tournament(this.population, this.selectionSize, this.tournamentSize, this.random);
        //}

        //public void crossoverProcedure()
        //{
        //     this.offsprings = CrossoverStrategy.doCrossover(this.parents, this.selectionSize, this.probabilityCrossover, this.random);
        //}

        //public void mutationProcedure()
        //{
        //    this.mutants = MutationStrategy.doMutation(this.offsprings, this.probabilityMutation, this.random);
        //}

        //public void updtadeProcedure()
        //{
        //    this.population = UpdateStrategy.updateGeneration(this.elite, this.mutants);
        //    this.champion = ChampionStrategy.getChampion(this.population);
        //}
    }
}