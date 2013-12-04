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
using Genetic_Algorithm;

namespace BasicGA
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
        GeneticAlgorithm myGA;

        /*Timer Process Variables*/
        bool startGA_flag = false;
        int nog_count;

        double champ;

        /*Constructor*/
        public Graphic_View()
        {
            InitializeComponent();
        }

        /*Overrided Constructor*/
        public Graphic_View(int ps, int ng, int pc, int pm, int rmin, int rmax, int gran, int selec_op, int cross_op, int optim_op)
        {
            InitializeComponent();
            myGA = new GeneticAlgorithm(rmin, rmax, gran, ps, ng, pc, pm, selec_op, cross_op, 1, optim_op, random);

            setGraphSettings();
            GAPointsLI = zgcFunction.GraphPane.AddCurve("GA Points", GAPointsRPPL, Color.Blue, SymbolType.Circle);
            GAPointsLI.Line.IsVisible = false;
            EqPointsLI = zgcFunction.GraphPane.AddCurve("Equation", EqPointsRPPL, Color.LightBlue, SymbolType.Default);
            PCavgPointsLI = zgcPerformance.GraphPane.AddCurve("f(Xavg)", PCavgPointsRPPL, Color.Red, SymbolType.Diamond);
            PCmaxPointsLI = zgcPerformance.GraphPane.AddCurve("f(Xbest)", PCmaxPointsRPPL, Color.Blue, SymbolType.Circle);
            
            setGraphFunction();
            GenAlgTimer.Enabled = true;
            PCavgPointsRPPL.Clear();
            PCmaxPointsRPPL.Clear();
        }

        /*Sets ZedGraph Scales*/
        private void setGraphSettings()
        {
            zgcFunction.GraphPane.Title.Text = "Genetic Algorithm Plot";
            zgcFunction.GraphPane.XAxis.Title.Text = "x";
            zgcFunction.GraphPane.YAxis.Title.Text = "f(x)";

            zgcFunction.GraphPane.XAxis.Scale.Min = Convert.ToDouble(myGA.rangeMin) - 20;
            zgcFunction.GraphPane.XAxis.Scale.Max = Convert.ToDouble(myGA.rangeMax) + 20;
            zgcFunction.GraphPane.XAxis.Scale.MaxAuto = true;
            zgcFunction.GraphPane.XAxis.Scale.MinorStep = 1;
            zgcFunction.GraphPane.XAxis.Scale.MajorStep = 100;
            zgcFunction.GraphPane.YAxis.Scale.Min = -Convert.ToDouble(myGA.rangeMax)+50;
            zgcFunction.GraphPane.YAxis.Scale.Max = 20;
            zgcFunction.GraphPane.YAxis.Scale.MinorStep = 25;
            zgcFunction.GraphPane.YAxis.Scale.MajorStep = 100;


            zgcPerformance.GraphPane.Title.Text = "Performance Curve";
            zgcPerformance.GraphPane.XAxis.Title.Text = "Generation";
            zgcPerformance.GraphPane.YAxis.Title.Text = "x";

            zgcPerformance.GraphPane.XAxis.Scale.Min = 0;
            zgcPerformance.GraphPane.XAxis.Scale.Max = Convert.ToDouble(myGA.numberGenerations);
            zgcPerformance.GraphPane.XAxis.Scale.MaxAuto = true;
            zgcPerformance.GraphPane.XAxis.Scale.MinorStep = 1;
            zgcPerformance.GraphPane.XAxis.Scale.MajorStep = 5;
            zgcPerformance.GraphPane.YAxis.Scale.Min = - Convert.ToDouble(myGA.rangeMax) - 20;
            zgcPerformance.GraphPane.YAxis.Scale.Max = 10;
            //zgcPerformance.GraphPane.YAxis.Scale.Min = Convert.ToDouble(myGA.rangeMin) - 20;
            //zgcPerformance.GraphPane.YAxis.Scale.Max = Convert.ToDouble(myGA.rangeMax) + 20;
            zgcPerformance.GraphPane.YAxis.Scale.MinorStep = 25;
            zgcPerformance.GraphPane.YAxis.Scale.MajorStep = 100;

            
        }

        /*Creates the curve for the equation type 1*/
        public void setGraphFunction()
        {
            setGraphSettings();
            EqPointsRPPL.Clear();
            double i = myGA.rangeMin;
            double j;
            while (i < myGA.rangeMax)
            {
                j = Equation.set(myGA.functionType, i);
                EqPointsRPPL.Add(i, j);

                i = i + 0.05;
            }
            zgcFunction.Invalidate();
        }

        private void GenAlgTimer_Tick(object sender, EventArgs e)
        {
            /*For the first Generation do*/
            if (startGA_flag == false)
            {
                startGA_flag = true;

                myGA.StartsPopulation();
                
                double champ = GetTheBestChromossome(myGA.chromoValue);
                PCavgPointsRPPL.Add(nog_count, (Equation.set(myGA.functionType, myGA.chromoValue.Average())));
                PCmaxPointsRPPL.Add(nog_count, (Equation.set(myGA.functionType, champ)));
                rtbInfo.AppendText("GA parameters per generation\n");
                rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(champ, 2) + " F(x): " + Math.Round(Equation.set(myGA.functionType, champ), 2) + "\n");


                UpdateGraphTimer.Enabled = true;
                //rtbInfo.AppendText("Gen.: 1 Max.: " + Math.Round(myGA.chromoValue.Max(), 2) + " Fit.: " + Math.Round(Equation.F1x(myGA.chromoValue.Max()),2) + "\n");
                myGA.SelectParents();
                myGA.Reproduction();
                nog_count++;
                UpdateGraphTimer.Enabled = true;
            }
            /*For the following Generation do*/
            else
            {
                myGA.SelectParents();
                myGA.Reproduction();
                nog_count++;
            }

            /*After reaching the number of generations value stops the GA process and the Graph Update Process*/
            if (nog_count >= myGA.numberGenerations)
            {
                GenAlgTimer.Enabled = false;
                UpdateGraphTimer.Enabled = false;
                startGA_flag = false;
                nog_count = 0;
                rtbInfo.AppendText("GA Process has reached the end!\n");
                MessageBox.Show("GA Process has reached the end!");
                rtbInfo.AppendText(Math.Round(champ, 2) + "\t" + Math.Round(Equation.set(myGA.functionType, champ), 2) + "\n");

            }
        }

        private void UpdateGraphTimer_Tick(object sender, EventArgs e)
        {
            GAPointsRPPL.Clear();
            for (int i = 0; i < myGA.populationSize; i++)
            {
                GAPointsRPPL.Add(myGA.chromoValue[i], Equation.set(myGA.functionType, myGA.chromoValue[i]));
            }

            champ = GetTheBestChromossome(myGA.chromoValue);

            PCavgPointsRPPL.Add(nog_count, (Equation.set(myGA.functionType, myGA.chromoValue.Average())));
            PCmaxPointsRPPL.Add(nog_count, (Equation.set(myGA.functionType, champ)));
            rtbInfo.AppendText("Gen.: " + (nog_count + 1) + " Best: " + Math.Round(champ, 2) + " F(x): " + Math.Round(Equation.set(myGA.functionType, champ), 2) + "\n");

            zgcFunction.Invalidate();
            zgcPerformance.Invalidate();
        }

        private double GetTheBestChromossome(List<double> population_values)
        {
            List<double> elite_values = population_values;
            List<double> elite_fitness = new List<double>();
            elite_fitness.Clear();

            for (int i = 0; i < elite_values.Count(); i++)
            {
                elite_fitness.Add(Fitness.set(myGA.functionType, myGA.optimizationType, elite_values[i]));
            }


            Array aelite_values = elite_values.ToArray();
            Array aelite_fitness = elite_fitness.ToArray();
            Array.Sort(aelite_fitness, aelite_values);

            elite_values = aelite_values.OfType<double>().ToList();
            elite_fitness = aelite_fitness.OfType<double>().ToList();

            elite_values.Reverse();

            return elite_values[0];
        }

    }
}
