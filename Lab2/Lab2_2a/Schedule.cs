﻿using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Lab2_2a
{
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
        }

        public void DrawGraph()
        {
            LagrangePolynomial lagrangePolynomial = new LagrangePolynomial();

            GraphPane pane = zedGraph.GraphPane; // Объявление панели для рисования

            pane.CurveList.Clear(); // Очистка панели

            PointPairList listF = new PointPairList(); //Создание списков точек для изображения на графике
            PointPairList listL = new PointPairList();

            for (double x = LagrangePolynomial.XMIN; x <= LagrangePolynomial.XMAX; x += 0.01)
                listF.Add(x, lagrangePolynomial.F(x)); // заполнение списка апроксимируемой функции

            double[] x_v = new double[(int)n + 1]; 
            double[] y_v = new double[(int)n + 1];
            double h = 2 / n;

            for (int i = 0; i <= n; i++) // Равномерное разбиение
            {
                x_v[i] = -1 + (i * h);
                y_v[i] = lagrangePolynomial.F(x_v[i]);
            }
            for (double s = LagrangePolynomial.XMIN; s <= LagrangePolynomial.XMAX; s += 1 / (n * 2))
                listL.Add(s, lagrangePolynomial.L(s, x_v, y_v, (int)n + 1)); // заполнение списка апроксиманты

            LineItem CurveF = pane.AddCurve("f(x)", listF, Color.DarkRed, SymbolType.None); //изображение графиков
            LineItem CurveL = pane.AddCurve("F(x)", listL, Color.Green, SymbolType.None);

            zedGraph.AxisChange();

            zedGraph.Invalidate();
        }

        private double n;

        private void button1_Click(object sender, System.EventArgs e)
        {
            n = 4;
            zedGraph.Invalidate();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            n = 10;
            zedGraph.Invalidate();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            n = 20;
            zedGraph.Invalidate();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            DrawGraph();
        }
    }
}