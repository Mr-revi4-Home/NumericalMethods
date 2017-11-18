using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_3b
{
    class NewtonPolynomial
    {
        public double P(double x, double[] x_values, double[] y_values, int size)
        {
            double res = y_values[0], F, den;
            int i, j, k;
            for (i = 1; i <= size - 1; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    den = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j)
                            den *= (x_values[j] - x_values[k]);
                    }
                    F += y_values[j] / den;
                }
                for (k = 0; k < i; k++) F *= (x - x_values[k]);
                res += F;
            }
            return res;
        }

        public double f(double x)
        {
            return Math.Pow(x, 3);
        }

        public const double xmin = -1;
        public const double xmax = 1;

    }
}
