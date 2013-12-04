using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm.Model
{
    public static class Elitism
    {
        public static List<string> getElit(List<string> _population_genes, List<double> _population_fit, int k)
        {
            List<string> candidate_values = _population_genes;
            List<double> candidate_fitness = _population_fit;
            
            Array a_candidate_values = candidate_values.ToArray();
            Array a_candidate_fitness = candidate_fitness.ToArray();
            Array.Sort(a_candidate_fitness, a_candidate_values);

            candidate_values = a_candidate_values.OfType<string>().ToList();
            candidate_fitness = a_candidate_fitness.OfType<double>().ToList();

            candidate_values.Reverse();

            List<string> elite_values = new List<string>();
            for (int i = 0; i < k; i++)
                elite_values.Add(candidate_values[i]);

            return elite_values;
        }
    }
}
