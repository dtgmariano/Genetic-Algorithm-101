using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA
{
    public partial class View : Form
    {
        Random random;
        GA ga;
        int countGeneration;

        public View()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            random = new Random();
            int _numEquip_total = Convert.ToInt32(numEquip_total.Value);
            int _numEquip_demand = Convert.ToInt32(numEquip_demand.Value);
            double _percentageEquip_reserve = Convert.ToDouble(percentageEquip_reserve.Value);
            int _numServIntervals = Convert.ToInt32(numServIntervals.Value);
            int _numIntervals = Convert.ToInt32(numIntervals.Value);
            int _numPopSize = Convert.ToInt32(numPopSize.Value);
            int _numGenerations = Convert.ToInt32(numGenerations.Value);
            
            countGeneration = 0;

            ga = new GA(_numEquip_total, _numEquip_demand, _percentageEquip_reserve, _numIntervals, _numServIntervals, _numPopSize, _numGenerations, this.random);
            ga.BeginStep();
            countGeneration++;

            richTextBox1.Clear();

            for (int i = 0; i < _numEquip_total; i++)
            {
                richTextBox1.AppendText(ga.champion.gene[i] + " ");
            }
            richTextBox1.AppendText("\n" + ga.champion.fitness);

            gaProcess.Enabled = true;

        }

        private void gaProcess_Tick(object sender, EventArgs e)
        {
            ga.EliteStep();
            ga.SelectionStep();
            ga.CrossoverStep();
            ga.NextGenerationStep();
            countGeneration++;

            if (countGeneration >= ga.numgenerations)
                gaProcess.Enabled = false;

        }
    }
}
