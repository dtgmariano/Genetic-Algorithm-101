using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class Chromossome
    {
        public int min, max, res, nbits;
        public string code;
        public double value, fitness;

        Random random;

        /*Constructor for the first chromossome*/
        public Chromossome(int _min, int _max, int _res, Random _random)
        {
            this.random = _random;
            this.min = _min;
            this.max = _max;
            this.res = _res;
            this.nbits = Convert.ToInt32(Math.Ceiling(Math.Log((this.max - this.min), 2))) + this.res;
            this.code = BinaryOperators.GeneratesBinaryString(this.random, this.nbits);
            this.value = BinaryOperators.BinaryStringToDecimal(this.code);
            this.fitness = setFitness(this.value);
        }

        /*Constructor for offspring chromossomes*/
        public Chromossome(string _code, int _min, int _max, int _res, Random _random)
        {
            this.random = _random;
            this.min = _min;
            this.max = _max;
            this.res = _res;
            this.nbits = Convert.ToInt32(Math.Ceiling(Math.Log((this.max - this.min), 2))) + this.res;
            this.code = _code;
            this.value = BinaryOperators.BinaryStringToDecimal(this.code);
            this.fitness = setFitness(this.value);
        }
        /*Avaliation*/
        public double setFitness(double _value)
        {
            return (_value * Math.Sin(_value / 5));
        }
    }
}
