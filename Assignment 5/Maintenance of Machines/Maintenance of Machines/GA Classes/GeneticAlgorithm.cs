using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiolabLibraries;

namespace Maintenance_of_Machines
{
    public class GeneticAlgorithm
    {
        #region Variables
        /*GA Parameters Variables*/
        public int popsize, numgenerations;
        private double probcrossover, probmutation;
        private int elitism_counter;

        /*GA Lists Variables*/
        public List<List<string>> population_values;
        public List<double> population_fitness;
        public List<List<string>> elite_population_values;
        public List<double> elite_population_fitness;
        public List<List<string>> selec_population_values;
        public List<double> selec_population_fitness;
        public List<List<string>> co_population_values;
        public List<double> co_population_fitness;
        public List<List<string>> mt_population_values;
        public List<double> mt_population_fitness;

        /*Maintenance of machiens variables*/
        int[] power_demand;  //power demand of each quarter
        int[] power_lost;    //power loss due to downtime of the machines
        string[] u1 = { "0001", "0010", "0100", "1000" };
        string[] u2 = { "1100", "0110", "0011" };
        string[] u3 = { "1110", "0111" };
        
        /*Random variable*/
        Random random;
        #endregion

        #region Class Constructor
        /*Constructor*/
        public GeneticAlgorithm(Random _random)
        {
            /*GA Parameters Variables*/
            this.popsize = 1000;
            this.numgenerations = 20;
            this.probcrossover = 0.6;
            this.probmutation = 0.01;
            this.elitism_counter = 100;

            /*GA Lists Variables*/
            this.population_values = new List<List<string>>();
            this.population_fitness = new List<double>();
            this.elite_population_values = new List<List<string>>();
            this.elite_population_fitness = new List<double>();
            this.selec_population_values = new List<List<string>>();
            this.selec_population_fitness = new List<double>();
            this.co_population_values = new List<List<string>>();
            this.co_population_fitness = new List<double>();

            /*Maintenance of machiens variables*/
            power_demand = new int[4] { 80, 90, 65, 70 };
            power_lost = new int[7] { 20, 15, 35, 40, 15, 15, 10 };

            /*Random variable*/
            this.random = _random;
        }

        /*Constructor*/
        public GeneticAlgorithm(Random _random, int[] _power_demand, int[] _power_lost)
        {
            /*GA Parameters Variables*/
            this.popsize = 1000;
            this.numgenerations = 20;
            this.probcrossover = 0.6;
            this.probmutation = 0.01;
            this.elitism_counter = 100;

            /*GA Lists Variables*/
            this.population_values = new List<List<string>>();
            this.population_fitness = new List<double>();
            this.elite_population_values = new List<List<string>>();
            this.elite_population_fitness = new List<double>();
            this.selec_population_values = new List<List<string>>();
            this.selec_population_fitness = new List<double>();
            this.co_population_values = new List<List<string>>();
            this.co_population_fitness = new List<double>();

            /*Maintenance of machiens variables*/
            power_demand = _power_demand;
            power_lost = _power_lost;

            /*Random variable*/
            this.random = _random;
        }
        #endregion

        #region GA Steps
        /*Processes the genetic algorithm*/
        public void Go()
        {
            /*Starting population*/
            StartStep();

            /*Through the generations*/
            int count_numberofgenerations = 0;
            while (count_numberofgenerations < this.numgenerations)
            {
                SelectionStep();
                ElitismStep();
                CrossoverStep();
                MutationStep();
                UpdatePopulation();
                count_numberofgenerations++;
            }

            /*Reaches the stop condition*/
            
        }

        /*Initiates population*/
        public void StartStep()
        {
            List<string> chromossome = new List<string>();
            double fitness = 0.0;

            int count_population = 0;
            bool flag_validator = false;

            population_values.Clear();
            population_fitness.Clear();

            while (count_population < this.popsize)
            {
                chromossome = generateChromossome();
                flag_validator = Validation(chromossome);

                if (flag_validator == true)
                {
                    population_values.Add(chromossome);
                    population_fitness.Add(Avaliation(chromossome));
                    count_population++;
                }
            }
        }

        /*Selects the elite of the population*/
        public void ElitismStep()
        {
            List<List<string>> elite_values = population_values;
            List<double> elite_fitness = population_fitness;

            Array aelite_values = elite_values.ToArray();
            Array aelite_fitness = elite_fitness.ToArray();
            Array.Sort(aelite_fitness, aelite_values);

            elite_values = aelite_values.OfType<List<string>>().ToList();
            elite_fitness = aelite_fitness.OfType<double>().ToList();

            elite_values.Reverse();
            elite_fitness.Reverse();

            elite_population_values.Clear();
            elite_population_fitness.Clear();

            for (int i = 0; i < this.elitism_counter; i++)
            {
                elite_population_values.Add(elite_values[i]);
                elite_population_fitness.Add(elite_fitness[i]);
            }

        }

        /*Selects the parents for reproduction with elitism*/
        public void SelectionStep()
        {
            bool flag_validation = false;
            List<string> parent_value;
            int count_population = 0;

            selec_population_values.Clear();
            selec_population_fitness.Clear();


            while (count_population < (this.popsize - this.elitism_counter))
            {
                parent_value = Tournament(10);
                flag_validation = Validation(parent_value);

                if (flag_validation == true)
                {
                    selec_population_values.Add(parent_value);
                    selec_population_fitness.Add(Avaliation(parent_value));
                    count_population++;
                }
            }
        }

        /*Generates the offsprings from the parents with elitism*/
        public void CrossoverStep()
        {
            List<List<string>> parents = new List<List<string>>();
            List<List<string>> offsprings;

            int count_population = 0;

            co_population_values.Clear();
            co_population_fitness.Clear();

            while (count_population < (this.popsize - this.elitism_counter))
            {
                parents.Clear();
                parents.Add(selec_population_values[count_population]);
                parents.Add(selec_population_values[count_population + 1]);
                offsprings = Crossover1P(parents, 10);

                co_population_values.Add(offsprings[0]);
                co_population_fitness.Add(Avaliation(offsprings[0]));
                co_population_values.Add(offsprings[1]);
                co_population_fitness.Add(Avaliation(offsprings[1]));

                count_population += 2;
            }
        }

        /*Mutation of the offsprings gens*/
        public void MutationStep()
        {
            //List<List<string>> offspring_before_mutation = new List<List<string>>();
            //List<List<string>> offspring_after_mutation;

            //int count_population = 0;
            //mt_population_values.Clear();
            //mt_population_fitness.Clear();

            //while (count_population < (this.popsize - this.elitism_counter))
            //{

            //}

        }
        
        /*Updates the current population with the new population*/
        public void UpdatePopulation()
        {
            population_values.Clear();
            population_fitness.Clear();

            for (int i = 0; i < this.popsize - this.elitism_counter; i++)
            {
                population_values.Add(co_population_values[i]);
                population_fitness.Add(co_population_fitness[i]);
            }
            for (int i = 0; i < elitism_counter; i++)
            {
                population_values.Add(elite_population_values[i]);
                population_fitness.Add(elite_population_fitness[i]);
            }
        }

        #endregion

        #region Specific Functions for the problem
        /*Returns the best chromossome at the population*/
        public List<string> GetBestResult()
        {
            List<string> champion;

            /*Organizes players based on the fitness attribute*/
            Array apopulation_fitness = population_fitness.ToArray();
            Array apopulation_values = population_values.ToArray();
            Array.Sort(apopulation_fitness, apopulation_values);

            population_values = apopulation_values.OfType<List<string>>().ToList();
            population_fitness = apopulation_fitness.OfType<double>().ToList();

            population_values.Reverse();
            population_fitness.Reverse();

            /*Selects the best option in the population*/
            champion = population_values[0];

            return champion;
        }

        /*Returns the NetPower for a specific combination of machines working*/
        public double[] GetNetPower(List<string> chromossome)
        {
            double total = this.power_lost.Sum();
            double[] net_power = new double[4] { total, total, total, total };

            for (int i = 0; i < 4; i++)
            {
                if (chromossome[0][i] == '1')
                    net_power[i] -= power_lost[0];
                if (chromossome[1][i] == '1')
                    net_power[i] -= power_lost[1];
                if (chromossome[2][i] == '1')
                    net_power[i] -= power_lost[2];
                if (chromossome[3][i] == '1')
                    net_power[i] -= power_lost[3];
                if (chromossome[4][i] == '1')
                    net_power[i] -= power_lost[4];
                if (chromossome[5][i] == '1')
                    net_power[i] -= power_lost[5];
                if (chromossome[6][i] == '1')
                    net_power[i] -= power_lost[6];
            }

            for (int i = 0; i < net_power.Count(); i++)
                net_power[i] -= power_demand[i];

            return net_power;
        }

        /*Generates a chromossome*/
        public List<string> generateChromossome()
        {
            List<string> chromossome = new List<string>();

            /*Adds each gen to the chromossome*/
            chromossome.Add(u2[random.Next(0, u2.Count())]);
            chromossome.Add(u2[random.Next(0, u2.Count())]);
            chromossome.Add(u1[random.Next(0, u1.Count())]);
            chromossome.Add(u1[random.Next(0, u1.Count())]);
            chromossome.Add(u1[random.Next(0, u1.Count())]);
            chromossome.Add(u1[random.Next(0, u1.Count())]);
            chromossome.Add(u1[random.Next(0, u1.Count())]);

            return chromossome;
        }

        #endregion

        #region Avaliation Methods
        /*Validates chromossome*/
        public bool Validation(List<string> chromossome)
        {
            double total = this.power_lost.Sum();
            double[] net_power = new double[4] { total, total, total, total };

            for (int i = 0; i < 4; i++)
            {
                if (chromossome[0][i] == '1')
                    net_power[i] -= power_lost[0];
                if (chromossome[1][i] == '1')
                    net_power[i] -= power_lost[1];
                if (chromossome[2][i] == '1')
                    net_power[i] -= power_lost[2];
                if (chromossome[3][i] == '1')
                    net_power[i] -= power_lost[3];
                if (chromossome[4][i] == '1')
                    net_power[i] -= power_lost[4];
                if (chromossome[5][i] == '1')
                    net_power[i] -= power_lost[5];
                if (chromossome[6][i] == '1')
                    net_power[i] -= power_lost[6];
            }

            for (int i = 0; i < net_power.Count(); i++)
                net_power[i] -= power_demand[i];

            if (net_power[0] >= 0 && net_power[1] >= 0 && net_power[2] >= 0 && net_power[3] >= 0)
                return true;
            else
                return false;
        }

        /*Avaliates the chromossome, returing the fitness(double)*/
        public double Avaliation(List<string> chromossome)
        {
            double total = this.power_lost.Sum();
            double[] net_power = new double[4] { total, total, total, total };

            for (int i = 0; i < 4; i++)
            {
                if (chromossome[0][i] == '1')
                    net_power[i] -= power_lost[0];
                if (chromossome[1][i] == '1')
                    net_power[i] -= power_lost[1];
                if (chromossome[2][i] == '1')
                    net_power[i] -= power_lost[2];
                if (chromossome[3][i] == '1')
                    net_power[i] -= power_lost[3];
                if (chromossome[4][i] == '1')
                    net_power[i] -= power_lost[4];
                if (chromossome[5][i] == '1')
                    net_power[i] -= power_lost[5];
                if (chromossome[6][i] == '1')
                    net_power[i] -= power_lost[6];
            }

            for (int i = 0; i < net_power.Count(); i++)
                net_power[i] -= power_demand[i];

            if (net_power[0] >= 0 && net_power[1] >= 0 && net_power[2] >= 0 && net_power[3] >= 0)
                return (100 / Statistics.StandardDeviation(net_power));
            else
                return 0;
        }
        #endregion

        #region Selection Methods
        /*Selection based on Tournament*/
        public List<string> Tournament(int _numPlayers)
        {
            List<List<string>> players_values = new List<List<string>>();
            List<double> players_fitness = new List<double>();
           
            int index = 0;
            int count_numPlayers = 0;

            while (count_numPlayers < _numPlayers)
            {
                index = random.Next(0, population_values.Count());
                players_values.Add(population_values[index]);
                players_fitness.Add(population_fitness[index]);
                count_numPlayers++;
            }

            /*Organizes players based on the fitness attribute*/
            Array aplayer_fitness = players_fitness.ToArray();
            Array aplayer_values = players_values.ToArray();
            Array.Sort(aplayer_fitness, aplayer_values);

            players_values = aplayer_values.OfType<List<string>>().ToList();
            players_fitness = aplayer_fitness.OfType<double>().ToList();

            players_values.Reverse();
            players_fitness.Reverse();

            return players_values[0];
        }

        /*Selection based on Tournament*/
        public List<string> Tournament(int _numPlayers, List<List<string>> _population_values, List<double> _population_fitness)
        {
            List<List<string>> players_values = new List<List<string>>();
            List<double> players_fitness = new List<double>();

            int index = 0;
            int count_numPlayers = 0;

            while (count_numPlayers < _numPlayers)
            {
                index = random.Next(0, _population_values.Count());
                players_values.Add(_population_values[index]);
                players_fitness.Add(_population_fitness[index]);
                count_numPlayers++;
            }

            /*Organizes players based on the fitness attribute*/
            Array aplayer_fitness = players_fitness.ToArray();
            Array aplayer_values = players_values.ToArray();
            Array.Sort(aplayer_fitness, aplayer_values);

            players_values = aplayer_values.OfType<List<string>>().ToList();
            players_fitness = aplayer_fitness.OfType<double>().ToList();

            players_values.Reverse();
            players_fitness.Reverse();

            return players_values[0];
        }
        #endregion

        #region Crossover Methods
        /*Crossover based on the One Point Method*/
        public List<List<string>> Crossover1P(List<List<string>> parents, int tolerance)
        {
            List<List<string>> offsprings = parents;

            if (this.random.NextDouble() <= this.probcrossover)
            {
                for (int i = 0; i < tolerance; i++)
                {
                    int mask = this.random.Next(0, parents[0].Count());
                    List<string> offspring1 = new List<string>();
                    List<string> offspring2 = new List<string>();

                    /*Crossover of 1 points process generates offsprings*/
                    for (int j = 0; j < mask; j++)
                        offspring1.Add(parents[0][j]);
                    for (int j = mask; j < parents[1].Count(); j++)
                        offspring1.Add(parents[1][j]);

                    for (int j = 0; j < mask; j++)
                        offspring2.Add(parents[1][j]);
                    for (int j = mask; j < parents[1].Count(); j++)
                        offspring2.Add(parents[0][j]);

                    /*Offspring validation*/
                    if (Validation(offspring1) == true && Validation(offspring2) == true)
                    {
                        offsprings = new List<List<string>>();
                        offsprings.Add(offspring1);
                        offsprings.Add(offspring2);
                        break;
                    }
                }
            }

            return offsprings;
        }
        #endregion

        #region Mutation Methods
        //public List<string> MutationClassic(List<string> _offspring_before_mutation)
        //{
        //    List<string> offspring_after_mutation;
            

        //    if (this.random.NextDouble() <= this.probmutation)
        //    {
        //        double mutationPoint = this.random.NextDouble();
        //    }

            


        //    return offspring_after_mutation;
        //}
        #endregion
    }
}
