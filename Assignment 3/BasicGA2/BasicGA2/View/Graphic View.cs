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

        //Chromossome champion;
        double avgResponse;

        /*Timer Process Variables*/
        bool startGA_flag = false;
        int nog_count;

        /*Constructor*/

        public Graphic_View(int _min, int _max, int _res, 
            int _popsize, int _numgenerations, double _probcrossover, double _probmutation,
            bool _hasranking, bool _haselitism, double _elitism_perc, 
            int _selec_op, int _cross_op, int _mutant_op, int _optim_op)
        {
            InitializeComponent();
            myGA = new GA(_min, _max, _res,
                _popsize, _numgenerations, _probcrossover, _probmutation,
                _hasranking, _haselitism, _elitism_perc,
                _selec_op, _cross_op, _mutant_op, _optim_op, random);

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
            
            rtbInfo.AppendText("Chromossome parameters\n");
            rtbInfo.AppendText("Minimum: " + myGA.min + "\n");
            rtbInfo.AppendText("Maximum: " + myGA.max + "\n");
            rtbInfo.AppendText("Resolution: " + myGA.res + "\n\n");

            rtbInfo.AppendText("GA parameters\n");
            rtbInfo.AppendText("Population size: " + myGA.probcrossover + "\n");
            rtbInfo.AppendText("Number of generations: " + myGA.numgenerations + "\n");
            rtbInfo.AppendText("Probability of crossover: " + myGA.probcrossover + "\n");
            rtbInfo.AppendText("Probability of mutation: " + myGA.probmutation + "\n");
            rtbInfo.AppendText("Elitism: " + myGA.hasElitism + " Counter: " + myGA.elitism_counter + "\n\n");

            rtbInfo.AppendText("Beginning GA!\n");

            myGA.beginStep();

            GAPointsRPPL.Clear();
            for (int i = 0; i < myGA.popsize; i++)
                GAPointsRPPL.Add(myGA.population[i].x, Equation.Fx(myGA.population[i].x));

            avgResponse = myGA.getAverageResponse();

            PCavgPointsRPPL.Add(nog_count, avgResponse);
            PCmaxPointsRPPL.Add(nog_count, myGA.champion.fx);
            rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(myGA.champion.x, 2) + " F(x): " + Math.Round(myGA.champion.fx, 2) + "\n");

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
                GAPointsRPPL.Add(myGA.population[i].x, Equation.Fx(myGA.population[i].x));

            avgResponse = myGA.getAverageResponse();

            PCavgPointsRPPL.Add(nog_count, avgResponse);
            PCmaxPointsRPPL.Add(nog_count, myGA.champion.fx);
            rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(myGA.champion.x, 2) + " F(x): " + Math.Round(myGA.champion.fx, 2) + "\n");

            zgcFunction.Invalidate();
            zgcPerformance.Invalidate();

            nog_count++;

            if (nog_count >= myGA.numgenerations)
                GenAlgTimer.Enabled = false;
        }
    }
}
