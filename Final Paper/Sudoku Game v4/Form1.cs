using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GA
{
    public partial class Form1 : Form
    {
        GA ga;
        List<int> vectorChampion;
        int count;

        public Form1()
        {
            InitializeComponent();
            numPS.Value = 300;
            numNG.Value = 100;
            numPc.Value = 60;
            numPm.Value = 25;
            numEp.Value = 20;
            numTs.Value = 100;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            int ps = (int) numPS.Value;
            int ng = (int)numNG.Value;
            double pc = (double) numPc.Value / 100.0;
            double pm = (double) numPm.Value / 100.0;
            double ep = (double) numEp.Value / 100.0;

            ga = new GA(ps, ng, pc, pm, ep, new Random());
            ga.populateProcedure();

            vectorChampion = ChromossomeStrategy.generateMatrix(ga.champion.gene);

            richTextBox1.Clear();
            for (int i = 0; i < 81; i++)
            {
                richTextBox1.AppendText(vectorChampion[i] + " ");
                if ((i + 1) % 9 == 0)
                    richTextBox1.AppendText("\n");
            }

            count = 1;
            lbGeneration.Text = "Generation: " + count;
            lbPenalty.Text = "Penalty: " + ga.champion.penalty;
            timer.Interval = (int)numTs.Value;

            btStart.Enabled = true;
            btGo.Enabled = true;
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            btStart.Enabled = false;
            btGo.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ga.elitismProcedure();
            ga.selectionProcedure();
            ga.crossoverProcedure();
            ga.mutationProcedure();
            ga.updtadeProcedure();

            vectorChampion = ChromossomeStrategy.generateMatrix(ga.champion.gene);

            richTextBox1.Clear();
            for (int i = 0; i < 81; i++)
            {
                richTextBox1.AppendText(vectorChampion[i] + " ");
                if ((i + 1) % 9 == 0)
                    richTextBox1.AppendText("\n");
            }
            
            count++;
            lbGeneration.Text = "Generation: " + count;
            lbPenalty.Text = "Penalty: " + ga.champion.penalty;
            if (count >= ga.generationsNumber)
            {
                timer.Enabled = false;
                btStart.Enabled = true;
                btGo.Enabled = false;
            }
        }

        
    }
}
