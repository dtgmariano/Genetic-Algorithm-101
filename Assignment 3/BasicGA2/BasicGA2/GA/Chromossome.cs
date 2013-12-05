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
            avaliationBasedOnFunction(this.value);
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
            avaliationBasedOnFunction(this.value);
        }

        /*Avaliation methods*/
        public void avaliationBasedOnFunction(double _value)
        {
            this.fitness = Equation.Fx(_value);
        }

        public void avaliationBasedOnRanking(double _score)
        {
            this.fitness = _score;
        }
    }
}
