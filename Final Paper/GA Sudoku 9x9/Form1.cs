using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace GA
{
    public partial class Form1 : Form
    {
        GA myGA;
        int ps, ng;
        double pc, pm, ep;
        Random random;
        int tickCount;

        RollingPointPairList PCavgPointsRPPL = new RollingPointPairList(1000); //Performance Curve Population List Points
        LineItem PCavgPointsLI;
        RollingPointPairList PCmaxPointsRPPL = new RollingPointPairList(1000); //Performance Curve Population List Points
        LineItem PCmaxPointsLI;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            PCavgPointsLI = zgcPerformance.GraphPane.AddCurve("f(Xavg)", PCavgPointsRPPL, Color.Red, SymbolType.Diamond);
            PCmaxPointsLI = zgcPerformance.GraphPane.AddCurve("f(Xbest)", PCmaxPointsRPPL, Color.Blue, SymbolType.Circle);
            
        }

        private void captureInputs()
        {
            ps = 50000;
            ng = 150;
            pc = 0.6;
            pm = 0.5;
            ep = 0;
        }

        private void setGraphSettings()
        {
            zgcPerformance.GraphPane.Title.Text = "Performance Curve";
            zgcPerformance.GraphPane.XAxis.Title.Text = "Generation";
            zgcPerformance.GraphPane.YAxis.Title.Text = "x";

            zgcPerformance.GraphPane.XAxis.Scale.Min = 0;
            zgcPerformance.GraphPane.XAxis.Scale.Max = Convert.ToDouble(myGA.generationsNumber);
            zgcPerformance.GraphPane.XAxis.Scale.MaxAuto = true;
            zgcPerformance.GraphPane.XAxis.Scale.MinorStep = 1;
            zgcPerformance.GraphPane.XAxis.Scale.MajorStep = 5;
            zgcPerformance.GraphPane.YAxis.Scale.Min = 0;
            zgcPerformance.GraphPane.YAxis.Scale.Max = 2;
            zgcPerformance.GraphPane.YAxis.Scale.MinorStep = 1;
            zgcPerformance.GraphPane.YAxis.Scale.MajorStep = 100;
        }

        private void updateInfo()
        {
            tb00.Text = myGA.champion.chromossome[0].ToString();
            tb01.Text = myGA.champion.chromossome[1].ToString();
            tb02.Text = myGA.champion.chromossome[2].ToString();
            tb03.Text = myGA.champion.chromossome[3].ToString();
            tb04.Text = myGA.champion.chromossome[4].ToString();
            tb05.Text = myGA.champion.chromossome[5].ToString();
            tb06.Text = myGA.champion.chromossome[6].ToString();
            tb07.Text = myGA.champion.chromossome[7].ToString();
            tb08.Text = myGA.champion.chromossome[8].ToString();

            tb10.Text = myGA.champion.chromossome[9].ToString();
            tb11.Text = myGA.champion.chromossome[10].ToString();
            tb12.Text = myGA.champion.chromossome[11].ToString();
            tb13.Text = myGA.champion.chromossome[12].ToString();
            tb14.Text = myGA.champion.chromossome[13].ToString();
            tb15.Text = myGA.champion.chromossome[14].ToString();
            tb16.Text = myGA.champion.chromossome[15].ToString();
            tb17.Text = myGA.champion.chromossome[16].ToString();
            tb18.Text = myGA.champion.chromossome[17].ToString();

            tb20.Text = myGA.champion.chromossome[18].ToString();
            tb21.Text = myGA.champion.chromossome[19].ToString();
            tb22.Text = myGA.champion.chromossome[20].ToString();
            tb23.Text = myGA.champion.chromossome[21].ToString();
            tb24.Text = myGA.champion.chromossome[22].ToString();
            tb25.Text = myGA.champion.chromossome[23].ToString();
            tb26.Text = myGA.champion.chromossome[24].ToString();
            tb27.Text = myGA.champion.chromossome[25].ToString();
            tb28.Text = myGA.champion.chromossome[26].ToString();

            tb30.Text = myGA.champion.chromossome[27].ToString();
            tb31.Text = myGA.champion.chromossome[28].ToString();
            tb32.Text = myGA.champion.chromossome[29].ToString();
            tb33.Text = myGA.champion.chromossome[30].ToString();
            tb34.Text = myGA.champion.chromossome[31].ToString();
            tb35.Text = myGA.champion.chromossome[32].ToString();
            tb36.Text = myGA.champion.chromossome[33].ToString();
            tb37.Text = myGA.champion.chromossome[34].ToString();
            tb38.Text = myGA.champion.chromossome[35].ToString();

            tb40.Text = myGA.champion.chromossome[36].ToString();
            tb41.Text = myGA.champion.chromossome[37].ToString();
            tb42.Text = myGA.champion.chromossome[38].ToString();
            tb43.Text = myGA.champion.chromossome[39].ToString();
            tb44.Text = myGA.champion.chromossome[40].ToString();
            tb45.Text = myGA.champion.chromossome[41].ToString();
            tb46.Text = myGA.champion.chromossome[42].ToString();
            tb47.Text = myGA.champion.chromossome[43].ToString();
            tb48.Text = myGA.champion.chromossome[44].ToString();

            tb50.Text = myGA.champion.chromossome[45].ToString();
            tb51.Text = myGA.champion.chromossome[46].ToString();
            tb52.Text = myGA.champion.chromossome[47].ToString();
            tb53.Text = myGA.champion.chromossome[48].ToString();
            tb54.Text = myGA.champion.chromossome[49].ToString();
            tb55.Text = myGA.champion.chromossome[50].ToString();
            tb56.Text = myGA.champion.chromossome[51].ToString();
            tb57.Text = myGA.champion.chromossome[52].ToString();
            tb58.Text = myGA.champion.chromossome[53].ToString();

            tb60.Text = myGA.champion.chromossome[54].ToString();
            tb61.Text = myGA.champion.chromossome[55].ToString();
            tb62.Text = myGA.champion.chromossome[56].ToString();
            tb63.Text = myGA.champion.chromossome[57].ToString();
            tb64.Text = myGA.champion.chromossome[58].ToString();
            tb65.Text = myGA.champion.chromossome[59].ToString();
            tb66.Text = myGA.champion.chromossome[60].ToString();
            tb67.Text = myGA.champion.chromossome[61].ToString();
            tb68.Text = myGA.champion.chromossome[62].ToString();

            tb70.Text = myGA.champion.chromossome[63].ToString();
            tb71.Text = myGA.champion.chromossome[64].ToString();
            tb72.Text = myGA.champion.chromossome[65].ToString();
            tb73.Text = myGA.champion.chromossome[66].ToString();
            tb74.Text = myGA.champion.chromossome[67].ToString();
            tb75.Text = myGA.champion.chromossome[68].ToString();
            tb76.Text = myGA.champion.chromossome[69].ToString();
            tb77.Text = myGA.champion.chromossome[70].ToString();
            tb78.Text = myGA.champion.chromossome[71].ToString();

            tb80.Text = myGA.champion.chromossome[72].ToString();
            tb81.Text = myGA.champion.chromossome[73].ToString();
            tb82.Text = myGA.champion.chromossome[74].ToString();
            tb83.Text = myGA.champion.chromossome[75].ToString();
            tb84.Text = myGA.champion.chromossome[76].ToString();
            tb85.Text = myGA.champion.chromossome[77].ToString();
            tb86.Text = myGA.champion.chromossome[78].ToString();
            tb87.Text = myGA.champion.chromossome[79].ToString();
            tb88.Text = myGA.champion.chromossome[80].ToString();

            label1.Text = "Penalty Score: " + myGA.champion.penalty;
            label2.Text = "Generation: " + tickCount;

            double fitn = myGA.population.Average(innerList => innerList.fitness);

            PCavgPointsRPPL.Add(tickCount, fitn);
            PCmaxPointsRPPL.Add(tickCount, myGA.champion.fitness);
            zgcPerformance.Invalidate();

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            captureInputs();
            myGA = new GA(ps, ng, pc, pm, ep, random);
            setGraphSettings();
            myGA.populateProcedure();
            updateInfo();
            tickCount++;
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            timer.Interval = 30;
            timer.Enabled = true;
            btGo.Enabled = false;
            btStart.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            myGA.elitismProcedure();
            myGA.selectionProcedure();
            myGA.crossoverProcedure();
            myGA.mutationProcedure();
            myGA.updtadeProcedure();
            updateInfo();
            tickCount++;
            if (tickCount >= myGA.generationsNumber || myGA.champion.fitness == ChromossomeStrategy.maxFitness)
            {
                timer.Enabled = false;
                btGo.Enabled = true;
                btStart.Enabled = true;
            }
        }
    }
}
