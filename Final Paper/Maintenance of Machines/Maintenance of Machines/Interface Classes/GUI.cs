using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintenance_of_Machines
{
    public partial class GUI : Form
    {
        /*Machine Parameters*/
        //int[] powerdemand = {80, 90, 65, 70};
        //int[] machinecapacity = { 20, 15, 35, 40, 15, 15, 10 };
        //int[] maintenanceinterval = { 2, 2, 1, 1, 1, 1 };
        Random random = new Random();
        GeneticAlgorithm ga;
        
        public GUI()
        {
            InitializeComponent();
            ga = new GeneticAlgorithm(random);
            ga.StartStep();
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            //ga.Go();
            ga.SelectionStep();
            ga.ElitismStep();
            ga.CrossoverStep();
            ga.MutationStep();
            ga.UpdatePopulation();

            rtbInfo.Clear();
            rtbInfo.AppendText(ga.population_fitness.Average() + "\n");
            rtbInfo.AppendText(ga.elite_population_fitness.Average() + "\n");
            rtbInfo.AppendText(ga.selec_population_fitness.Average() + "\n");
            rtbInfo.AppendText(ga.co_population_fitness.Average() + "\n");
            foreach (string s in ga.GetBestResult())
            {
                rtbInfo.AppendText(s + " ");
            }
            rtbInfo.AppendText("\n");

            double[] net_power = ga.GetNetPower(ga.GetBestResult());

            foreach (double d in net_power)
            {
                rtbInfo.AppendText(d + " ");
            }
            rtbInfo.AppendText("\n");

            //rtbInfo.AppendText("----Initial Population----\n");
            //for (int i = 0; i < ga.population_value.Count(); i++)
            //{
            //    foreach (string gen in ga.population_value[i])
            //    {
            //        rtbInfo.AppendText(gen + " ");
            //    }
            //    //rtbInfo.AppendText(" " + ga.population_fitness[i] + " " + ga.fitpp[i] + "\n");
            //    rtbInfo.AppendText(" " + ga.population_fitness[i] + "\n");
            //}

            //rtbInfo.AppendText("\n----Parents Population----\n");
            //for (int i = 0; i < ga.new_population_value.Count(); i++)
            //{
            //    foreach (string gen in ga.new_population_value[i])
            //    {
            //        rtbInfo.AppendText(gen + " ");
            //    }
            //    //rtbInfo.AppendText(" " + ga.population_fitness[i] + " " + ga.fitpp[i] + "\n");
            //    rtbInfo.AppendText(" " + ga.new_population_fitness[i] + "\n");
            //}
        }
    }
}
