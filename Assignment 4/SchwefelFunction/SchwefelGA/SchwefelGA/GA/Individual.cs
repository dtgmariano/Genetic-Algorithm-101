using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class Individual
    {
        public int min, max, res, nbits;
        public string chromossome;
        public double fitness;

        /*Constructor for the first chromossome*/
        public Individual(Random _random)
        {
            this.min = -500;
            this.max = 500;
            this.res = 0;
            this.nbits = 2 * (Convert.ToInt32(Math.Ceiling(Math.Log((this.max - this.min), 2))) + this.res);
            this.chromossome = ChromossomeStrategy.generateChromossome(_random, nbits);
            this.fitness = ChromossomeStrategy.calculateFitness(this.chromossome, this.min, this.max, this.res, this.nbits);
        }

        /*Constructor for offspring chromossomes*/
        public Individual(string _code)
        {
            this.min = -500;
            this.max = 500;
            this.res = 0;
            this.nbits = 2 * (Convert.ToInt32(Math.Ceiling(Math.Log((this.max - this.min), 2))) + this.res);
            this.chromossome = _code;
            this.fitness = ChromossomeStrategy.calculateFitness(this.chromossome, this.min, this.max, this.res, this.nbits);
        }
    }
}
