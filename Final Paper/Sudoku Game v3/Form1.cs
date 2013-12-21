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
        Chromossome bestSolution;
        int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            int ps = 10000;
            int ng = 75;
            double pc = 0.6;
            double pm = 0.25;
            double ep = 0.2;

            ga = new GA(ps, ng, pc, pm, ep, new Random());
            ga.populateProcedure();
            bestSolution = ga.champion;
            #region textboxes change value
            tb00.Text = bestSolution.gene[0].ToString();
            tb01.Text = bestSolution.gene[1].ToString();
            tb02.Text = bestSolution.gene[2].ToString();
            tb03.Text = bestSolution.gene[3].ToString();
            tb04.Text = bestSolution.gene[4].ToString();
            tb05.Text = bestSolution.gene[5].ToString();
            tb06.Text = bestSolution.gene[6].ToString();
            tb07.Text = bestSolution.gene[7].ToString();
            tb08.Text = bestSolution.gene[8].ToString();
            tb10.Text = bestSolution.gene[9].ToString();
            tb11.Text = bestSolution.gene[10].ToString();
            tb12.Text = bestSolution.gene[11].ToString();
            tb13.Text = bestSolution.gene[12].ToString();
            tb14.Text = bestSolution.gene[13].ToString();
            tb15.Text = bestSolution.gene[14].ToString();
            tb16.Text = bestSolution.gene[15].ToString();
            tb17.Text = bestSolution.gene[16].ToString();
            tb18.Text = bestSolution.gene[17].ToString();
            tb20.Text = bestSolution.gene[18].ToString();
            tb21.Text = bestSolution.gene[19].ToString();
            tb22.Text = bestSolution.gene[20].ToString();
            tb23.Text = bestSolution.gene[21].ToString();
            tb24.Text = bestSolution.gene[22].ToString();
            tb25.Text = bestSolution.gene[23].ToString();
            tb26.Text = bestSolution.gene[24].ToString();
            tb27.Text = bestSolution.gene[25].ToString();
            tb28.Text = bestSolution.gene[26].ToString();
            tb30.Text = bestSolution.gene[27].ToString();
            tb31.Text = bestSolution.gene[28].ToString();
            tb32.Text = bestSolution.gene[29].ToString();
            tb33.Text = bestSolution.gene[30].ToString();
            tb34.Text = bestSolution.gene[31].ToString();
            tb35.Text = bestSolution.gene[32].ToString();
            tb36.Text = bestSolution.gene[33].ToString();
            tb37.Text = bestSolution.gene[34].ToString();
            tb38.Text = bestSolution.gene[35].ToString();
            tb40.Text = bestSolution.gene[36].ToString();
            tb41.Text = bestSolution.gene[37].ToString();
            tb42.Text = bestSolution.gene[38].ToString();
            tb43.Text = bestSolution.gene[39].ToString();
            tb44.Text = bestSolution.gene[40].ToString();
            tb45.Text = bestSolution.gene[41].ToString();
            tb46.Text = bestSolution.gene[42].ToString();
            tb47.Text = bestSolution.gene[43].ToString();
            tb48.Text = bestSolution.gene[44].ToString();
            tb50.Text = bestSolution.gene[45].ToString();
            tb51.Text = bestSolution.gene[46].ToString();
            tb52.Text = bestSolution.gene[47].ToString();
            tb53.Text = bestSolution.gene[48].ToString();
            tb54.Text = bestSolution.gene[49].ToString();
            tb55.Text = bestSolution.gene[50].ToString();
            tb56.Text = bestSolution.gene[51].ToString();
            tb57.Text = bestSolution.gene[52].ToString();
            tb58.Text = bestSolution.gene[53].ToString();
            tb60.Text = bestSolution.gene[54].ToString();
            tb61.Text = bestSolution.gene[55].ToString();
            tb62.Text = bestSolution.gene[56].ToString();
            tb63.Text = bestSolution.gene[57].ToString();
            tb64.Text = bestSolution.gene[58].ToString();
            tb65.Text = bestSolution.gene[59].ToString();
            tb66.Text = bestSolution.gene[60].ToString();
            tb67.Text = bestSolution.gene[61].ToString();
            tb68.Text = bestSolution.gene[62].ToString();
            tb70.Text = bestSolution.gene[63].ToString();
            tb71.Text = bestSolution.gene[64].ToString();
            tb72.Text = bestSolution.gene[65].ToString();
            tb73.Text = bestSolution.gene[66].ToString();
            tb74.Text = bestSolution.gene[67].ToString();
            tb75.Text = bestSolution.gene[68].ToString();
            tb76.Text = bestSolution.gene[69].ToString();
            tb77.Text = bestSolution.gene[70].ToString();
            tb78.Text = bestSolution.gene[71].ToString();
            tb80.Text = bestSolution.gene[72].ToString();
            tb81.Text = bestSolution.gene[73].ToString();
            tb82.Text = bestSolution.gene[74].ToString();
            tb83.Text = bestSolution.gene[75].ToString();
            tb84.Text = bestSolution.gene[76].ToString();
            tb85.Text = bestSolution.gene[77].ToString();
            tb86.Text = bestSolution.gene[78].ToString();
            tb87.Text = bestSolution.gene[79].ToString();
            tb88.Text = bestSolution.gene[80].ToString();
            #endregion
            count = 1;
            lbGeneration.Text = "Generation: " + count;
            lbPenalty.Text = "Penalty: " + bestSolution.penalty;
            timer.Interval = 30;
            timer.Enabled = true;
            btGo.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ga.elitismProcedure();
            ga.selectionProcedure();
            ga.crossoverProcedure();
            ga.mutationProcedure();
            ga.updtadeProcedure();

            bestSolution = ga.champion;
            #region textboxes change value
            tb00.Text = bestSolution.gene[0].ToString();
            tb01.Text = bestSolution.gene[1].ToString();
            tb02.Text = bestSolution.gene[2].ToString();
            tb03.Text = bestSolution.gene[3].ToString();
            tb04.Text = bestSolution.gene[4].ToString();
            tb05.Text = bestSolution.gene[5].ToString();
            tb06.Text = bestSolution.gene[6].ToString();
            tb07.Text = bestSolution.gene[7].ToString();
            tb08.Text = bestSolution.gene[8].ToString();
            tb10.Text = bestSolution.gene[9].ToString();
            tb11.Text = bestSolution.gene[10].ToString();
            tb12.Text = bestSolution.gene[11].ToString();
            tb13.Text = bestSolution.gene[12].ToString();
            tb14.Text = bestSolution.gene[13].ToString();
            tb15.Text = bestSolution.gene[14].ToString();
            tb16.Text = bestSolution.gene[15].ToString();
            tb17.Text = bestSolution.gene[16].ToString();
            tb18.Text = bestSolution.gene[17].ToString();
            tb20.Text = bestSolution.gene[18].ToString();
            tb21.Text = bestSolution.gene[19].ToString();
            tb22.Text = bestSolution.gene[20].ToString();
            tb23.Text = bestSolution.gene[21].ToString();
            tb24.Text = bestSolution.gene[22].ToString();
            tb25.Text = bestSolution.gene[23].ToString();
            tb26.Text = bestSolution.gene[24].ToString();
            tb27.Text = bestSolution.gene[25].ToString();
            tb28.Text = bestSolution.gene[26].ToString();
            tb30.Text = bestSolution.gene[27].ToString();
            tb31.Text = bestSolution.gene[28].ToString();
            tb32.Text = bestSolution.gene[29].ToString();
            tb33.Text = bestSolution.gene[30].ToString();
            tb34.Text = bestSolution.gene[31].ToString();
            tb35.Text = bestSolution.gene[32].ToString();
            tb36.Text = bestSolution.gene[33].ToString();
            tb37.Text = bestSolution.gene[34].ToString();
            tb38.Text = bestSolution.gene[35].ToString();
            tb40.Text = bestSolution.gene[36].ToString();
            tb41.Text = bestSolution.gene[37].ToString();
            tb42.Text = bestSolution.gene[38].ToString();
            tb43.Text = bestSolution.gene[39].ToString();
            tb44.Text = bestSolution.gene[40].ToString();
            tb45.Text = bestSolution.gene[41].ToString();
            tb46.Text = bestSolution.gene[42].ToString();
            tb47.Text = bestSolution.gene[43].ToString();
            tb48.Text = bestSolution.gene[44].ToString();
            tb50.Text = bestSolution.gene[45].ToString();
            tb51.Text = bestSolution.gene[46].ToString();
            tb52.Text = bestSolution.gene[47].ToString();
            tb53.Text = bestSolution.gene[48].ToString();
            tb54.Text = bestSolution.gene[49].ToString();
            tb55.Text = bestSolution.gene[50].ToString();
            tb56.Text = bestSolution.gene[51].ToString();
            tb57.Text = bestSolution.gene[52].ToString();
            tb58.Text = bestSolution.gene[53].ToString();
            tb60.Text = bestSolution.gene[54].ToString();
            tb61.Text = bestSolution.gene[55].ToString();
            tb62.Text = bestSolution.gene[56].ToString();
            tb63.Text = bestSolution.gene[57].ToString();
            tb64.Text = bestSolution.gene[58].ToString();
            tb65.Text = bestSolution.gene[59].ToString();
            tb66.Text = bestSolution.gene[60].ToString();
            tb67.Text = bestSolution.gene[61].ToString();
            tb68.Text = bestSolution.gene[62].ToString();
            tb70.Text = bestSolution.gene[63].ToString();
            tb71.Text = bestSolution.gene[64].ToString();
            tb72.Text = bestSolution.gene[65].ToString();
            tb73.Text = bestSolution.gene[66].ToString();
            tb74.Text = bestSolution.gene[67].ToString();
            tb75.Text = bestSolution.gene[68].ToString();
            tb76.Text = bestSolution.gene[69].ToString();
            tb77.Text = bestSolution.gene[70].ToString();
            tb78.Text = bestSolution.gene[71].ToString();
            tb80.Text = bestSolution.gene[72].ToString();
            tb81.Text = bestSolution.gene[73].ToString();
            tb82.Text = bestSolution.gene[74].ToString();
            tb83.Text = bestSolution.gene[75].ToString();
            tb84.Text = bestSolution.gene[76].ToString();
            tb85.Text = bestSolution.gene[77].ToString();
            tb86.Text = bestSolution.gene[78].ToString();
            tb87.Text = bestSolution.gene[79].ToString();
            tb88.Text = bestSolution.gene[80].ToString();
            #endregion
            count++;
            lbGeneration.Text = "Generation: " + count;
            lbPenalty.Text = "Penalty: " + bestSolution.penalty;
            if (count >= ga.generationsNumber)
            {
                timer.Enabled = false;
                btGo.Enabled = true;
            }
        }
    }
}
