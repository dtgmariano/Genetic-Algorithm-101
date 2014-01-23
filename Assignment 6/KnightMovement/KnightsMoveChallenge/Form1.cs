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
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            Point x, y;
            string move;

            x = new Point(3, 2);

            move = "000";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            move = "001";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            move = "010";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            move = "011";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            move = "100";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            move = "101";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            move = "110";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
            move = "111";
            y = ProblemStrategy.ReturnNextPosition(move, x);
            Console.WriteLine(move + ": (" + y.X + ", " + y.Y + ")");
        }
    }
}
