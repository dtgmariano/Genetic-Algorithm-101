using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public static class Chromossome
    {
        public static List<string> Creates(int _populationSize, int _rangeMin, int _rangeMax, int _granularity, Random _random)
        {
            int nBits = Convert.ToInt32(Math.Ceiling(Math.Log((_rangeMax - _rangeMin), 2))) + _granularity;
            List<string> population = new List<string>();
            
            for (int i = 0; i < _populationSize; i++)
            {
                population.Add(Operation.GeneratesBinaryString(_random, nBits));
            }

            return population;
        }

        public static List<double> getPopulationValues(List<string> _population, int _rangeMin, int _rangeMax, int _granularity, Random _random)
        {
            int nBits = Convert.ToInt32(Math.Ceiling(Math.Log((_rangeMax - _rangeMin), 2))) + _granularity;
            List<double> populationValues = new List<double>();
            for (int i = 0; i < _population.Count(); i++)
            {
                populationValues.Add((_rangeMin + (_rangeMax - _rangeMin) * (Operation.BinaryStringToDecimal(_population[i])) / (Math.Pow(2, nBits) - 1)));
            }

            return populationValues;
        }

        public static List<double> getPopulationFitness(int _functionType, int _optimizationType, List<double> _populationValues)
        {
            List<double> populationFitness = new List<double>();

            for (int i = 0; i < _populationValues.Count(); i++)
            {
                populationFitness.Add(Fitness.set(_functionType, _optimizationType, _populationValues[i])); 
            }
            
            
            return populationFitness;
        }
    }
}
