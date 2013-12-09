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
    public partial class TestView : Form
   {
        Random random;
        GA myGA;
        Chromossome myChromossome;
        int count;

        public TestView()
        {
            InitializeComponent();
            random = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();

            myGA = new GA(0, 16, 0, 50, 20, 1.0, 1.0, false, true, 0.1, 0, 0, 0, 1, random);

            myGA.beginStep();
            label1.Text = "beginStep";
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox1.AppendText(myGA.population[i].x.ToString() + " " + myGA.population[i].y.ToString() + " " + Math.Round(myGA.population[i].fitness, 2).ToString() + "\n");

            myGA.elitismStep();
            label2.Text = "elitismStep";
            for (int i = 0; i < myGA.elite.Count(); i++)
                richTextBox2.AppendText(myGA.elite[i].x.ToString() + " " + myGA.elite[i].y.ToString() + " " + Math.Round(myGA.elite[i].fitness, 2).ToString() + "\n");

            myGA.selectionStep();
            label3.Text = "selectionStep";
            for (int i = 0; i < myGA.parents.Count(); i++)
                richTextBox3.AppendText(myGA.parents[i].x.ToString() + " " + myGA.parents[i].y.ToString() + " " + Math.Round(myGA.parents[i].fitness, 2).ToString() + "\n");

            myGA.crossoverStep();
            label4.Text = "crossoverStep " + myGA.countcrossover;
            for (int i = 0; i < myGA.offspring.Count(); i++)
                richTextBox4.AppendText(myGA.offspring[i].x.ToString() + " " + myGA.offspring[i].y.ToString() + " " + Math.Round(myGA.offspring[i].fitness, 2).ToString() + "\n");

            myGA.mutationStep();
            label5.Text = "mutationStep" + myGA.countmutation;
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox5.AppendText(myGA.population[i].x.ToString() + " " + myGA.population[i].y.ToString() + " " + Math.Round(myGA.population[i].fitness, 2).ToString() + "\n");

            myGA.updateStep();
            label6.Text = "updateStep";
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox6.AppendText(myGA.population[i].x.ToString() + " " + myGA.population[i].y.ToString() + " " + Math.Round(myGA.population[i].fitness, 2).ToString() + "\n");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = 0;
            myGA = new GA(0, 512, 0, 20, 10, 0.6, 0.1, false, true, 0.1, 0, 0, 0, 0, random);
            myGA.beginStep();
            count++;
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox1.AppendText(myGA.population[i].x.ToString() + " " + myGA.population[i].y.ToString() + " " + Math.Round(myGA.population[i].fitness, 2).ToString() + "\n");
            
            timer1.Interval = 200;
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            myGA.processesGA();
            count++;
            richTextBox1.Clear();
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox1.AppendText(myGA.population[i].x.ToString() + " " + myGA.population[i].y.ToString() + " " + Math.Round(myGA.population[i].fitness, 2).ToString() + "\n");
            if (count >= myGA.numgenerations)
                timer1.Enabled = false;
        }
    }
}
