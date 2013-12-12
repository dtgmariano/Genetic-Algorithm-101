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
    public partial class MapView : Form
    {
        /*GUI Variables Declared -> Related to ZedGraph*/
        RollingPointPairList GAPointsRPPL = new RollingPointPairList(1000); //GA Population List Points
        LineItem GAPointsLI;
        World myWorld;
        GA myGA;
        Chromossome myChromossome;
        Random random;

        /*Constructor*/
        public MapView()
        {
            InitializeComponent();
            setGraphSettings();
            GAPointsLI = zgcMap.GraphPane.AddCurve("Cities", GAPointsRPPL, Color.Blue, SymbolType.Circle);
            GAPointsLI.Line.IsVisible = true;
        }

        /*Sets ZedGraph Scales*/
        private void setGraphSettings()
        {
            zgcMap.GraphPane.Title.Text = "TSP";
            zgcMap.GraphPane.XAxis.Title.Text = "X";
            zgcMap.GraphPane.YAxis.Title.Text = "Y";

            zgcMap.GraphPane.XAxis.Scale.Min = -100;
            zgcMap.GraphPane.XAxis.Scale.Max = 100;
            zgcMap.GraphPane.XAxis.Scale.MaxAuto = true;
            zgcMap.GraphPane.XAxis.Scale.MinorStep = 1;
            zgcMap.GraphPane.XAxis.Scale.MajorStep = 10;

            zgcMap.GraphPane.YAxis.Scale.Min = -100;
            zgcMap.GraphPane.YAxis.Scale.Max = 100;
            //zgcMap.GraphPane.YAxis.Scale.MaxAuto = true;
            zgcMap.GraphPane.YAxis.Scale.MinorStep = 1;
            zgcMap.GraphPane.YAxis.Scale.MajorStep = 10;
        }


        private void btGo_Click(object sender, EventArgs e)
        {
            int nc = Convert.ToInt32(numericUpDown1.Value);

            this.random = new Random();
            this.myWorld = new World(nc, this.random);
            this.myGA = new GA(myWorld, 20, 2, 0.6, 0.1, 0, 0, 0, 0, random);

            myGA.beginStep();
            myGA.elitismStep();
            myGA.selectionStep();
            //myGA.crossoverStep();

            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();

            foreach (Chromossome c in myGA.population)
            {
                richTextBox1.AppendText(c.fitness + "\n");
            }
            richTextBox1.AppendText(myGA.champion.fitness + "\n");

            foreach (Chromossome c in myGA.elite)
            {
                richTextBox2.AppendText(c.fitness + "\n");
            }

            foreach (Chromossome c in myGA.parents)
            {
                richTextBox3.AppendText(c.fitness + "\n");
            }

            foreach (Chromossome c in myGA.offspring)
            {
                richTextBox4.AppendText(c.fitness + "\n");
            }
            
            //GAPointsRPPL.Clear();
            //for (int i = 0; i < myGA.champion.nbits; i++)
            //    GAPointsRPPL.Add(myGA.champion.cities[i].x, myGA.champion.cities[i].y);

            //zgcMap.Invalidate();
        }
    }
}
