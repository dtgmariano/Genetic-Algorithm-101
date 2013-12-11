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
    public partial class Central_Machinery : Form
    {
        Random random = new Random();
        GeneticAlgorithm ga;
        List<string> machinestatus;
        double[] netpower;
        bool startGA_flag = false;
        int count_numberofgenerations = 0;

        public Central_Machinery()
        {
            InitializeComponent();
            
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            int[] _power_demand = new int[4] { (int)pd1.Value, (int)pd2.Value, (int)pd3.Value, (int)pd4.Value };
            int[] _power_machine = new int[7] { (int)pm1.Value, (int)pm2.Value, (int)pm3.Value, (int)pm4.Value, (int)pm5.Value, (int)pm6.Value, (int)pm7.Value};
            //ga = new GeneticAlgorithm(random);
            ga = new GeneticAlgorithm(random, _power_demand, _power_machine);
            netpower = new double[4];
            ProcessGA_Timer.Enabled = true;
        }

        private void CentralLightsProcess()
        {
            machinestatus = ga.GetBestResult();

        }

        private void CentralEnergyInfo()
        {
            netpower = ga.GetNetPower(machinestatus);
            lbP1.Text = netpower[0].ToString();
            lbP2.Text = netpower[1].ToString();
            lbP3.Text = netpower[2].ToString();
            lbP4.Text = netpower[3].ToString();
        }
        
        private void ProcessGA_Timer_Tick(object sender, EventArgs e)
        {

            /*For the first Generation do*/
            if (startGA_flag == false)
            {
                startGA_flag = true;
                btStart.Text = "Processing";
                btStart.Enabled = false;
                ga.StartStep();
                ga.SelectionStep();
                ga.ElitismStep();
                ga.CrossoverStep();
                //ga.MutationStep();
                ga.UpdatePopulation();

                count_numberofgenerations++;
                //UpdateGUI_Timer.Enabled = true;
            }
            /*For the following Generation do*/
            else
            {
                ga.SelectionStep();
                ga.ElitismStep();
                ga.CrossoverStep();
                //ga.MutationStep();
                ga.UpdatePopulation();

                count_numberofgenerations++;
            }

            /*After reaching the number of generations value stops the GA process and the Graph Update Process*/
            if (count_numberofgenerations >= ga.numgenerations)
            {
                ProcessGA_Timer.Enabled = false;
                //UpdateGUI_Timer.Enabled = false;
                startGA_flag = false;
                btStart.Text = "Start Genetic Algorithm Processes";
                btStart.Enabled = true;
                count_numberofgenerations = 0;
                MessageBox.Show("GA Process has reached the end!");
                
            }

            lbGeneration.Text = "Generation: " + (count_numberofgenerations);
            CentralLightsProcess();
            CentralEnergyInfo();

        }
       
        private void UpdateGUI_Timer_Tick(object sender, EventArgs e)
        {
            
        }

    }
}
