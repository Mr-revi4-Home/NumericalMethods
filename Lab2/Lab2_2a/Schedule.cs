using System.Drawing;
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

        public void DrawGraph() //функция прорисовки графика
        {
            LagrangePolynomial lagrangePolynomial = new LagrangePolynomial();

            GraphPane pane = zedGraph.GraphPane; //создание холста

            pane.CurveList.Clear();   //очистка холста

            PointPairList listF = new PointPairList(); //объявление массивов точек для рисования 
            PointPairList listL = new PointPairList();            

            for (double x = LagrangePolynomial.xmin; x <= LagrangePolynomial.xmax; x += 0.01) //добавление в первый массив точек исходной функции f(x)
                listF.Add(x, lagrangePolynomial.f(x));            
            
            double[] x_v = new double[(int)n + 1]; // два массива вспомогательных для точек апроксимируемой функции
            double[] y_v = new double[(int)n + 1];
            double h = 2 / n;

            for (int i = 0; i <= n; i++) // заполнение массивов точками апроксимируемой функции
            {
                x_v[i] = -1 + (i * h);
                y_v[i] = lagrangePolynomial.f(x_v[i]);
            }
            for (double s = LagrangePolynomial.xmin; s <= LagrangePolynomial.xmax; s += 1 / (n * 2))
                listL.Add(s, lagrangePolynomial.L(s, x_v, y_v, (int)n + 1)); // заполнение массива точками для рисования 

            LineItem CurveF = pane.AddCurve("f(x)", listF, Color.DarkRed, SymbolType.None); // рисование графиков
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