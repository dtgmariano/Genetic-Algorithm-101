using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    class Class
    {
        Professor _professor;
        Discipline _discipline;
        int _duration;
        List<StudentsGroup> _groups;

        public Class(Professor professor, Discipline discipline, int duration, List<StudentsGroup> groups)
        {
            _professor = professor;
            _discipline = discipline;
            _duration = duration;
            _groups = groups;
        }

    }
}
