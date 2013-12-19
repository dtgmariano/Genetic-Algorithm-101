using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class UpdateStrategy
    {
        public static List<Chromossome> updateGeneration(List<Chromossome> _elite, List<Chromossome> _children)
        {
            List<Chromossome> population = new List<Chromossome>(_elite);
            population.AddRange(_children);
            return population;
        }
    }
}
