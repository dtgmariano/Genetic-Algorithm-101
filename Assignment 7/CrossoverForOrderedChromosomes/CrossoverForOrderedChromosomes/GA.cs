using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class GA
    {
        public List<int> parentA, parentB, offspringA, offspringB;
        public List<int> cities;
        public int ncities;
        Random random;

        public GA(Random _random, int _ncities)
        {
            initializeCities();
            random = _random;
            ncities = _ncities;
            initializeCities();
            parentA = genChromossome(cities);
            parentB = genChromossome(cities);
        }

        public void initializeCities()
        {
            cities = new List<int>();
            for (int i = 0; i < ncities; i++)
            {
                cities.Add(i);
            }
        }

        public List<int> genChromossome(List<int> _cities)
        {
            List<int> cities = new List<int>(_cities);
            List<int> chromossome = new List<int>();
            int dice;

            while (cities.Count()!=0)
            {
                dice = random.Next(0, cities.Count());
                chromossome.Add(cities[dice]);
                cities.RemoveAt(dice);
            }

            return chromossome;
        }

        public void PMX()
        {
            List<int> points = new List<int>();
            points.Add(random.Next(0, ncities));
            points.Add(random.Next(0, ncities));
            while (points[0] == points[1])
            {
                points.Clear();
                points.Add(random.Next(0, ncities));
                points.Add(random.Next(0, ncities));
                points.Add(0); points.Add(5);
            }
            points.Sort();

            offspringA = new List<int>();
            offspringB = new List<int>();
            for (int i = 0; i < points[0]; i++)
            {
                offspringA.Add(parentA[i]);
                offspringB.Add(parentB[i]);
            }
            for (int i = points[0]; i <= points[1]; i++)
            {
                offspringA.Add(parentB[i]);
                offspringB.Add(parentA[i]);
            }
            for (int i = points[1] + 1; i < ncities ; i++)
            {
                offspringA.Add(parentA[i]);
                offspringB.Add(parentB[i]);
            }

        }
    }
}
