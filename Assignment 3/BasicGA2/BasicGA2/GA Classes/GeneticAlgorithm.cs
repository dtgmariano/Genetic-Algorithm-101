using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public class GeneticAlgorithm
    {
        public int populationSize;
        public int numberGenerations;
        public int probabilityCrossover; 
        public int probabilityMutation;

        public int selectionType;
        public int crossoverType;
        public int functionType;
        public int optimizationType;

        public List<string> chromoGens = new List<string>();
        public List<double> chromoValue = new List<double>();
        public List<double> chromoFitness = new List<double>();

        public Random random;
        public int rangeMin;
        public int rangeMax; 
        public int granularity;

        public GeneticAlgorithm(int _rangeMin, int _rangeMax, int _granularity, 
                                int _populationsize, int _numberGenerations,  int _probabilityCrossover, int _probabilityMutation, 
                                int _selectionType, int _crossoverType, int _functionType, int _optimizationType,
                                Random _random)
        {
            this.rangeMin = _rangeMin;
            this.rangeMax = _rangeMax;
            this.granularity = _granularity;

            this.populationSize = _populationsize;
            this.numberGenerations = _numberGenerations;
            this.probabilityCrossover = _probabilityCrossover;
            this.probabilityMutation = _probabilityMutation;

            this.selectionType = _selectionType;
            this.crossoverType = _crossoverType;
            this.functionType = _functionType;
            this.optimizationType = _optimizationType;

            this.random = _random;

            //StartsPopulation();
        }

        public void StartsPopulation()
        {
            chromoGens.Clear();
            chromoGens = Chromossome.Creates(populationSize, rangeMin, rangeMax, granularity, random);
            chromoValue = Chromossome.getPopulationValues(chromoGens, rangeMin, rangeMax, granularity, random);
            chromoFitness = Chromossome.getPopulationFitness(functionType, optimizationType, chromoValue);
        }

        public void SelectParents()
        {
            chromoGens = Selection.doSelection(selectionType,chromoGens, chromoFitness, random);
            chromoValue = Chromossome.getPopulationValues(chromoGens, rangeMin, rangeMax, granularity, random);
            chromoFitness = Chromossome.getPopulationFitness(functionType, optimizationType, chromoValue);
        }

        public void Reproduction()
        {
            chromoGens = Crossover.doCrossover(crossoverType, chromoGens, probabilityCrossover, random);
            //chromoGens = Mutation.doMutation(1, chromoGens, probabilityMutation, random);
            chromoValue = Chromossome.getPopulationValues(chromoGens, rangeMin, rangeMax, granularity, random);
            chromoFitness = Chromossome.getPopulationFitness(functionType, optimizationType, chromoValue);
        }

    }
}
