using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace GA
{
    public partial class Graphic_View : Form
    {
        /*GUI Variables Declared -> Related to ZedGraph*/
        RollingPointPairList GAPointsRPPL = new RollingPointPairList(1000); //GA Population List Points
        LineItem GAPointsLI;
        RollingPointPairList EqPointsRPPL = new RollingPointPairList(10000); //Equation Function List Points
        LineItem EqPointsLI;
        RollingPointPairList PCavgPointsRPPL = new RollingPointPairList(1000); //Performance Curve Population List Points
        LineItem PCavgPointsLI;
        RollingPointPairList PCmaxPointsRPPL = new RollingPointPairList(1000); //Performance Curve Population List Points
        LineItem PCmaxPointsLI;

        Random random = new Random();
        //GeneticAlgorithm myGA;
        GA myGA;

        Chromossome champion;
        double avgResponse;

        /*Timer Process Variables*/
        bool startGA_flag = false;
        int nog_count;

        /*Constructor*/
        public Graphic_View()
        {
            InitializeComponent();
        }

        /*Overrided Constructor*/

        public Graphic_View(int rmin, int rmax, int gran,
            int ps, int ng, double pc, double pm,
            bool hasRanking, bool hasElite, int elite_counter, 
            int selec_op, int cross_op, int optim_op)
        {
            InitializeComponent();
            myGA = new GA(rmin, rmax, gran, ps, ng, pc, pm, hasRanking, hasElite, elite_counter, random);

            setGraphSettings();
            GAPointsLI = zgcFunction.GraphPane.AddCurve("GA Points", GAPointsRPPL, Color.Blue, SymbolType.Circle);
            GAPointsLI.Line.IsVisible = false;
            EqPointsLI = zgcFunction.GraphPane.AddCurve("Equation", EqPointsRPPL, Color.LightBlue, SymbolType.Default);
            PCavgPointsLI = zgcPerformance.GraphPane.AddCurve("f(Xavg)", PCavgPointsRPPL, Color.Red, SymbolType.Diamond);
            PCmaxPointsLI = zgcPerformance.GraphPane.AddCurve("f(Xbest)", PCmaxPointsRPPL, Color.Blue, SymbolType.Circle);

            setGraphFunction();
            //GenAlgTimer.Enabled = true;
            Go();
            PCavgPointsRPPL.Clear();
            PCmaxPointsRPPL.Clear();
        }

        /*Sets ZedGraph Scales*/
        private void setGraphSettings()
        {
            zgcFunction.GraphPane.Title.Text = "Genetic Algorithm Plot";
            zgcFunction.GraphPane.XAxis.Title.Text = "x";
            zgcFunction.GraphPane.YAxis.Title.Text = "f(x)";

            zgcFunction.GraphPane.XAxis.Scale.Min = Convert.ToDouble(myGA.min) - 20;
            zgcFunction.GraphPane.XAxis.Scale.Max = Convert.ToDouble(myGA.max) + 20;
            zgcFunction.GraphPane.XAxis.Scale.MaxAuto = true;
            zgcFunction.GraphPane.XAxis.Scale.MinorStep = 1;
            zgcFunction.GraphPane.XAxis.Scale.MajorStep = 100;
            zgcFunction.GraphPane.YAxis.Scale.Min = -Convert.ToDouble(myGA.max) + 50;
            zgcFunction.GraphPane.YAxis.Scale.Max = Convert.ToDouble(myGA.max) + 50;
            zgcFunction.GraphPane.YAxis.Scale.MinorStep = 25;
            zgcFunction.GraphPane.YAxis.Scale.MajorStep = 100;


            zgcPerformance.GraphPane.Title.Text = "Performance Curve";
            zgcPerformance.GraphPane.XAxis.Title.Text = "Generation";
            zgcPerformance.GraphPane.YAxis.Title.Text = "x";

            zgcPerformance.GraphPane.XAxis.Scale.Min = 0;
            zgcPerformance.GraphPane.XAxis.Scale.Max = Convert.ToDouble(myGA.numgenerations);
            zgcPerformance.GraphPane.XAxis.Scale.MaxAuto = true;
            zgcPerformance.GraphPane.XAxis.Scale.MinorStep = 1;
            zgcPerformance.GraphPane.XAxis.Scale.MajorStep = 5;
            zgcPerformance.GraphPane.YAxis.Scale.Min = -Convert.ToDouble(myGA.max) - 20;
            zgcPerformance.GraphPane.YAxis.Scale.Max = Convert.ToDouble(myGA.max) + 20;
            zgcPerformance.GraphPane.YAxis.Scale.MinorStep = 25;
            zgcPerformance.GraphPane.YAxis.Scale.MajorStep = 100;
        }

        /*Creates the curve for the equation type 1*/
        public void setGraphFunction()
        {
            setGraphSettings();
            EqPointsRPPL.Clear();
            double i = myGA.min;
            double j;
            while (i < myGA.max)
            {
                j = Equation.Fx(i);
                EqPointsRPPL.Add(i, j);

                i = i + 0.05;
            }
            zgcFunction.Invalidate();
        }

        private void Go()
        {
            myGA.beginStep();
            rtbInfo.AppendText("GA parameters per generation\n");

            GAPointsRPPL.Clear();
            for (int i = 0; i < myGA.popsize; i++)
                GAPointsRPPL.Add(myGA.population[i].value, Equation.Fx(myGA.population[i].value));

            champion = myGA.getChampion();
            avgResponse = myGA.getAverageResponse();

            PCavgPointsRPPL.Add(nog_count, avgResponse);
            PCmaxPointsRPPL.Add(nog_count, Equation.Fx(champion.value));
            rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(champion.value, 2) + " F(x): " + Math.Round(Equation.Fx(champion.value), 2) + "\n");

            zgcFunction.Invalidate();
            zgcPerformance.Invalidate();

            nog_count++;

            GenAlgTimer.Enabled = true;

        }

        private void GenAlgTimer_Tick(object sender, EventArgs e)
        {
            myGA.processesGA();

            GAPointsRPPL.Clear();
            for (int i = 0; i < myGA.popsize; i++)
                GAPointsRPPL.Add(myGA.population[i].value, Equation.Fx(myGA.population[i].value));

            champion = myGA.getChampion();
            avgResponse = myGA.getAverageResponse();

            PCavgPointsRPPL.Add(nog_count, avgResponse);
            PCmaxPointsRPPL.Add(nog_count, Equation.Fx(champion.value));
            rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(champion.value, 2) + " F(x): " + Math.Round(Equation.Fx(champion.value), 2) + "\n");

            zgcFunction.Invalidate();
            zgcPerformance.Invalidate();

            nog_count++;

            if (nog_count >= myGA.numgenerations)
                GenAlgTimer.Enabled = false;
        }

        //private void GenAlgTimer_Tick(object sender, EventArgs e)
        //{
        //    /*For the following Generation do*/
        //    if (startGA_flag == true)
        //    {
        //        myGA.elitismStep();
        //        myGA.selectionStep();
        //        myGA.crossoverStep();
        //        myGA.mutationStep();
        //        myGA.updateStep();
        //        nog_count++;  
        //    }
        //    /*For the first Generation do*/
        //    else
        //    {
        //        startGA_flag = true;

        //        myGA.beginStep();
        //        champion = myGA.getChampion();
        //        avgResponse = myGA.getAverageResponse();

        //        PCavgPointsRPPL.Add(nog_count, avgResponse);
        //        PCmaxPointsRPPL.Add(nog_count, Equation.Fx(champion.value));
        //        rtbInfo.AppendText("GA parameters per generation\n");
        //        rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(champion.value, 2) + " F(x): " + Math.Round(Equation.Fx(champion.value), 2) + "\n");


        //        UpdateGraphTimer.Enabled = true;
        //        //rtbInfo.AppendText("Gen.: 1 Max.: " + Math.Round(myGA.chromoValue.Max(), 2) + " Fit.: " + Math.Round(Equation.F1x(myGA.chromoValue.Max()),2) + "\n");
        //        myGA.elitismStep();
        //        myGA.selectionStep();
        //        myGA.crossoverStep();
        //        myGA.mutationStep();
        //        myGA.updateStep();

        //        nog_count++;
        //        UpdateGraphTimer.Enabled = true;
        //    }

        //    /*After reaching the number of generations value stops the GA process and the Graph Update Process*/
        //    if (nog_count >= myGA.numgenerations)
        //    {
        //        GenAlgTimer.Enabled = false;
        //        UpdateGraphTimer.Enabled = false;
        //        startGA_flag = false;
        //        nog_count = 0;
        //        rtbInfo.AppendText("GA Process has reached the end!\n");
        //        MessageBox.Show("GA Process has reached the end!");
        //        rtbInfo.AppendText(Math.Round(champion.value, 2) + "\t" + Math.Round(Equation.Fx(champion.value), 2) + "\n");

        //    }
        //}

        private void UpdateGraphTimer_Tick(object sender, EventArgs e)
        {
            GAPointsRPPL.Clear();
            for (int i = 0; i < myGA.popsize; i++)
                GAPointsRPPL.Add(myGA.population[i].value, Equation.Fx(myGA.population[i].value));

            champion = myGA.getChampion();
            avgResponse = myGA.getAverageResponse();

            PCavgPointsRPPL.Add(nog_count, avgResponse);
            PCmaxPointsRPPL.Add(nog_count, Equation.Fx(champion.value));
            rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(champion.value, 2) + " F(x): " + Math.Round(Equation.Fx(champion.value), 2) + "\n");

            zgcFunction.Invalidate();
            zgcPerformance.Invalidate();
        }


    }
}
