using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiolabLibraries;

namespace GA
{
    public class Chromossome
    {
        
        public List<string> gene;
        public double fitness;
        Random random;

        public int size;
        public int intervals;

        /*First generation chromossome constructor*/
        public Chromossome(int _size, int _numIntervals, List<string> _U, Random _random)
        {
            this.random = _random;
            this.size = _size;
            this.intervals = _numIntervals;
            this.gene = generateGene(this.size, _U);
            this.fitness = geneAvaliation(this.gene);
        }

        public List<string> generateGene(int _size, List<string> _U)
        {
            List<string> gene = new List<string>();
            bool isValid = false;

            while (isValid == false)
            {
                gene.Clear();
                for (int i = 0; i < _size; i++)
                    gene.Add(_U[random.Next(0, _U.Count())]);
                isValid = Validator.geneIsValid(gene);
            }

            return gene;
        }

        /*Offspring generation chromossome constructor*/
        public Chromossome(List<string> _gene, int _size, Random _random)
        {
            this.random = _random;
            this.size = _size;
            this.gene = _gene;
            this.fitness = geneAvaliation(this.gene);
        }

        public double geneAvaliation(List<string> _gene)
        {
            double score = 0.0;
            double[] availability = new double[12];

            for (int i = 0; i < this.intervals; i++) //each interval
            {
                for (int j = 0; j < _gene.Count(); j++) //each machine
                {
                    if (_gene[j][i] == '0')
                        availability[i] += 1;
                }
            }

            score = (100 / Statistics.StandardDeviation(availability));

            return score;
        }

        
    }
}
