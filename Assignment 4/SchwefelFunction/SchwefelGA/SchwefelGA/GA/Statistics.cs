using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class Statistics
    {
        public static int Rounding { get; set; }

        public static double Average(List<double> sampleList)
        {
            double sum = 0;

            for (int i = 0; i < sampleList.Count; i++)
                sum += sampleList[i];

            return Math.Round(sum / sampleList.Count, Rounding);
        }

        public static double Variance(List<double> sampleList)
        {
            double sum = 0;

            double mean = Average(sampleList);

            for (int i = 0; i < sampleList.Count(); i++)
                sum += Math.Pow((sampleList[i] - mean), 2);

            return Math.Round((sum / (sampleList.Count() - 1)), Rounding);
        }

        public static double StandardDeviation(List<double> sampleList)
        {
            return Math.Round(Math.Sqrt(Variance(sampleList)), Rounding);
        }

        public static double Value_Average(List<Individual> sampleList)
        {
            double sum = 0;

            for (int i = 0; i < sampleList.Count; i++)
                sum += sampleList[i].x;

            return Math.Round(sum / sampleList.Count, Rounding);
        }

        public static double Value_Variance(List<Individual> sampleList)
        {
            double sum = 0;

            double mean = Value_Average(sampleList);

            for (int i = 0; i < sampleList.Count(); i++)
                sum += Math.Pow((sampleList[i].x - mean), 2);

            return Math.Round((sum / (sampleList.Count() - 1)), Rounding);
        }

        public static double Value_StandardDeviation(List<Individual> sampleList)
        {
            return Math.Round(Math.Sqrt(Value_Variance(sampleList)), Rounding);
        }

        //public static double FuncValue_Average(List<Chromossome> sampleList)
        //{
        //    double sum = 0;

        //    for (int i = 0; i < sampleList.Count; i++)
        //        sum += Equation.Fx(sampleList[i].x);

        //    return Math.Round(sum / sampleList.Count, Rounding);
        //}

        //public static double FuncValue_Variance(List<Chromossome> sampleList)
        //{
        //    double sum = 0;

        //    double mean = FuncValue_Average(sampleList);

        //    for (int i = 0; i < sampleList.Count(); i++)
        //        sum += Math.Pow((Equation.Fx(sampleList[i].x) - mean), 2);

        //    return Math.Round((sum / (sampleList.Count() - 1)), Rounding);
        //}

        //public static double FuncValue_StandardDeviation(List<Chromossome> sampleList)
        //{
        //    return Math.Round(Math.Sqrt(FuncValue_Variance(sampleList)), Rounding);
        //}

        public static Individual getTheBestChromossome(List<Individual> _population)
        {
            Individual champ;

            List<Individual> candidates = new List<Individual>();
            List<double> candidates_fitness = new List<double>();

            for (int i = 0; i < _population.Count(); i++)
            {
                candidates.Add(_population[i]);
                candidates_fitness.Add(_population[i].fitness);
            }

            Array acandidates = candidates.ToArray();
            Array acandidates_fitness = candidates_fitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            candidates = acandidates.OfType<Individual>().ToList();
            candidates.Reverse();
            champ = candidates[0];

            return champ;
        }
    }
}
