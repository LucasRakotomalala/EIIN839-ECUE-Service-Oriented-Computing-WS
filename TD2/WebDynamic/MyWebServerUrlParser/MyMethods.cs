using System.Diagnostics;
using System.IO;

namespace MyWebServerUrlParser
{
    class MyMethods
    {
        public string MyMethod(string param1_value, string param2_value)
        {
            if (param1_value != null && param2_value != null)
                return "<html><body> Hello " + param1_value + " et " + param2_value + "!</body></html>";
            else
                return "<html><body>Exactly 2 params required!</body></html>";
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

        public string incr(string value)
        {
            // TODO: Surrond parse with try/catch block
            int val = int.Parse(value) + 1;
            return $"{{\n\t\"val\": {val},\n\t\"method\": \"incr\",\n\t\"OK\": \"true\"\n}}";
        }
    }
}
