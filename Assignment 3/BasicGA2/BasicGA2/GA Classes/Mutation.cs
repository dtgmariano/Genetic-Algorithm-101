using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public static class Mutation
    {
        public static List<string> doMutation(int mutationType, List<string> _chromoGen, int _probabilityMutation, Random _random)
        {
            List<string> offspring = new List<string>();

            switch (mutationType)
            {
                case 0:
                    {
                        offspring = WholeCode(_chromoGen, _probabilityMutation, _random);
                    }
                    break;

                case 1:
                    {
                        offspring = OnePoint(_chromoGen, _probabilityMutation, _random);
                    }
                    break;

                default:
                    {
                        offspring = WholeCode(_chromoGen, _probabilityMutation, _random);
                    }
                    break;
            }

            return offspring;
        }

        public static List<string> WholeCode(List<string> _chromoGen, int _probabilityMutation, Random _random)
        {
            List<string> mutationGens = new List<string>();

            for (int i = 0; i < _chromoGen.Count(); i++)
            {
                mutationGens.Add(_chromoGen[i]);
                if((_random.NextDouble()*100)<_probabilityMutation)
                    mutationGens[i] = Operation.InvertBinaryString(mutationGens[i]);
            }

            return mutationGens;
        }

        public static List<string> OnePoint(List<string> _chromoGen, int _probabilityMutation, Random _random)
        {
            List<string> mutationGens = new List<string>();
            //string s;
            int point;

            for (int i = 0; i < _chromoGen.Count(); i++)
            {
                mutationGens.Add(_chromoGen[i]);
                if ((_random.NextDouble() * 100) < _probabilityMutation)
                {
                    point = _random.Next(0, mutationGens[i].Length);
                    if(mutationGens[i][point]=='0')
                        mutationGens[i] = mutationGens[i].Substring(0, point) + "1" + mutationGens[i].Substring(point + 1, mutationGens[i].Length - point - 1);
                    else
                        mutationGens[i] = mutationGens[i].Substring(0, point) + "0" + mutationGens[i].Substring(point + 1, mutationGens[i].Length - point - 1);
                }
            }

            return mutationGens;
        }
    }
}
