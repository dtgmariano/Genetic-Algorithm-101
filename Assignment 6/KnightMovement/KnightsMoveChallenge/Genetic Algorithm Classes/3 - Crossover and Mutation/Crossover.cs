using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class Crossover
    {
        public static List<Individual> doCrossover(Ops _method, List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        {

            List<Individual> offspring = new List<Individual>();

            int sizeChromossome = _parents[0].chromossome.Count();

            if (_selectionSize % 2 != 0)
            {
                offspring.Add(_parents[_selectionSize - 1]);
            }

            for (int i = 0; i < (_selectionSize / 2); i++)
            {
                double dice = _random.NextDouble();
                if (dice <= _crossoverProbability)
                {
                    //Do crossover and generates offsprings
                    int index = i * 2;
                    int cutoff;
                    switch (_method)
                    {
                        case Ops.onePoint:
                            {
                                cutoff = _random.Next(0, _parents[index].chromossome.Count());
                                offspring.Add(onePoint(_parents[index], _parents[index + 1], cutoff));
                                offspring.Add(onePoint(_parents[index + 1], _parents[index], cutoff));
                            }
                            break;
                        case Ops.twoPoints:
                            {
                                //offspring.Add(twoPoints(_parents[index], _parents[index + 1], _random));
                                //offspring.Add(twoPoints(_parents[index + 1], _parents[index], _random));
                            }
                            break;
                        case Ops.singleGen:
                            {
                                cutoff = _random.Next(0, _parents[index].chromossome.Count());
                                offspring.Add(singleGen(_parents[index], _parents[index + 1], cutoff));
                                offspring.Add(singleGen(_parents[index + 1], _parents[index], cutoff));
                            }
                            break;
                        case Ops.PMX:
                            {
                            }
                            break;
                    }
                }
                else
                {
                    //Mantain parents
                    int index = i * 2;
                    offspring.Add(_parents[index]);
                    offspring.Add(_parents[index + 1]);
                }
            }

            return offspring;
        }

        public enum Ops
        {
            onePoint,
            twoPoints,
            singleGen,
            PMX
        }

        private static Individual onePoint(Individual p1, Individual p2, int _cutoff)
        {
            List<string> o1_c = new List<string>();

            int size = p1.chromossome.Count();

            o1_c.AddRange(p1.chromossome.GetRange(0, _cutoff));
            o1_c.AddRange(p2.chromossome.GetRange(0, size - _cutoff));

            return (new Individual(o1_c, p1.startPoint));
        }

        private static Individual twoPoints(Individual p1, Individual p2, int _cutoff)
        {
            List<string> o1_c = new List<string>();
            
            //TO IMPLEMENT!!

            return (new Individual(o1_c, p1.startPoint));
        }

        private static Individual singleGen(Individual p1, Individual p2, int _cutoff)
        {
            List<string> o1_c = new List<string>(p1.chromossome);

            o1_c[_cutoff] = p2.chromossome[_cutoff];

            return (new Individual(o1_c, p1.startPoint));
        }
    }
}
