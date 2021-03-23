using System;

namespace Server
{
    public class MathsOperations : IMathsOperations
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                return x / y;
            }
        }
    }
}
