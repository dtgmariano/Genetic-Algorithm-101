/*
 * ----------------------------------------------------------------------------------
 * UNIVERSIDADE FEDERAL DE UBERLÂNDIA    
 * FACULDADE DE ENGENHARIA ELÉTRICA      
 * LABORATÓRIO DE ENGENHARIA BIOMÉDICA   
 * 
 * CLASSE CONTENDO MÉTODOS ESTATÍSTICOS
 * Desenvolvido por: Andrei Nakagawa Silva
 * Contato: andrei.ufu@gmail.com
 * -------------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolabLibraries
{
    public static class Statistics
    {
        public static int Rounding { get; set; }

        //Calcula a média de uma lista de amostras
        //Retorna o valor da média
        public static double Mean(List<double> sampleList)
        {
            double sum = 0;

            for (int i = 0; i < sampleList.Count; i++)
                sum += sampleList[i];

            return Math.Round(sum / sampleList.Count, Rounding);
        }

        //Calcula a média de um vetor de amostras
        //Retorna o valor da média
        public static double Mean(double[] sampleVector)
        {
            double sum = 0;

            for (int i = 0; i < sampleVector.Length; i++)
                sum += sampleVector[i];

            return Math.Round(sum / sampleVector.Length, Rounding);
        }

        //Calcula a média de várias amostras, presentes em uma matriz
        //Cada coluna da matriz deve se referir à um conjunto de amostras diferentes
        //Retorna uma matriz de uma linha e N colunas, sendo que cada coluna se refere à média
        //das amostras de cada coluna da matriz de argumento
        public static double[,] Mean(double[,] sampleMatrix)
        {
            double[,] resp = new double[1, sampleMatrix.GetLength(1)];
            double sum = 0;
            for (int j = 0; j < sampleMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < sampleMatrix.GetLength(0); i++)
                {
                    sum += sampleMatrix[i, j];
                }

                resp[0, j] = Math.Round(sum / sampleMatrix.GetLength(0), Rounding);
                sum = 0;
            }
            return resp;
        }

        //Calcula a variância de um vetor de amostras
        //Retorna o valor da variância
        public static double Variance(double[] sampleVector)
        {
            double sum = 0;

            double mean = Mean(sampleVector);

            for (int i = 0; i < sampleVector.Length; i++)
                sum += Math.Pow((sampleVector[i] - mean), 2);

            return Math.Round((sum / (sampleVector.Length - 1)), Rounding);
        }

        //Calcula a variância de várias amostras, presentes em uma matriz
        //Cada coluna da matriz deve se referir à um conjunto de amostras diferentes
        //Retorna uma matriz de uma linha e N colunas, sendo que cada coluna se refere à variância
        //das amostras de cada coluna da matriz de argumento
        public static double[,] Variance(double[,] sampleMatrix)
        {
            double[,] resp = new double[1, sampleMatrix.GetLength(1)];
            double[] sampleGroup = new double[sampleMatrix.GetLength(0)];

            for (int j = 0; j < sampleMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < sampleMatrix.GetLength(0); i++)
                {
                    sampleGroup[i] = sampleMatrix[i, j];
                }

                resp[0, j] = Variance(sampleGroup);
            }
            return resp;
        }

        //Calcula o desvio padrão de um vetor de amostras
        //Retorna o valor do desvio padrão
        public static double StandardDeviation(double[] sampleVector)
        {
            return Math.Round(Math.Sqrt(Variance(sampleVector)), Rounding);
        }

        //Calcula o desvio padrão de várias amostras, presentes em uma matriz
        //Cada coluna da matriz deve se referir à um conjunto de amostras diferentes
        //Retorna uma matriz de uma linha e N colunas, sendo que cada coluna se refere ao desvio padrão
        //das amostras de cada coluna da matriz de argumento
        public static double[,] StandardDeviation(double[,] sampleMatrix)
        {
            double[,] resp = new double[1, sampleMatrix.GetLength(1)];
            double[] sampleGroup = new double[sampleMatrix.GetLength(0)];

            for (int j = 0; j < sampleMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < sampleMatrix.GetLength(0); i++)
                {
                    sampleGroup[i] = sampleMatrix[i, j];
                }

                resp[0, j] = StandardDeviation(sampleGroup);
            }
            return resp;
        }

        //Aplica a normalização Zscore em um vetor de amostras
        //Retorna um novo vetor contendo as amostras normalizadas
        //z = (x - media)/desviopadrao
        public static double[] Zscore(double[] sampleVector)
        {
            double[] resp = new double[sampleVector.Length];
            double mean = Mean(sampleVector);
            double std = StandardDeviation(sampleVector);
            for (int i = 0; i < sampleVector.Length; i++)
            {
                resp[i] = Math.Round((sampleVector[i] - mean) / std, Rounding);
            }
            return resp;
        }

        //Aplica a normalização Zscore em uma matriz de amostras
        //Cada coluna da matriz deve se referir à um conjunto de amostras diferentes
        //Retorna uma nova matriz contendo todas as amostras normalizadas
        public static double[,] Zscore(double[,] sampleMatrix)
        {
            double[] sampleGroup = new double[sampleMatrix.GetLength(0)];
            double[,] meanArray = Mean(sampleMatrix);
            double[,] stdArray = StandardDeviation(sampleMatrix);
            double[,] resp = new double[sampleMatrix.GetLength(0), sampleMatrix.GetLength(1)];

            for (int j = 0; j < sampleMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < sampleMatrix.GetLength(0); i++)
                {
                    resp[i, j] = Math.Round((sampleMatrix[i, j] - meanArray[0, j]) / stdArray[0, j], Rounding);
                }
            }

            return resp;
        }

        //FUNÇÃO PARA O CÁLCULO DOS COEFICIENTES DA REGRESSÃO LINEAR
        public static void LinearRegression(int numbPoints, double[] pntX, double[] pntY, ref double coefa, ref double coefb)
        {
            //Equação da reta: y = ax + b

            //Coeficientes
            double a = 0;
            double b = 0;

            //Equação 1
            //Soma Y = a*Soma(X) + n*b
            double somaY = 0;
            double somaX = 0;
            double n = numbPoints;

            //Equação 2
            //Soma XY = b*Soma(X) + a*Soma(X^2)
            double somaXY = 0;
            double somaXQuadrado = 0;

            //Solução do sistema            
            //-----------------------------------------------------------------------------------
            double fator = 0;
            double somaYlinha = 0;
            double somaXlinha = 0;
            double subY = 0;
            double subX = 0;

            //EQUAÇÃO 1
            for (int i = 0; i < numbPoints; i++)
            {
                somaY += pntY[i];
                somaX += pntX[i];
            }

            //EQUAÇÃO 2
            for (int i = 0; i < numbPoints; i++)
            {
                somaXY += pntX[i] * pntY[i];
                somaXQuadrado += Math.Pow(pntX[i], 2);
            }

            //Encontrando o valor de a
            fator = somaX / n;
            somaYlinha = somaY * fator;
            somaXlinha = somaX * fator;
            subY = somaXY - somaYlinha;
            subX = somaXQuadrado - somaXlinha;

            //Encontrando o valor de a
            a = subY / subX;

            //Encontrando o valor de b
            b = (somaY - (somaX * a)) / n;

            a = Math.Round(a, 3);
            b = Math.Round(b, 3);

            coefa = a;
            coefb = b;
        }

        //FUNÇÃO PARA O CÁLCULO DO COEFICIENTE DE CORRELAÇÃO DE PEARSON
        public static double CorrelationCoefficient(double[] pntX, double[] pntY)
        {
            //Segue a fórmula: r = (Somatória(X-mediaY)*(Y - mediaY)) / Raiz((Somatoria(X-mediaY)^2)*Somatoria(Y-mediaY)^2))
            double coefR = 0;
            double mediaX = Mean(pntX);
            double mediaY = Mean(pntY);
            double numerador = 0;
            double denominador1 = 0;
            double denominador2 = 0;

            for (int i = 0; i < pntX.Length; i++)
            {
                numerador += ((pntX[i] - mediaX) * (pntY[i] - mediaY));
                denominador1 += Math.Pow((pntX[i] - mediaX), 2);
                denominador2 += Math.Pow((pntY[i] - mediaY), 2);
            }

            coefR = numerador / Math.Sqrt(denominador1 * denominador2);

            return coefR;
        }

        //FUNÇÃO PARA O CÁLCULO DO COEFICIENTE DE DETERMINAÇÃO R²
        public static double CoeficienteDeterminacao(double[] pntX, double[] pntY)
        {
            double a = 0, b = 0, sqres = 0, sqtot = 0, resultado = 0;
            double[] yPrev = new double[pntY.Length];

            double mediaY = Mean(pntY);

            LinearRegression(pntX.Length, pntX, pntY, ref a, ref b);

            for (int i = 0; i < pntY.Length; i++)
                yPrev[i] = a * pntX[i] + b;

            for (int i = 0; i < pntY.Length; i++)
                sqres += Math.Pow((yPrev[i] - pntY[i]), 2);


            for (int i = 0; i < pntY.Length; i++)
                sqtot += Math.Pow((pntY[i] - mediaY), 2);

            resultado = 1 - (sqres / sqtot);

            return resultado;
        }

        //FUNÇÃO PARA O CÁLCULO DA DISTÂNCIA EUCLIDIANA 
        public static double DistanciaEuclidiana(double[] p, double[] q)
        {
            double d = 0;
            for (int i = 0; i < p.Length; i++)
            {
                d += Math.Pow((p[i] - q[i]), 2);
            }
            return Math.Round(Math.Sqrt(d), 2);
        }

        public static double Distancia(double[] p, double[] q)
        {
            double d = 0;
            for (int i = 0; i < p.Length; i++)
            {
                d += Math.Pow((p[i] - q[i]), 2);
            }
            return Math.Round(d, 2);
        }
    }
}