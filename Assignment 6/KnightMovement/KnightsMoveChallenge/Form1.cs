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
        GeneticAlgorithm GA;
        Random rnd = new Random();
        Point startPoint = new Point(4, 4);

        public Form1()
        {
            InitializeComponent();

            rnd = new Random();
            startPoint = new Point(4, 4);

            //Point x, y;
            //string move;

            //x = new Point(3, 2);

            //move = "000";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            //move = "001";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            //move = "010";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            //move = "011";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            //move = "100";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            //move = "101";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            //move = "110";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            //move = "111";
            //y = ProblemStrategy.ReturnNextPosition(move, x);
            //Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GA = new GeneticAlgorithm(10, 10, 0.6, 0.1, 0.0, startPoint, rnd);
                foreach (Individual i in GA.population)
                {
                    richTextBox1.AppendText(i.fitness.ToString()+"\n");
                }

                 Console.WriteLine("test");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}
