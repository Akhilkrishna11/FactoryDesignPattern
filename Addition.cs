using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_design_pattern
{
    public class Addition : ICalculate
    {
        public void Calculate(double a, double b)
        {
            Console.WriteLine("a + b is {0}", a + b);
        }
    }

    public class Subtraction : ICalculate
    {
        public void Calculate(double a, double b)
        {
            Console.WriteLine("a - b is {0}", a - b);
        }
    }
}
