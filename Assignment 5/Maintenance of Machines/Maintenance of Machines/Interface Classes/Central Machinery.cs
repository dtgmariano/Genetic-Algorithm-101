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
        List<string> machinelights;
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
            machinelights = ga.GetBestResult();

            #region Machine 1 Lights
            if (machinelights[0][0] == '0')
                pb00.Image = Properties.Resources.Green_LED_environmental;
            else
                pb00.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[0][1] == '0')
                pb01.Image = Properties.Resources.Green_LED_environmental;
            else
                pb01.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[0][2] == '0')
                pb02.Image = Properties.Resources.Green_LED_environmental;
            else
                pb02.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[0][3] == '0')
                pb03.Image = Properties.Resources.Green_LED_environmental;
            else
                pb03.Image = Properties.Resources.Red_LED_green_folder;
            #endregion

            #region Machine 2 Lights
            if (machinelights[1][0] == '0')
                pb10.Image = Properties.Resources.Green_LED_environmental;
            else
                pb10.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[1][1] == '0')
                pb11.Image = Properties.Resources.Green_LED_environmental;
            else
                pb11.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[1][2] == '0')
                pb12.Image = Properties.Resources.Green_LED_environmental;
            else
                pb12.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[1][3] == '0')
                pb13.Image = Properties.Resources.Green_LED_environmental;
            else
                pb13.Image = Properties.Resources.Red_LED_green_folder;
            #endregion

            #region Machine 3 Lights
            if (machinelights[2][0] == '0')
                pb20.Image = Properties.Resources.Green_LED_environmental;
            else
                pb20.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[2][1] == '0')
                pb21.Image = Properties.Resources.Green_LED_environmental;
            else
                pb21.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[2][2] == '0')
                pb22.Image = Properties.Resources.Green_LED_environmental;
            else
                pb22.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[2][3] == '0')
                pb23.Image = Properties.Resources.Green_LED_environmental;
            else
                pb23.Image = Properties.Resources.Red_LED_green_folder;
            #endregion

            #region Machine 4 Lights
            if (machinelights[3][0] == '0')
                pb30.Image = Properties.Resources.Green_LED_environmental;
            else
                pb30.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[3][1] == '0')
                pb31.Image = Properties.Resources.Green_LED_environmental;
            else
                pb31.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[3][2] == '0')
                pb32.Image = Properties.Resources.Green_LED_environmental;
            else
                pb32.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[3][3] == '0')
                pb33.Image = Properties.Resources.Green_LED_environmental;
            else
                pb33.Image = Properties.Resources.Red_LED_green_folder;
            #endregion

            #region Machine 5 Lights
            if (machinelights[4][0] == '0')
                pb40.Image = Properties.Resources.Green_LED_environmental;
            else
                pb40.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[4][1] == '0')
                pb41.Image = Properties.Resources.Green_LED_environmental;
            else
                pb41.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[4][2] == '0')
                pb42.Image = Properties.Resources.Green_LED_environmental;
            else
                pb42.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[4][3] == '0')
                pb43.Image = Properties.Resources.Green_LED_environmental;
            else
                pb43.Image = Properties.Resources.Red_LED_green_folder;
            #endregion

            #region Machine 6 Lights
            if (machinelights[5][0] == '0')
                pb50.Image = Properties.Resources.Green_LED_environmental;
            else
                pb50.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[5][1] == '0')
                pb51.Image = Properties.Resources.Green_LED_environmental;
            else
                pb51.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[5][2] == '0')
                pb52.Image = Properties.Resources.Green_LED_environmental;
            else
                pb52.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[5][3] == '0')
                pb53.Image = Properties.Resources.Green_LED_environmental;
            else
                pb53.Image = Properties.Resources.Red_LED_green_folder;
            #endregion

            #region Machine 7 Lights
            if (machinelights[6][0] == '0')
                pb60.Image = Properties.Resources.Green_LED_environmental;
            else
                pb60.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[6][1] == '0')
                pb61.Image = Properties.Resources.Green_LED_environmental;
            else
                pb61.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[6][2] == '0')
                pb62.Image = Properties.Resources.Green_LED_environmental;
            else
                pb62.Image = Properties.Resources.Red_LED_green_folder;

            if (machinelights[6][3] == '0')
                pb63.Image = Properties.Resources.Green_LED_environmental;
            else
                pb63.Image = Properties.Resources.Red_LED_green_folder;
            #endregion

        }

        private void CentralEnergyInfo()
        {
            netpower = ga.GetNetPower(machinelights);
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
