using System;
using System.Diagnostics;
using System.IO;

namespace MyWebServerUrlParser
{
    class MyMethods
    {
        public string MyMethod(string param1_value, string param2_value)
        {
            return "<html><body> Hello " + param1_value + " et " + param2_value + "!</body></html>";
        }

        public string MyExternalMethod(string param1_value, string param2_value)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"E:\SI4\Semestre 8\Service Oriented Computing\eiin839\TD2\WebDynamic\MyExternalMethods\bin\Debug\netcoreapp3.1\MyExternalMethods.exe"; // Specify exe name.
            start.Arguments = param1_value + " " + param2_value;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
