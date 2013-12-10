using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class Chromossome
    {
        public int size;
        public List<City> code;
        public double fitness;
        public double traveldistance;
        Random random;

        /*Constructor for the first chromossome*/
        public Chromossome(List<City> _worldsCities, Random _random)
        {
            this.random = _random;
            this.size = _worldsCities.Count();
            this.code = generateCode(_worldsCities, random);
            this.traveldistance = getTravelDistance(code);
            this.fitness = getFitness(traveldistance);
        }

        public Chromossome(List<City> _code, List<City> _worldsCities, Random _random)
        {
            this.random = _random;
            this.size = _worldsCities.Count();
            this.code = _code;
            this.traveldistance = getTravelDistance(code);
            this.fitness = getFitness(traveldistance);
        }

        public List<City> generateCode(List<City> _worldsCities, Random _random)
        {
            List<City> code = new List<City>();
            List<City> worldsCities = new List<City>(_worldsCities);

            while (worldsCities.Count != 0)
            {
                int point = _random.Next(0, worldsCities.Count);
                code.Add(worldsCities[point]);
                worldsCities.RemoveAt(point);
            }
            return code;
        }

        public double getTravelDistance(List<City> cities)
        {
            double travelDistance = 0;
            for (int i = 0; i < (this.size - 1); i++)
            {
                travelDistance += distanceBetweenCities(cities[i], cities[i + 1]);
            }
            return travelDistance; 
        }

        public double distanceBetweenCities(City A, City B)
        {
            return Math.Sqrt((Math.Pow(Math.Abs(A.x - B.x),2)) + (Math.Pow(Math.Abs(A.y - B.y),2)));
        }

        public double getFitness(double _traveldistance)
        {
            return _traveldistance;
            //return (1.0 / _traveldistance);
        }

    }
}
