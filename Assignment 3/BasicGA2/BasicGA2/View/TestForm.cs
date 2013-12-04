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
            myGA = new GA(random);

            myGA.beginStep();
            for (int i = 0; i < myGA.population.Count(); i++)
                richTextBox1.AppendText(myGA.population[i].value.ToString() + " " + Math.Round(myGA.population[i].fitness,2).ToString() + "\n");

            myGA.elitismStep();
            for (int i = 0; i < myGA.elite.Count(); i++)
                richTextBox2.AppendText(myGA.elite[i].value.ToString() + " " + Math.Round(myGA.elite[i].fitness, 2).ToString() + "\n");

            myGA.selectionStep();
            for (int i = 0; i < myGA.parents.Count(); i++)
                richTextBox3.AppendText(myGA.parents[i].value.ToString() + " " + Math.Round(myGA.parents[i].fitness, 2).ToString() + "\n");

        }
    }
}
