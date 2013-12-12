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
    public partial class View : Form
    {
        Random random;
        List<char> parent1, parent2, child1, child2;

        public View()
        {
            InitializeComponent();
            random = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cutoff1 = 3; int cutoff2 = 7;
            string parentA_seq = "8473625190"; 
            string parentB_seq = "0123456789";

            parent1 = new List<char>();
            for (int i = 0; i < parentA_seq.Length; i++)
                parent1.Add(parentA_seq[i]);

            parent2 = new List<char>();
            for (int i = 0; i < parentB_seq.Length; i++)
                parent2.Add(parentB_seq[i]);

            child1 = CrossoverStrategy.pmx(parent1, parent2, cutoff1, cutoff2);
            child2 = CrossoverStrategy.pmx(parent2, parent1, cutoff1, cutoff2);
            print();
        }

        private void print()
        {
            for (int i = 0; i < parent1.Count(); i++)
                richTextBox1.AppendText(parent1[i] + "");
            richTextBox1.AppendText("\n");

            for (int i = 0; i < parent2.Count(); i++)
                richTextBox1.AppendText(parent2[i] + "");
            richTextBox1.AppendText("\n");

            for (int i = 0; i < child1.Count(); i++)
                richTextBox1.AppendText(child1[i] + "");
            richTextBox1.AppendText("\n");

            for (int i = 0; i < child2.Count(); i++)
                richTextBox1.AppendText(child2[i] + "");
            richTextBox1.AppendText("\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }


    }
}
