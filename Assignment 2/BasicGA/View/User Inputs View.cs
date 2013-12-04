using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicGA
{
    public partial class User_Inputs_View : Form
    {
        int ps, ng, pc, pm, rmin, rmax, gran, elit_count, selec_op, cross_op, mutat_op, optim_op;

        public User_Inputs_View()
        {
            InitializeComponent();
            setInitialParameters();
        }

        private void setInitialParameters()
        {
            numPS.Value = 50;
            numNG.Value = 20;
            numPC.Value = 60;
            numPM.Value = 1;
            numRMin.Value = 0;
            numRMax.Value = 511;
            numGran.Value = 0;
            cbSelection.SelectedIndex = 0;
            cbCrossover.SelectedIndex = 0;
            cbMutation.SelectedIndex = 0;
            cbOptimization.SelectedIndex = 0;
            cbElitism.SelectedIndex = 0;
        }

        public void CapturesInputs()
        {
            ps = (int)numPS.Value;
            ng = (int)numNG.Value;
            pc = (int)numPC.Value;
            pm = (int)numPM.Value;
            rmin = (int)numRMin.Value;
            rmax = (int)numRMax.Value;
            gran = (int)numGran.Value;

            selec_op = cbSelection.SelectedIndex;
            cross_op = cbCrossover.SelectedIndex;
            optim_op = cbOptimization.SelectedIndex;

            ValidatesInputs();
        }

        public void ValidatesInputs()
        {
            if (cbElitism.SelectedIndex == 0)
            {
                numEC.Enabled = false;
                elit_count = 0;
            }
            else
            {
                numEC.Enabled = true;
                numEC.Maximum = ps;
                elit_count = (int)numEC.Value;
            }
        }

        public void ThreadProc()
        {
            Application.Run(new Graphic_View(ps, ng, pc, pm, rmin, rmax, gran, selec_op, cross_op, optim_op));
        }

        public void ThreadProc2()
        {
            Application.Run(new Statistics_View(ps, ng, pc, pm, rmin, rmax, gran, selec_op, cross_op, optim_op));
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            CapturesInputs();
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
        }

        private void cbElitism_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbElitism.SelectedIndex == 0)
                numEC.Enabled = false;
            else
                numEC.Enabled = true;
        }

        private void btGoSt_Click(object sender, EventArgs e)
        {
            CapturesInputs();
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc2));
            t.Start();
        }
    }
}
