using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Genetic_Algorithm
{
    public static class Crossover
    {
        //public static readonly Dictionary<int, string> CrossoverType = new Dictionary<int, string>()
        //{
        //    {0,"Uniform"},
        //    {1,"OnePoint"},
        //    {2, "TwoPoints"}
        //};

        public static List<string> doCrossover(int _crossoverType, List<string> _selectedChromossomes, int _ProbabilityCrossover, Random _random)
        {
            List<string> offspring = new List<string>();

            switch (_crossoverType)
            {
                case 0:
                {
                    offspring = Uniform(_selectedChromossomes, _ProbabilityCrossover, _random);
                }
                break;

                case 1:
                {
                    offspring = OnePoint(_selectedChromossomes, _ProbabilityCrossover, _random);
                }
                break;

                case 2:
                {
                    offspring = TwoPoints(_selectedChromossomes, _ProbabilityCrossover, _random);
                }
                break;

                default:
                {
                    offspring = OnePoint(_selectedChromossomes, _ProbabilityCrossover, _random);
                }
                break;
            }

            return offspring;
            
        }

        public static List<string> Uniform(List<string> _selectedChromossomes, int _ProbabilityCrossover, Random _random)
        {
            List<string> offspring = new List<string>();
            string mask;

            for (int i = 0; i < _selectedChromossomes.Count(); i=i+2)
            {
                offspring.Add(_selectedChromossomes[i]);
                offspring.Add(_selectedChromossomes[i + 1]);

                mask = Operation.GeneratesBinaryString(_random, _selectedChromossomes[0].Length);
                

                if (_random.Next(0, 100) <= _ProbabilityCrossover)
                {
                    for (int idx_s = 0; idx_s < offspring[0].Length; idx_s++)
                    {
                        if(mask[idx_s] == '1')
                        {
                            offspring[i] = _selectedChromossomes[i].Substring(0, idx_s) + _selectedChromossomes[i + 1][idx_s] + _selectedChromossomes[i].Substring(idx_s + 1, _selectedChromossomes[i].Length - idx_s - 1);
                            offspring[i + 1] = _selectedChromossomes[i + 1].Substring(0, idx_s) + _selectedChromossomes[i][idx_s] + _selectedChromossomes[i + 1].Substring(idx_s + 1, _selectedChromossomes[i + 1].Length - idx_s - 1);
                        }
                    }
                }
             }
            return offspring;
        }

        public static List<string> OnePoint(List<string> _selectedChromossomes, int _ProbabilityCrossover, Random _random)
        {
            List<string> offspring = new List<string>();

            for (int i = 0; i < _selectedChromossomes.Count(); i = i + 2)
            {
                offspring.Add(_selectedChromossomes[i]);
                offspring.Add(_selectedChromossomes[i + 1]);

                if (_random.Next(0, 100) <= _ProbabilityCrossover)
                {
                    //if (_selectedChromossomes[i].Length == _selectedChromossomes[i+1].Length)
                    //{
                    int mask = _random.Next(0, _selectedChromossomes[i].Length);
                    offspring[i] = _selectedChromossomes[i].Substring(0, mask) + _selectedChromossomes[i + 1].Substring(mask, _selectedChromossomes[i + 1].Length - mask);
                    offspring[i + 1] = _selectedChromossomes[i + 1].Substring(0, mask) + _selectedChromossomes[i].Substring(mask, _selectedChromossomes[i].Length - mask);
                    //}
                }
            }
            return offspring;
        }

        public static List<string> TwoPoints(List<string> _selectedChromossomes, int _ProbabilityCrossover, Random _random)
        {
            List<string> offspring = new List<string>();
            List<int> mask = new List<int>();

            for (int i = 0; i < _selectedChromossomes.Count(); i = i + 2)
            {
                offspring.Add(_selectedChromossomes[i]);
                offspring.Add(_selectedChromossomes[i + 1]);

                if (_random.Next(0, 100) <= _ProbabilityCrossover)
                {

                    mask.Clear();
                    mask.Add(0);
                    mask.Add(2);
                    //mask.Add(_random.Next(0, _selectedChromossomes[i].Length));
                    //mask.Add(_random.Next(0, _selectedChromossomes[i].Length));
                    mask.Sort();

                    offspring[i] = _selectedChromossomes[i].Substring(0, mask[0]) + 
                                   _selectedChromossomes[i + 1].Substring(mask[0], mask[1] - mask[0] + 1) + 
                                   _selectedChromossomes[i].Substring(mask[1] + 1, _selectedChromossomes[i].Length - 1 - mask[1]);

                    offspring[i + 1] = _selectedChromossomes[i + 1].Substring(0, mask[0]) + 
                                       _selectedChromossomes[i].Substring(mask[0], mask[1] - mask[0] + 1) + 
                                       _selectedChromossomes[i+1].Substring(mask[1] + 1, _selectedChromossomes[i+1].Length - 1 - mask[1]);
                }
            }
            return offspring;
        }

    }
}
