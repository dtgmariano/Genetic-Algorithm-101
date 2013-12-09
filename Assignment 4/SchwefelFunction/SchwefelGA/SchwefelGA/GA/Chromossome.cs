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
        public double x, y, z, fitness;
        private int optimization;

        Random random;

        /*Constructor for the first chromossome*/
        public Chromossome(int _min, int _max, int _res, int _optimization, Random _random)
        {
            this.random = _random;
            this.min = _min;
            this.max = _max;
            this.res = _res;
            this.nbits = (Convert.ToInt32(Math.Ceiling(Math.Log((this.max - this.min), 2))) + this.res)*2;
            this.code = BinaryOperators.GeneratesBinaryString(this.random, this.nbits);
            this.x = BinaryOperators.BinaryStringToDecimal(this.code.Substring(0, nbits / 2));
            this.y = BinaryOperators.BinaryStringToDecimal(this.code.Substring(nbits / 2, nbits / 2));
            this.z = Equation.Fxy(this.x, this.y);
            this.optimization = _optimization;
            avaliationBasedOnFunction();
        }

        /*Constructor for offspring chromossomes*/
        public Chromossome(string _code, int _min, int _max, int _res, int _optimization, Random _random)
        {
            this.random = _random;
            this.min = _min;
            this.max = _max;
            this.res = _res;
            this.nbits = (Convert.ToInt32(Math.Ceiling(Math.Log((this.max - this.min), 2))) + this.res) * 2;
            this.code = _code;
            this.x = BinaryOperators.BinaryStringToDecimal(this.code.Substring(0, nbits / 2));
            this.y = BinaryOperators.BinaryStringToDecimal(this.code.Substring(nbits / 2, nbits / 2));
            this.z = Equation.Fxy(this.x, this.y);
            this.optimization = _optimization;
            avaliationBasedOnFunction();
        }

        /*Avaliation methods*/
        public void avaliationBasedOnFunction()
        {
            switch (this.optimization)            
            {
                case 0:
                    {
                        this.fitness = this.z;
                        break;
                    }
                case 1:
                    {
                        this.fitness = -this.z;
                        break;
                    }
            }
        }

        public void avaliationBasedOnRanking(double _score)
        {
            this.fitness = _score;
        }

    }
}
