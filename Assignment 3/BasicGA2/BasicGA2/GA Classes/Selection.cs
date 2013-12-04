using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public static class Selection
    {
        public static List<string> doSelection(int selectionType, List<string> _chromoGen, List<double> _chromoFitness, Random _random)
        {
            List<string> offspring = new List<string>();

            switch (selectionType)
            {
                case 0:
                    {
                        offspring = Roulette(_chromoGen, _chromoFitness, _random);
                    }
                    break;

                case 1:
                    {
                        offspring = Tournament(_chromoGen, _chromoFitness, _random);
                    }
                    break;

                default:
                    {
                        offspring = Roulette(_chromoGen, _chromoFitness, _random);
                    }
                    break;
            }

            return offspring;
        }

        public static List<string> Roulette(List<string>_chromoGen, List<double>_chromoFitness, Random _random)
        {
            List<double> pSelection = PSelection(_chromoFitness);
            List<double> cpSelecion = CPSelection(pSelection);
            List<string> selectedGens = new List<string>();

            double rndRoulette;

            for (int i = 0; i < _chromoGen.Count(); i++)
            {
                rndRoulette = _random.Next(Convert.ToInt32(Math.Floor(cpSelecion.Max())));
                for (int j = 0; j < _chromoGen.Count(); j++)
                {
                    if (rndRoulette <= cpSelecion[j])
                    {
                        selectedGens.Add(_chromoGen[j]);
                        break;
                    }
                }
            }
            return selectedGens;
        }

        private static List<double> PSelection(List<double> _chromoFitness)
        {
            List<double> _chromoPSelection = new List<double>();

            double offset = _chromoFitness.Min()+1;
            for (int i = 0; i < _chromoFitness.Count(); i++)
                _chromoFitness[i] += Math.Abs(offset);

            for (int i = 0; i < _chromoFitness.Count(); i++)
                _chromoPSelection.Add(_chromoFitness[i] / _chromoFitness.Sum() * 100);
            return _chromoPSelection;
        }

        private static List<double> CPSelection(List<double> _chromoPSelection)
        {
            List<double> _chromoCPSelection = new List<double>();
            for (int i = 0; i < _chromoPSelection.Count(); i++)
            {
                _chromoCPSelection.Add(0);
                for (int j = 0; j <= i; j++)
                {
                    _chromoCPSelection[i] += _chromoPSelection[j];
                }
            }
            return _chromoCPSelection;
        }

        public static List<string> Tournament(List<string> _chromoGen, List<double> _chromoFitness, Random _random)
        {
            List<string> selectedGens = new List<string>();

            /*For tournament selection it was necessary to multiply fitness by -1*/
            for (int i = 0; i < _chromoFitness.Count(); i++)
            {
                _chromoFitness[i] = -_chromoFitness[i];
            }

            int criteria = 3;
            double compareFitness = 0;

            List<int> playersIndex = new List<int>();
            //List<double> playersFit = new List<double>();

            for (int i = 0; i < _chromoGen.Count(); i++)
            {
                playersIndex.Clear();
                for (int j = 0; j < criteria; j++)
                {
                    playersIndex.Add(_random.Next(0, _chromoGen.Count()));
                }

                /*Match for n players*/
                compareFitness = _chromoFitness[playersIndex[0]];
                selectedGens.Add(_chromoGen[playersIndex[0]]);

                for (int j = 0; j < criteria - 1; j++)
                {
                    if (compareFitness > _chromoFitness[playersIndex[j + 1]])
                    {
                        compareFitness = _chromoFitness[playersIndex[j + 1]];
                        selectedGens[i] = _chromoGen[playersIndex[j + 1]];
                    }
                }
            }
            return selectedGens;
        }
    }
}
