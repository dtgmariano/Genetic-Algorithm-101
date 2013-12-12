using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class CrossoverStrategy
    {
        public static List<char> pmx(List<char> _parent1, List<char> _parent2, int _cutoff1, int _cutoff2)
        {
            List<char> child = new List<char>();
            List<char> swath_p1;

            /*Step 1: Randomly select a swath of alleles from parent 1 
             * and copy them directly to the child. Note the indexes of the segment.*/
            swath_p1 = _parent1.GetRange(_cutoff1, _cutoff2 - _cutoff1 + 1);

            /*Organizes child alleles. The ones that are out of the cutoff zone, receives '*' */
            for (int i = 0; i < _cutoff1; i++)
                child.Add('*');
            child.AddRange(swath_p1);
            for (int i = _cutoff2 + 1; i < _parent1.Count(); i++)
                child.Add('*');

            /*Step 2: Looking in the same segment positions in parent 2, 
             * select each value that hasn't already been copied to the child.*/
            for (int i = _cutoff1; i < _cutoff2 + 1; i++)
            {
                char v, valuetoinsert;
                int idx_at_p2;
                bool flag;
                /*For each of these values*/
                if (isItemRepeated(_parent2[i], child) == false)
                {
                    /*Note the index of this value (parent2[i]) in Parent 2. Locate the value, V, 
                     * from parent 1 in this same position. Locate this same value in parent 2.*/
                    valuetoinsert = _parent2[i];
                    v = _parent1[i];
                    idx_at_p2 = getIndex(v, _parent2);

                    while (is_part_of_the_original_swath(idx_at_p2, _cutoff1, _cutoff2) == true)
                    {
                        v = _parent1[idx_at_p2];
                        idx_at_p2 = getIndex(v, _parent2);
                    }

                    child[idx_at_p2] = valuetoinsert;
                    /*If the index of this value in Parent 2 is part of the original swath, 
                     * go to step i. using this value.*/

                    /*If the position isn't part of the original swath, 
                     * insert Step A's value into the child in this position.*/
                }
            }

            /*6. Now the easy part, we've taken care of all swath values, 
             * so everything else from Parent 2 drops down to the child.*/
            for (int i = 0; i < child.Count(); i++)
            {
                if (child[i] == '*')
                    child[i] = _parent2[i];
            }

            return child;
        }

        public static int getIndex(char item, List<char> list)
        {
            int index = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == item)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static bool isItemRepeated(char item, List<char> list)
        {
            bool answer = false;
            foreach (char c in list)
            {
                if (c == item)
                {
                    answer = true;
                    break;
                }
            }
            return answer;
        }

        public static bool is_part_of_the_original_swath(int index, int cutoff1, int cutoff2)
        {
            bool answer;

            if (index >= cutoff1 && index <= cutoff2)
                answer = true;
            else
                answer = false;

            return answer;
        }
    }
}
