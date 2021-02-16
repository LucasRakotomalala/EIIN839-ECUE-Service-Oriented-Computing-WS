using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace MyWebServerUrlParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }


            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };


            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                
                // get url 
                Console.WriteLine($"Received request for {request.Url}\n");
                /*
                //get url protocol
                Console.WriteLine(request.Url.Scheme);
                //get user in url
                Console.WriteLine(request.Url.UserInfo);
                //get host in url
                Console.WriteLine(request.Url.Host);
                //get port in url
                Console.WriteLine(request.Url.Port);
                //get path in url 
                Console.WriteLine(request.Url.LocalPath);

                // parse path in url 
                foreach (string str in request.Url.Segments)
                {
                    Console.WriteLine(str);
                }
                */
                string[] segments = request.Url.Segments;
                string last_segment = segments[segments.Length - 1];

                // On construit les paramètres
                Object[] params_request = new Object[2];
                params_request[0] = HttpUtility.ParseQueryString(request.Url.Query).Get("param1");
                params_request[1] = HttpUtility.ParseQueryString(request.Url.Query).Get("param2");

                // On récupère la classe et la méthode
                Type type = typeof(MyMethods);
                MethodInfo method = type.GetMethod(last_segment);

                // Initialisation du résultat à afficher
                string result = "";

                // Si la méthode existe on l'appelle
                // Évite de faire buguer le programme lorsque la requête pour la `favicon` est lancée automatiquement par le navigateur
                if (method != null)
                {
                    Console.WriteLine("Success: Internal Method Detected");
                    MyMethods myMethods = new MyMethods();
                    result = (string) method.Invoke(myMethods, params_request);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Error: No Internal Method Detected");
                }

                if (last_segment.Equals("MyExternalMethod"))
                {
                    Console.WriteLine("Success: External Method Detected");
                    ProcessStartInfo start = new ProcessStartInfo();
                    start.FileName = @"E:\SI4\Semestre 8\Service Oriented Computing\eiin839\TD2\WebDynamic\MyExternalMethods\bin\Debug\netcoreapp3.1\MyExternalMethods.exe"; // Specify exe name.
                    start.Arguments = params_request[0] + " " + params_request[1]; // Specify arguments.
                    start.UseShellExecute = false;
                    start.RedirectStandardOutput = true;
                    //
                    // Start the process.
                    //
                    using (Process process = Process.Start(start))
                    {
                        //
                        // Read in all the text from the process with the StreamReader.
                        //
                        using (StreamReader reader = process.StandardOutput)
                        {
                            result = reader.ReadToEnd();
                            Console.WriteLine(result);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: No External Methods Detected");
                }

                //get params un url. After ? and between &

                Console.WriteLine(request.Url.Query);

                //parse params in url
                Console.WriteLine("param1 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param1"));
                Console.WriteLine("param2 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param2"));
                //Console.WriteLine("param3 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param3"));
                //Console.WriteLine("param4 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param4"));

                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString = result == "" ? "<html><body>Hello World!</body></html>" : result;
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }
    }
}