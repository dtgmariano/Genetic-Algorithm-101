using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GAforStatistic
    {
        public List<GA> tests;
        int min, max, res;
        int popsize, numgenerations;
        double probcrossover, probmutation;
        bool hasranking, haselitism;
        double elitism_percent;
        int  selec_op, cross_op, mutant_op, optim_op;
        Random random;

        public GAforStatistic()
        {
            tests = new List<GA>();
            min = 0;
            max = 512;
            res = 0;
            popsize = 50;
            numgenerations = 20;
            probcrossover = 0.6;
            probmutation = 0.01;
            hasranking = false;
            haselitism = false;
            elitism_percent = 0.1;
            selec_op = 0;
            cross_op = 0;
            mutant_op = 0;
            optim_op = 0;
            random = new Random();
        }

        public void setTests()
        {

            selec_op = 0;
            tests.Add( new GA(min, max, res,
                popsize, numgenerations, probcrossover, probmutation,
                hasranking, haselitism, elitism_percent,
                selec_op, cross_op, mutant_op, optim_op, random));

            selec_op = 1;
            tests.Add(new GA(min, max, res,
                popsize, numgenerations, probcrossover, probmutation,
                hasranking, haselitism, elitism_percent,
                selec_op, cross_op, mutant_op, optim_op, random));

            haselitism = true;

            elitism_percent = 0.1;
            tests.Add(new GA(min, max, res,
                popsize, numgenerations, probcrossover, probmutation,
                hasranking, haselitism, elitism_percent,
                selec_op, cross_op, mutant_op, optim_op, random));

        }
    }
}
