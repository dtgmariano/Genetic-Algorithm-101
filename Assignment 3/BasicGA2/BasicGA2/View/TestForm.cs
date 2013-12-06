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
    public partial class TestForm : Form
    {
        Random random;
        GA myGA;

        public TestForm()
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

            myGA = new GA(random);

            myGA.beginStep();
            label1.Text = "beginStep";
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox1.AppendText(myGA.population[i].x.ToString() + " " + Math.Round(myGA.population[i].fitness,2).ToString() + "\n");

            myGA.elitismStep();
            label2.Text = "elitismStep";
            for (int i = 0; i < myGA.elite.Count(); i++)
                richTextBox2.AppendText(myGA.elite[i].x.ToString() + " " + Math.Round(myGA.elite[i].fitness, 2).ToString() + "\n");

            myGA.selectionStep();
            label3.Text = "selectionStep" ;
            for (int i = 0; i < myGA.parents.Count(); i++)
                richTextBox3.AppendText(myGA.parents[i].x.ToString() + " " + Math.Round(myGA.parents[i].fitness, 2).ToString() + "\n");

            myGA.crossoverStep();
            label4.Text = "crossoverStep " + myGA.countcrossover;
            for (int i = 0; i < myGA.offspring.Count(); i++)
                richTextBox4.AppendText(myGA.offspring[i].x.ToString() + " " + Math.Round(myGA.offspring[i].fitness, 2).ToString() + "\n");

            myGA.mutationStep();
            label5.Text = "mutationStep" + myGA.countmutation;
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox5.AppendText(myGA.population[i].x.ToString() + " " + Math.Round(myGA.population[i].fitness, 2).ToString() + "\n");

            myGA.updateStep();
            label6.Text = "updateStep";
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox6.AppendText(myGA.population[i].x.ToString() + " " + Math.Round(myGA.population[i].fitness, 2).ToString() + "\n");

        }
    }
}
