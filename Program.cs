using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static double alpha = 0.3, e = 0.000001;
        static double x1, x2;
        static int n = 0, nn = 0;
        static double f(double x1, double x2)
        {
            double f = Math.Pow(x1,4)+Math.Pow(x2,4)+Math.Sqrt(2+x1*x1+x2*x2)-2*x1+3*x2;
            return f;
        }
        static double f_der_x1(double x1, double x2)
        {
            double f = 4 *Math.Pow(x1,3)-2+x1/(Math.Sqrt(2+x1*x1+x2*x2));
            return f;
        }
        static double f_der_x2(double x1, double x2)
        {
            double f = 4 * x2 * x2 * x2 + 3 + x2 / (Math.Sqrt(2 + x1 * x1 + x2 * x2));
            return f;
        }
        static double x1_next(double x1, double x2, double alpha)
        {
            return x1 - alpha * f_der_x1(x1, x2);
        }
        static double x2_next(double x1, double x2, double alpha)
        {
            return x2 - alpha * f_der_x2(x1, x2);
        }
        static double fi()
        {
            double a = 0, b = 1, e = 0.0000001, d = 0.00000001;
            double xk1()
            { 
                return (a + b) / 2 - d;
            }
            double xk2() 
            { 
                return (a + b) / 2 + d; 
            }
            double fm (double al) 
            {
                return f(x1_next(x1, x2, al), x2_next(x1, x2, al));
            }
            while (b-a>=e)
            {
                n++;
                if (fm(xk1()) < fm(xk2()))
                    b = xk2();
                else a = xk1();
            }
            return a + b / 2;
        }
        static void Main()
        {
            while (Math.Abs(f(x1_next(x1,x2,alpha),x2_next(x1,x2,alpha))-f(x1,x2))>=e)
            {
                nn++;
                double x1o = x1;
                x1 = x1_next(x1, x2, alpha);
                x2 = x2_next(x1o, x2, alpha);
                if (f(x1_next(x1,x2,alpha),x2_next(x1,x2,alpha))>= f(x1,x2))//странно работает
                    alpha = fi();
            }
            Console.WriteLine("Значения X\nX1 = "+ Convert.ToString(x1)+"\nX2 = "+Convert.ToString(x2)
                + "\nЗначение функции в данной точке: "+Convert.ToString(f(x1,x2))+"\nКол-во итераций - "+Convert.ToString(n)
                + "\nКол-во мини-итераций - "+Convert.ToString(nn));
            Console.ReadLine();
        }
    }
}
