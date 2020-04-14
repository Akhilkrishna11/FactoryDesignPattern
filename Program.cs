using System;

namespace Factory_design_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number");
            string input = Console.ReadLine();
            Console.WriteLine("Enter the second number");
            string input1 = Console.ReadLine();
            double a, b;
            bool result = Double.TryParse(input, out a);
            if (!result)
            {
                Console.WriteLine("Please enter the  number");
                input1 = Console.ReadLine();
                return;
            }
            bool result1 = Double.TryParse(input1, out b);
            if (!result1)
            {
                Console.WriteLine("Please Enter the number");
                return;
            }
            Console.WriteLine("Please Enter 1 for Addition 2 for Subtraction");
            CalculateFactory calculateFactory = new CalculateFactory();
            ICalculate obj = calculateFactory.GetCalculations(Console.ReadLine());
            if(obj != null)
            {
                obj.Calculate(a, b);
            }
        }
    }
}
