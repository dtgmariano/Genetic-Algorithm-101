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
            GA = new GeneticAlgorithm(50, 20, 0.8, 0.05, 0.1, startPoint, rnd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                for (int i = 0; i < GA.generationsNumber; i++)
                {
                    GA.processGeneration();
                    richTextBox1.AppendText(GA.champion.fitness.ToString()+"\n");

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
