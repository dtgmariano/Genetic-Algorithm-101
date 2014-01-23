using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace GA
{
    public class Individual
    {
        public List<string> chromossome;
        public Point startPoint;
        public double fitness;

        public Individual(Random _random, Point _startPoint)
        {
            chromossome = ChromossomeStrategy.generateChromossome(_random);
            startPoint = _startPoint;
            fitness = ChromossomeStrategy.calculatesFitness(chromossome, startPoint);
        }

    }
}
