using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GA
{
    public partial class TestView : Form
   {
        Random random;
        GA myGA;
        Individual myChromossome;
        int count;
        List<double> coords;

        public TestView(int _popsize,
            int _numgenerations,
            double _probcrossover,
            double _probmutation,
            double _elitism_percentage)
        {
            InitializeComponent();
            random = new Random();
            myGA = new GA(_popsize, _numgenerations, _probcrossover, _probmutation, _elitism_percentage, random);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Clear();
            myGA.populateProcedure();
            coords = ChromossomeStrategy.calculateCoords(myGA.champion.chromossome, myGA.champion.min, myGA.champion.max, myGA.champion.res, myGA.champion.nbits);
            //richTextBox1.AppendText("[" + coords[0] + "," + coords[1] + "] fit: " + myGA.champion.fitness.ToString()+"\n\n");
            richTextBox1.AppendText(myGA.champion.chromossome.ToString() + "\n");

            foreach (Individual i in myGA.population)
            {
                coords = ChromossomeStrategy.calculateCoords(i.chromossome, i.min, i.max,i.res, i.nbits);
                //richTextBox1.AppendText("[" + coords[0] + "," + coords[1] + "] fit: " + i.fitness.ToString() + "\n");
                richTextBox1.AppendText(i.chromossome.ToString() + "\n");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            timer1.Interval = 200;
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            myGA.elitismProcedure();
            myGA.selectionProcedure();
            myGA.crossoverProcedure();
            myGA.mutationProcedure();
            myGA.updtadeProcedure();

            richTextBox1.Clear();
            coords = ChromossomeStrategy.calculateCoords(myGA.champion.chromossome, myGA.champion.min, myGA.champion.max, myGA.champion.res, myGA.champion.nbits);
            richTextBox1.AppendText("[" + coords[0] + "," + coords[1] + "] fit: " + myGA.champion.fitness.ToString() + "\n\n");

            foreach (Individual i in myGA.population)
            {
                coords = ChromossomeStrategy.calculateCoords(i.chromossome, i.min, i.max, i.res, i.nbits);
                richTextBox1.AppendText("[" + coords[0] + "," + coords[1] + "] fit: " + i.fitness.ToString() + "\n");

            }
            count++;
            if (count >= myGA.generationsNumber)
                timer1.Enabled = false;
        }
    }
}
