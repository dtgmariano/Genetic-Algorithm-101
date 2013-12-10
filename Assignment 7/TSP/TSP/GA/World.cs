using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public class World
    {
        public int numberOfCities;
        public List<City> citiesList;
        public Random random;

        public World(int _numberOfCities, Random _random)
        {
            numberOfCities = _numberOfCities;
            random = _random;
            citiesList = new List<City>();

            citiesList.Add(new City(random));

            while (citiesList.Count() < this.numberOfCities)
            {
                City newCity = new City(random);

                if (validateCity(citiesList, newCity) == true)
                {
                    citiesList.Add(newCity);
                    citiesList[citiesList.Count - 1].id = citiesList.Count - 1;
                }
            }
        }

        public bool validateCity(List<City> _citiesList, City _newCity)
        {
            bool isCityValid = false;

            foreach (City c in _citiesList)
            {
                if (c.x != _newCity.x || c.y != _newCity.y)
                    isCityValid = true;
                else
                {
                    isCityValid = false;
                    break;
                }
            }

            return isCityValid;
        }


    }
}
