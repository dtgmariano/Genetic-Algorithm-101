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
        List<Chromossome> championslist; 
        List<double> stddeviation;
        List<double> avg;

        int min, max, res;
        int popsize, numgenerations; 
        double probcrossover, probmutation;
        bool hasranking, haselitism;
        double elitism_percent;
        int selec_op, cross_op, mutant_op, optim_op;
        Random random;

        /*Timer Process Variables*/
        bool startGA_flag = false;
        int nog_count;

        /*Constructor*/
        public Statistics_View(int _min, int _max, int _res, 
            int _popsize, int _numgenerations, double _probcrossover, double _probmutation,
            bool _hasranking, bool _haselitism, double _elitism_percent, 
            int _selec_op, int _cross_op, int _mutant_op, int _optim_op)
        {
            InitializeComponent();
            min = _min;
            max = _max;
            res = _res;
            popsize = _popsize;
            numgenerations = _numgenerations;
            probcrossover = _probcrossover; 
            probmutation = _probmutation;
            hasranking = _hasranking; 
            haselitism = _haselitism;
            elitism_percent = _elitism_percent; 
            selec_op = _selec_op; 
            cross_op = _cross_op; 
            mutant_op = _mutant_op; 
            optim_op = _optim_op;
            random = new Random();
        }

        private void btGo_Click(object sender, EventArgs e)
        { 
            rtbInfo.Clear();

            stddeviation = new List<double>();
            avg = new List<double>();
            championslist = new List<Chromossome>();

            for (int i = 0; i < numRounds.Value; i++)
            {
                myGA = new GA(min, max, res,
                popsize, numgenerations, probcrossover, probmutation,
                hasranking, haselitism, elitism_percent,
                selec_op, cross_op, mutant_op, optim_op, random);

                myGA.beginStep();

                for (int j = 1; j < myGA.numgenerations; j++)
                    myGA.processesGA();

                championslist.Add(myGA.champion);
                stddeviation.Add(Statistics.Value_StandardDeviation(myGA.population));
                avg.Add(Statistics.Value_Average(myGA.population));

                rtbInfo.AppendText(Math.Round(championslist[i].x, 3) + "\t" + Math.Round(championslist[i].fx, 3) + "\n");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "Round";
                xlWorkSheet.Cells[1, 2] = "PS";
                xlWorkSheet.Cells[1, 3] = "NG";
                xlWorkSheet.Cells[1, 4] = "Pc";
                xlWorkSheet.Cells[1, 5] = "Pm";
                xlWorkSheet.Cells[1, 6] = "Xchamp";
                xlWorkSheet.Cells[1, 7] = "f(Xchamp)";
                xlWorkSheet.Cells[1, 8] = "StdDev";
                xlWorkSheet.Cells[1, 9] = "Avg";

                for (int i = 0; i < championslist.Count(); i++)
                {
                    xlWorkSheet.Cells[(i + 2), 1] = (i+1);
                    xlWorkSheet.Cells[(i + 2), 2] = myGA.popsize;
                    xlWorkSheet.Cells[(i + 2), 3] = myGA.numgenerations;
                    xlWorkSheet.Cells[(i + 2), 4] = myGA.probcrossover;
                    xlWorkSheet.Cells[(i + 2), 5] = myGA.probmutation;
                    xlWorkSheet.Cells[(i + 2), 6] = championslist[i].x;
                    xlWorkSheet.Cells[(i + 2), 7] = championslist[i].fx;
                    xlWorkSheet.Cells[(i + 2), 8] = stddeviation[i];
                    xlWorkSheet.Cells[(i + 2), 9] = avg[i];
                }

                xlWorkSheet.Cells[1, 11] = "Best Result from all rounds";
                xlWorkSheet.Cells[2, 11] = "Xbest";
                xlWorkSheet.Cells[2, 12] = "f(Xbest)";

                xlWorkSheet.Cells[3, 11] = (Statistics.getTheBestChromossome(championslist)).x;
                xlWorkSheet.Cells[3, 12] = (Statistics.getTheBestChromossome(championslist)).fx;

                xlWorkBook.SaveAs(tbFileName.Text, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                liberarObjetos(xlWorkSheet);
                liberarObjetos(xlWorkBook);
                liberarObjetos(xlApp);

                MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : " + tbFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
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
