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
    public partial class User_Inputs_View : Form
    {
        int ps, ng, rmin, rmax, gran, selec_op, cross_op, mutant_op, optim_op;
        double pc, pm, elite_percent;
        bool hasElite, hasRanking;

        public User_Inputs_View()
        {
            InitializeComponent();
            setInitialParameters();
        }

        private void setInitialParameters()
        {
            numPS.Value = 20;
            numNG.Value = 20;
            tbPc.Value = 60;
            tbPm.Value = 1;
            //numRMin.Value = 0;
            //numRMax.Value = 512;
            //tbRes.Value = 0;
            tbElitism.Value = 0;
            cbSelection.SelectedIndex = 0;
            cbCrossover.SelectedIndex = 0;
            cbMutation.SelectedIndex = 0;
            cbOptimization.SelectedIndex = 0;
        }

        public void CapturesInputs()
        {
            ps = (int)numPS.Value;
            ng = (int)numNG.Value;
            pc = ((int)tbPc.Value) / 100.0;
            pm = ((int)tbPm.Value) / 100.0;
            //rmin = (int)numRMin.Value;
            //rmax = (int)numRMax.Value;
            //gran = (int)tbRes.Value;

            selec_op = cbSelection.SelectedIndex;
            cross_op = cbCrossover.SelectedIndex;
            mutant_op = cbMutation.SelectedIndex;
            optim_op = cbOptimization.SelectedIndex;
            elite_percent = (int)tbElitism.Value / 100.0;
            hasRanking = cbRanking.Enabled;

            if (elite_percent != 0)
                hasElite = true;
            else
                hasElite = false;
        }

        public void ThreadProc()
        {
            Application.Run(new TestView(ps, ng, pc, pm, elite_percent));
        }

        public void ThreadProc2()
        {

        }

        private void btGo_Click(object sender, EventArgs e)
        {
            CapturesInputs();
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
        }


        private void btGoSt_Click(object sender, EventArgs e)
        {
            CapturesInputs();
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc2));
            t.Start();
        }

        private void tbElitism_ValueChanged(object sender, EventArgs e)
        {
            lbElitism.Text = tbElitism.Value + " %";
        }

        private void tbPc_ValueChanged(object sender, EventArgs e)
        {
            lbPc.Text = tbPc.Value + "%";
        }

        private void tbPm_ValueChanged(object sender, EventArgs e)
        {
            lbPm.Text = tbPm.Value + "%";
        }

        private void tbRes_ValueChanged(object sender, EventArgs e)
        {
            //lbRes.Text = tbRes.Value + "";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
}
