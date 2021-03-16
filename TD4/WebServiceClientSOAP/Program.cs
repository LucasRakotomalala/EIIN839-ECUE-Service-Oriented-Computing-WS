using System;

namespace WebServiceClientSOAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator.Calculator calculator = new Calculator.Calculator();
            Console.WriteLine(calculator.Add(10, 12));
        }
    }
}
