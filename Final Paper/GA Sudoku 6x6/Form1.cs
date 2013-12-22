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
            ps = 30000;
            ng = 100;
            pc = 0.2;
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
            zgcPerformance.GraphPane.YAxis.Scale.Max = ChromossomeStrategy.maxFitness + 5;
            zgcPerformance.GraphPane.YAxis.Scale.MinorStep = 25;
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

            tb10.Text = myGA.champion.chromossome[6].ToString();
            tb11.Text = myGA.champion.chromossome[7].ToString();
            tb12.Text = myGA.champion.chromossome[8].ToString();
            tb13.Text = myGA.champion.chromossome[9].ToString();
            tb14.Text = myGA.champion.chromossome[10].ToString();
            tb15.Text = myGA.champion.chromossome[11].ToString();

            tb20.Text = myGA.champion.chromossome[12].ToString();
            tb21.Text = myGA.champion.chromossome[13].ToString();
            tb22.Text = myGA.champion.chromossome[14].ToString();
            tb23.Text = myGA.champion.chromossome[15].ToString();
            tb24.Text = myGA.champion.chromossome[16].ToString();
            tb25.Text = myGA.champion.chromossome[17].ToString();

            tb30.Text = myGA.champion.chromossome[18].ToString();
            tb31.Text = myGA.champion.chromossome[19].ToString();
            tb32.Text = myGA.champion.chromossome[20].ToString();
            tb33.Text = myGA.champion.chromossome[21].ToString();
            tb34.Text = myGA.champion.chromossome[22].ToString();
            tb35.Text = myGA.champion.chromossome[23].ToString();

            tb40.Text = myGA.champion.chromossome[24].ToString();
            tb41.Text = myGA.champion.chromossome[25].ToString();
            tb42.Text = myGA.champion.chromossome[26].ToString();
            tb43.Text = myGA.champion.chromossome[27].ToString();
            tb44.Text = myGA.champion.chromossome[28].ToString();
            tb45.Text = myGA.champion.chromossome[29].ToString();

            tb50.Text = myGA.champion.chromossome[30].ToString();
            tb51.Text = myGA.champion.chromossome[31].ToString();
            tb52.Text = myGA.champion.chromossome[32].ToString();
            tb53.Text = myGA.champion.chromossome[33].ToString();
            tb54.Text = myGA.champion.chromossome[34].ToString();
            tb55.Text = myGA.champion.chromossome[35].ToString();

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
