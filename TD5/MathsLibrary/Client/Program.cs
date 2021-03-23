using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperations.IMathsOperations mathsOperations = new MathsOperations.MathsOperationsClient();
            Console.WriteLine("1 + 2 = {0}", mathsOperations.Add(1, 2));
            Console.WriteLine("2 x 2 = {0}", mathsOperations.Multiply(2, 2));
            Console.WriteLine("5 - 3 = {0}", mathsOperations.Subtract(5, 3));
            Console.WriteLine("3 / 4 = {0}", mathsOperations.Divide(3, 4));
            
            Console.ReadLine();
        }
    }
}
