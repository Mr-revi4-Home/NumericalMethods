using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Lab2_3c
{
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
        }        

        public void DrawGraph()
        {
            NewtonPolynomial newtonPolynomial = new NewtonPolynomial();

            GraphPane pane = zedGraph.GraphPane;

            pane.CurveList.Clear();

            PointPairList listF = new PointPairList();
            PointPairList listL = new PointPairList();            

            for (double x = NewtonPolynomial.xmin; x <= NewtonPolynomial.xmax; x += 0.01)
                listF.Add(x, newtonPolynomial.f(x));

            double h = 2 / n;

            int size = (int)n + 1;
            double[] x_v = new double[size];
            double[] y_v = new double[size];

            for (int i = 0; i <= n; i++)
            {
                x_v[i] = -1 + i * h;
                y_v[i] = newtonPolynomial.f(x_v[i]);
            }
            for (double s = NewtonPolynomial.xmin; s <= NewtonPolynomial.xmax; s += 1 / (n * 2))
                listL.Add(s, newtonPolynomial.P(s, x_v, y_v, size));

            LineItem CurveF = pane.AddCurve("f(x)", listF, Color.Red, SymbolType.None);
            LineItem CurveL = pane.AddCurve("F(x)", listL, Color.Blue, SymbolType.None);

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