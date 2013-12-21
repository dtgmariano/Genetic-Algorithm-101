using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class ChromossomeStrategy
    {
        const int area = 81;
        const int size = 9;

        /*Returns the gene of the Chromossome: List of 3x3 subgrids */
        public static List<List<int>> generateGenes(Random _random)
        {
            List<List<int>> genes = new List<List<int>>();

            while (genes.Count() < 9)
                genes.Add(generateSubGrid(_random));

            return genes;
        }

        public static List<object> generateObjGenes(Random _random)
        {
            List<object> genes = new List<object>();

            while (genes.Count() < 9)
                genes.Add(generateSubGrid(_random));

            return genes;
        }

        /*Returns a list of integers based on a 3x3 subgrid */
        public static List<int> generateSubGrid(Random _random)
        {
            List<int> U = new List<int>(Enumerable.Range(1, 9));
            List<int> subgrid = new List<int>();

            while (U.Count() > 0)
            {
                int idx = _random.Next(0, U.Count());
                subgrid.Add(U[idx]);
                U.RemoveAt(idx);
            }
            return subgrid;
        }

        /*Returns a list of integers based on the distribution of sudoku */
        public static List<int> generateGrid(List<List<int>> _genes)
        {
            int[] agrid = new int[81];

            for (int i = 0; i < 9; i++) 
            {
                for (int j = 0; j < 9; j++)
                    agrid[(3 * (i + 2 * (i - (i % 3)))) + (3 * (j - (j % 3))) + (j % 3)] = _genes[i][j];
            }

            List<int> grid = agrid.ToList<int>();
            return grid;
        }

        /*Returns the number of missing digits (from the interval 1:9) in a sequency*/
        public static int calculateNumMissingDigitis(List<int> sequency)
        {
            int sum = 0;
            HashSet<int> myRange = new HashSet<int>(Enumerable.Range(1, 9));
            myRange.ExceptWith(sequency);
            sum += myRange.Count();

            //check the number of repetitions
            //var duplicated = sequency.GroupBy(x => x);
            //sum += sequency.Count() - duplicated.Count();

            return sum;
        }

        /*Returns the sum of the number of missing digits from each row and column from a grid*/
        public static int calculatePenalty(List<int> grid)
        {
            int score = 0;

            for (int i = 0; i < size; i++)
            {
                /*calculates mnissing digits for each row*/
                score += ChromossomeStrategy.calculateNumMissingDigitis(grid.GetRange(i * size, size));
                /*calculates mnissing digits for each column*/
                score += ChromossomeStrategy.calculateNumMissingDigitis(new List<int>
                             (new[]{grid[i], grid[i + 1*size], grid[i + 2*size], 
                           grid[i + 3*size], grid[i + 4*size], grid[i + 5*size], 
                           grid[i + 6*size], grid[i + 7*size], grid[i + 8*size],}));
            }
            return score;
        }

        /*Returns the fitness based on the Chromossomes's gene*/
        public static double calculatesFitness(List<List<int>> _gene)
        {
            return 100.0 / calculatePenalty(generateGrid(_gene));
        }

        /*Returns the fitness based on the Chromossome's number of penalties*/
        public static double calculatesFitness(int penaltyScore)
        {
            return 100.0 / penaltyScore;
        }

    }
}
