using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    static public class PopulateStrategy
    {
        public static List<Chromossome> populate(int _populationSize, Random _random)
        {
            List<Chromossome> population = new List<Chromossome>();
            for (int i = 0; i < _populationSize; i++)
                population.Add(new Chromossome(_random));
            return population;
        }
    }
}