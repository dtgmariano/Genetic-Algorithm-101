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
            ps = 100;
            ng = 30;
            pc = 0.6;
            pm = 0.2;
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
            tb10.Text = myGA.champion.chromossome[3].ToString();
            tb11.Text = myGA.champion.chromossome[4].ToString();
            tb12.Text = myGA.champion.chromossome[5].ToString();
            tb20.Text = myGA.champion.chromossome[6].ToString();
            tb21.Text = myGA.champion.chromossome[7].ToString();
            tb22.Text = myGA.champion.chromossome[8].ToString();
            label1.Text = "Penalty Score: " + myGA.champion.penalty;

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
            timer.Interval = 100;
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
