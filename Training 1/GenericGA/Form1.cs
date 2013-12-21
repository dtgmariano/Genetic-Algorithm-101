using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericGA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<object> l = new List<object>();
            l.Add(10);
            l.Add("sasd");
            l.Add(true);
            l.Add(0.0);
            l.Add(new List<int>());

            foreach (object o in l)
                Console.WriteLine(o.GetType());
        }
    }
}
