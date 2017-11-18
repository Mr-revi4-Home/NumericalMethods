namespace Lab2_2b
{
    class LagrangePolynomial
    {
        public double L(double x, double[] x_values, double[] y_values, int size) //многочлен Лагранжа
        {
            double lagrange_pol = 0;
            double basics_pol;

            for (int i = 0; i < size; i++)
            {
                basics_pol = 1;
                for (int j = 0; j < size; j++)
                {
                    if (j == i) continue;
                    basics_pol *= (x - x_values[j]) / (x_values[i] - x_values[j]);
                }
                lagrange_pol += basics_pol * y_values[i];
            }
            return lagrange_pol;
        }

        public double f(double x) //Исходная функция f(x)
        {
            double d = 21.0;
            return 1 / (1 + d * x * x);
        }

        public const double xmin = -1;
        public const double xmax = 1;
    }
}
