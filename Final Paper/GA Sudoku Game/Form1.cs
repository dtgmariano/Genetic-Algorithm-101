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
        List<List<int>> inputs;

        public Form1()
        {
            InitializeComponent();
            numPS.Value = 5000;
            numNG.Value = 75;
            numPc.Value = 60;
            numPm.Value = 25;
            numEp.Value = 20;
            numTs.Value = 40;
        }

        private void captureInputs()
        {
            inputs = new List<List<int>>();
            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb00.Text), Convert.ToInt32(tb01.Text), Convert.ToInt32(tb02.Text), 
                                             Convert.ToInt32(tb10.Text), Convert.ToInt32(tb11.Text), Convert.ToInt32(tb12.Text),
                                             Convert.ToInt32(tb20.Text), Convert.ToInt32(tb21.Text), Convert.ToInt32(tb22.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb03.Text), Convert.ToInt32(tb04.Text), Convert.ToInt32(tb05.Text), 
                                             Convert.ToInt32(tb13.Text), Convert.ToInt32(tb14.Text), Convert.ToInt32(tb15.Text),
                                             Convert.ToInt32(tb23.Text), Convert.ToInt32(tb24.Text), Convert.ToInt32(tb25.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb06.Text), Convert.ToInt32(tb07.Text), Convert.ToInt32(tb08.Text), 
                                             Convert.ToInt32(tb16.Text), Convert.ToInt32(tb17.Text), Convert.ToInt32(tb18.Text),
                                             Convert.ToInt32(tb26.Text), Convert.ToInt32(tb27.Text), Convert.ToInt32(tb28.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb30.Text), Convert.ToInt32(tb31.Text), Convert.ToInt32(tb32.Text), 
                                             Convert.ToInt32(tb40.Text), Convert.ToInt32(tb41.Text), Convert.ToInt32(tb42.Text),
                                             Convert.ToInt32(tb50.Text), Convert.ToInt32(tb51.Text), Convert.ToInt32(tb52.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb03.Text), Convert.ToInt32(tb34.Text), Convert.ToInt32(tb35.Text), 
                                             Convert.ToInt32(tb13.Text), Convert.ToInt32(tb44.Text), Convert.ToInt32(tb45.Text),
                                             Convert.ToInt32(tb23.Text), Convert.ToInt32(tb54.Text), Convert.ToInt32(tb55.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb36.Text), Convert.ToInt32(tb37.Text), Convert.ToInt32(tb38.Text), 
                                             Convert.ToInt32(tb46.Text), Convert.ToInt32(tb47.Text), Convert.ToInt32(tb48.Text),
                                             Convert.ToInt32(tb56.Text), Convert.ToInt32(tb57.Text), Convert.ToInt32(tb58.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb60.Text), Convert.ToInt32(tb61.Text), Convert.ToInt32(tb62.Text), 
                                             Convert.ToInt32(tb70.Text), Convert.ToInt32(tb71.Text), Convert.ToInt32(tb72.Text),
                                             Convert.ToInt32(tb80.Text), Convert.ToInt32(tb81.Text), Convert.ToInt32(tb82.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb63.Text), Convert.ToInt32(tb64.Text), Convert.ToInt32(tb65.Text), 
                                             Convert.ToInt32(tb73.Text), Convert.ToInt32(tb74.Text), Convert.ToInt32(tb75.Text),
                                             Convert.ToInt32(tb83.Text), Convert.ToInt32(tb84.Text), Convert.ToInt32(tb85.Text),}));

            inputs.Add(new List<int>(new[] { Convert.ToInt32(tb66.Text), Convert.ToInt32(tb67.Text), Convert.ToInt32(tb68.Text), 
                                             Convert.ToInt32(tb76.Text), Convert.ToInt32(tb77.Text), Convert.ToInt32(tb78.Text),
                                             Convert.ToInt32(tb86.Text), Convert.ToInt32(tb87.Text), Convert.ToInt32(tb88.Text),}));
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            int ps = (int)numPS.Value;
            int ng = (int)numNG.Value;
            double pc = (double)numPc.Value / 100.0;
            double pm = (double)numPm.Value / 100.0;
            double ep = (double)numEp.Value / 100.0;

            ga = new GA(ps, ng, pc, pm, ep, new Random());
            ga.populateProcedure();


            vectorChampion = ChromossomeStrategy.generateGrid(ga.newChampion.chromossome);


            richTextBox1.Clear();
            for (int i = 0; i < 81; i++)
            {
                richTextBox1.AppendText(vectorChampion[i] + " ");
                if ((i + 1) % 9 == 0)
                    richTextBox1.AppendText("\n");
            }

            count = 1;
            lbGeneration.Text = "Generation: " + count;
            lbPenalty.Text = "Penalty: " + ga.newChampion.penalty;
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

            vectorChampion = ChromossomeStrategy.generateGrid(ga.newChampion.chromossome);

            richTextBox1.Clear();
            for (int i = 0; i < 81; i++)
            {
                richTextBox1.AppendText(vectorChampion[i] + " ");
                if ((i + 1) % 9 == 0)
                    richTextBox1.AppendText("\n");
            }

            count++;
            lbGeneration.Text = "Generation: " + count;
            lbPenalty.Text = "Penalty: " + ga.newChampion.penalty;
            if (count >= ga.generationsNumber)
            {
                timer.Enabled = false;
                btStart.Enabled = true;
                btGo.Enabled = false;
            }
        }


    }
}
