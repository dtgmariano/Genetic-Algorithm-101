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
        Random random;
        GA myGA;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myGA = new GA(this.random, 6);
            richTextBox1.Clear(); 
            richTextBox2.Clear();
            richTextBox1.AppendText("Parent A\n");
            richTextBox2.AppendText("Parent B\n");
            for(int i=0; i<myGA.ncities; i++)
            {
                richTextBox1.AppendText(myGA.parentA[i] + "");
                richTextBox2.AppendText(myGA.parentB[i] + "");
            }

            myGA.PMX();
            richTextBox1.AppendText("\nOffspring A\n");
            richTextBox2.AppendText("\nOffspring B\n");
            for (int i = 0; i < myGA.ncities; i++)
            {
                richTextBox1.AppendText(myGA.offspringA[i] + "");
                richTextBox2.AppendText(myGA.offspringB[i] + "");
            }


            
        }
    }
}
