using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using BiolabLibraries;

namespace GA
{
    public partial class Statistics_View : Form
    {
        Random random = new Random();
        GA myGA;

        List<double> column1;
        List<double> column2;
        List<double> stddeviation;
        List<double> avg;

        int ps; int ng; int pc; int pm; int rmin; int rmax; int gran; int selec_op; int cross_op; int optim_op;
        /*Timer Process Variables*/
        bool startGA_flag = false;
        int nog_count;

        double champ;

        public Statistics_View()
        {
            InitializeComponent();
        }

        ///*Overrided Constructor*/
        //public Statistics_View(int _ps, int _ng, int _pc, int _pm,
        //    int _rmin, int _rmax, int _gran,
        //    int _selec_op, int _cross_op, int _optim_op)
        //{
        //    InitializeComponent();
        //    ps = _ps;
        //    ng = _ng;
        //    pc = _pc;
        //    pm = _pm;
        //    rmin = _rmin;
        //    rmax = _rmax;
        //    gran = _gran;
        //    selec_op = _selec_op;
        //    cross_op = _cross_op;
        //    optim_op = _optim_op;
        //}

        private void btGo_Click(object sender, EventArgs e)
        { }

        private void btSave_Click(object sender, EventArgs e)
        { }
        //private void btGo_Click(object sender, EventArgs e)
        //{
        //    rtbInfo.Clear();


        //    column1 = new List<double>();
        //    column2 = new List<double>();
        //    stddeviation = new List<double>();
        //    avg = new List<double>();

        //    for (int i = 0; i < numRounds.Value; i++)
        //    {
        //        myGA = new GeneticAlgorithm(rmin, rmax, gran, ps, ng, pc, pm, selec_op, cross_op, 2, optim_op, random);

        //        myGA.StartsPopulation();
        //        myGA.SelectParents();
        //        myGA.Reproduction();

        //        for (int j = 1; j < myGA.numberGenerations; j++)
        //        {
        //            myGA.SelectParents();
        //            myGA.Reproduction();
        //        }

        //        champ = GetTheBestChromossome(myGA.chromoValue);
        //        column1.Add(champ);
        //        column2.Add(Equation.set(myGA.functionType, champ));
        //        double[] values = new double[50];
        //        values = myGA.chromoValue.ToArray();
        //        avg.Add(Statistics.Mean(values));
        //        stddeviation.Add(Statistics.StandardDeviation(values));
        //        rtbInfo.AppendText(Math.Round(column1[i], 3) + "\t" + Math.Round(column2[i], 3) + "\n");
        //    }
        //}

        //private void btSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Excel.Application xlApp;
        //        Excel.Workbook xlWorkBook;
        //        Excel.Worksheet xlWorkSheet;
        //        object misValue = System.Reflection.Missing.Value;

        //        xlApp = new Excel.Application();
        //        xlWorkBook = xlApp.Workbooks.Add(misValue);

        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //        xlWorkSheet.Cells[1, 1] = "PS";
        //        xlWorkSheet.Cells[1, 2] = "NG";
        //        xlWorkSheet.Cells[1, 3] = "Pc";
        //        xlWorkSheet.Cells[1, 4] = "Pm";
        //        xlWorkSheet.Cells[1, 5] = "Xbest";
        //        xlWorkSheet.Cells[1, 6] = "f(Xbest)";
        //        xlWorkSheet.Cells[1, 7] = "StdDev";
        //        xlWorkSheet.Cells[1, 8] = "Avg";

        //        for (int i = 0; i < column1.Count(); i++)
        //        {
        //            xlWorkSheet.Cells[(i + 2), 1] = myGA.populationSize;
        //            xlWorkSheet.Cells[(i + 2), 2] = myGA.numberGenerations;
        //            xlWorkSheet.Cells[(i + 2), 3] = myGA.probabilityCrossover;
        //            xlWorkSheet.Cells[(i + 2), 4] = myGA.probabilityMutation;

        //            xlWorkSheet.Cells[(i + 2), 5] = column1[i];
        //            xlWorkSheet.Cells[(i + 2), 6] = column2[i];
        //            xlWorkSheet.Cells[(i + 2), 7] = stddeviation[i];
        //            xlWorkSheet.Cells[(i + 2), 8] = avg[i];
        //        }

        //        xlWorkSheet.Cells[1, 10] = "Best Result";
        //        xlWorkSheet.Cells[1, 11] = "";
        //        xlWorkSheet.Cells[2, 10] = "X";
        //        xlWorkSheet.Cells[2, 11] = "f(Xbest)";
        //        xlWorkSheet.Cells[3, 10] = GetTheBestChromossome(column1);
        //        xlWorkSheet.Cells[3, 11] = Equation.set(myGA.functionType, GetTheBestChromossome(column1));

        //        xlWorkBook.SaveAs(tbFileName.Text, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //        xlWorkBook.Close(true, misValue, misValue);
        //        xlApp.Quit();

        //        liberarObjetos(xlWorkSheet);
        //        liberarObjetos(xlWorkBook);
        //        liberarObjetos(xlApp);

        //        MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : " + tbFileName.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro : " + ex.Message);
        //    }
        //}

        //private void GAProcess()
        //{


        //}

        //private double GetTheBestChromossome(List<double> population_values)
        //{
        //    List<double> elite_values = population_values;
        //    List<double> elite_fitness = new List<double>();
        //    elite_fitness.Clear();

        //    for (int i = 0; i < elite_values.Count(); i++)
        //    {
        //        elite_fitness.Add(Fitness.set(myGA.functionType, myGA.optimizationType, elite_values[i]));
        //    }


        //    Array aelite_values = elite_values.ToArray();
        //    Array aelite_fitness = elite_fitness.ToArray();
        //    Array.Sort(aelite_fitness, aelite_values);

        //    elite_values = aelite_values.OfType<double>().ToList();
        //    elite_fitness = aelite_fitness.OfType<double>().ToList();

        //    elite_values.Reverse();

        //    return elite_values[0];
        //}

        //private void save()
        //{

        //}

        //private void liberarObjetos(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //        MessageBox.Show("Ocorreu um erro durante a liberação do objeto " + ex.ToString());
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}

    }
}
