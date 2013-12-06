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
        GA myGA;
        Chromossome champion;

        List<double> champvalue;
        List<double> champfvalue;
        List<double> stddeviation;
        List<double> avg;

        int min, max, res;
        int popsize, _numgenerations; 
        double probcrossover, probmutation;
        bool hasranking, haselitism; 
        int elitism_counter, selec_op, cross_op, mutant_op, optim_op;
        Random random;

        /*Timer Process Variables*/
        bool startGA_flag = false;
        int nog_count;

        

        public Statistics_View()
        {
            InitializeComponent();
        }

        public Statistics_View(int _min, int _max, int _res, 
            int _popsize, int _numgenerations, double _probcrossover, double _probmutation,
            bool _hasranking, bool _haselitism, int _elitism_counter, 
            int _selec_op, int _cross_op, int _mutant_op, int _optim_op)
        {
            InitializeComponent();
            random = new Random();
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
        { 
            
           
            rtbInfo.Clear();


            champvalue = new List<double>();
            champfvalue = new List<double>();
            stddeviation = new List<double>();
            avg = new List<double>();

            for (int i = 0; i < numRounds.Value; i++)
            {
                myGA = new GA(min, max, res,
                popsize, _numgenerations, probcrossover, probmutation,
                hasranking, haselitism, elitism_counter,
                selec_op, cross_op, mutant_op, optim_op, random);

                myGA.beginStep();

                for (int j = 1; j < myGA.numgenerations; j++)
                {
                    myGA.processesGA();
                }

                champion = myGA.getChampion();

                champvalue.Add(champion.value);
                champfvalue.Add(Equation.Fx(champion.value));
                avg.Add(myGA.getAverageValue());

                //stddeviation.Add(Statistics.StandardDeviation(values));

                rtbInfo.AppendText(Math.Round(champvalue[i], 3) + "\t" + Math.Round(champfvalue[i], 3) + "\n");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Excel.Application xlApp;
            //    Excel.Workbook xlWorkBook;
            //    Excel.Worksheet xlWorkSheet;
            //    object misValue = System.Reflection.Missing.Value;

            //    xlApp = new Excel.Application();
            //    xlWorkBook = xlApp.Workbooks.Add(misValue);

            //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //    xlWorkSheet.Cells[1, 1] = "PS";
            //    xlWorkSheet.Cells[1, 2] = "NG";
            //    xlWorkSheet.Cells[1, 3] = "Pc";
            //    xlWorkSheet.Cells[1, 4] = "Pm";
            //    xlWorkSheet.Cells[1, 5] = "Xbest";
            //    xlWorkSheet.Cells[1, 6] = "f(Xbest)";
            //    xlWorkSheet.Cells[1, 7] = "StdDev";
            //    xlWorkSheet.Cells[1, 8] = "Avg";

            //    for (int i = 0; i < champvalue.Count(); i++)
            //    {
            //        xlWorkSheet.Cells[(i + 2), 1] = myGA.populationSize;
            //        xlWorkSheet.Cells[(i + 2), 2] = myGA.numberGenerations;
            //        xlWorkSheet.Cells[(i + 2), 3] = myGA.probabilityCrossover;
            //        xlWorkSheet.Cells[(i + 2), 4] = myGA.probabilityMutation;

            //        xlWorkSheet.Cells[(i + 2), 5] = champvalue[i];
            //        xlWorkSheet.Cells[(i + 2), 6] = champfvalue[i];
            //        xlWorkSheet.Cells[(i + 2), 7] = stddeviation[i];
            //        xlWorkSheet.Cells[(i + 2), 8] = avg[i];
            //    }

            //    xlWorkSheet.Cells[1, 10] = "Best Result";
            //    xlWorkSheet.Cells[1, 11] = "";
            //    xlWorkSheet.Cells[2, 10] = "X";
            //    xlWorkSheet.Cells[2, 11] = "f(Xbest)";
            //    xlWorkSheet.Cells[3, 10] = GetTheBestChromossome(champvalue);
            //    xlWorkSheet.Cells[3, 11] = Equation.set(myGA.functionType, GetTheBestChromossome(champvalue));

            //    xlWorkBook.SaveAs(tbFileName.Text, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //    xlWorkBook.Close(true, misValue, misValue);
            //    xlApp.Quit();

            //    liberarObjetos(xlWorkSheet);
            //    liberarObjetos(xlWorkBook);
            //    liberarObjetos(xlApp);

            //    MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : " + tbFileName.Text);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Erro : " + ex.Message);
            //}
        }

        private void liberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Ocorreu um erro durante a liberação do objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
