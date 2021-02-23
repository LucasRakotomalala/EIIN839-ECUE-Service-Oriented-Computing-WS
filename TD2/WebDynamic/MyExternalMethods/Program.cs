using System;

namespace MyExternalMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
                Console.WriteLine("<html><body>Hello " + args[0] + " et " + args[1] + "!</body></html>");
            else
                Console.WriteLine("<html><body>Exactly 2 params required!</body></html>");
        }
    }
}
