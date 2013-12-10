using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class City
    {
        public int id;
        public int min, max;
        public double x, y;
        public Random random;

        public City(Random _random)
        {
            this.random = _random;
            min = -100;
            max = 100;
            this.x = random.Next(min, max);
            this.y = random.Next(min, max);   
        }


    }
}
