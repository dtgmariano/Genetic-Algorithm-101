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
        Chromossome chromo;
        Random random;

        public TestView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //random = new Random();
            //chromo = new Chromossome(50, random);

            //foreach (City c in chromo.cities)
            //{
            //    richTextBox1.AppendText(c.x + " " + c.y + "\n");
            //}
            //richTextBox2.AppendText(chromo.fitness + "\n");
        }
    }
}
