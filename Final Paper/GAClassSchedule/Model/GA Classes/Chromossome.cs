using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GA.GA_Classes
{
    class Chromossome
    {
        int _size;

        List<Class> _slots;
        Hashtable _classes = new Hashtable();
        double _fitness;

        public Chromossome()
        {

        }

        public Chromossome(List<Class> semesterList, List<Room> roomsAvailable)
        {
            _size = 5 * roomsAvailable.Count() * 12;
            
        }

        public double calculateFitness()
        {
            double fitness = 0.0;

            return fitness;
        }

    }
}
