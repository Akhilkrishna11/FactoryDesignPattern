using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_design_pattern
{
    class CalculateFactory
    {
        public ICalculate GetCalculations(string type)
        {
            ICalculate obj = null;

            if (type.Equals("1"))
            {
                obj = new Addition();
            }
            if (type.Equals("2"))
            {
                obj = new Subtraction();
            }
            else
            {
                Console.WriteLine("Cant perform that action");
            }
            return obj;
        }
    }
}
