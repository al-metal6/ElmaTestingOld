using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Helper
    {
        public double Sum(double x, double y)
        {
            return x + y;
        }

        public double Minus(double x, double y)
        {
            return x - y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
                return 0;
            return x / y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Step(double x, double y)
        {
            return Math.Pow(x, y);
        }

        public MethodInfo[] metods()
        {
            var methods = GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            return methods;
        }
    }
}
