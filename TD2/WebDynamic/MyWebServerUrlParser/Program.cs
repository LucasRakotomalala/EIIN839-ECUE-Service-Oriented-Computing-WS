using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Collections.Generic;

namespace MyWebServer
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

                // On récupère des paramètres s'ils existent
                List<object> params_request = new List<object>();
                if (HttpUtility.ParseQueryString(request.Url.Query).Get("param1") != null)
                    params_request.Add(HttpUtility.ParseQueryString(request.Url.Query).Get("param1"));
                if (HttpUtility.ParseQueryString(request.Url.Query).Get("param2") != null)
                    params_request.Add(HttpUtility.ParseQueryString(request.Url.Query).Get("param2"));
                if (HttpUtility.ParseQueryString(request.Url.Query).Get("val") != null)
                    params_request.Add(HttpUtility.ParseQueryString(request.Url.Query).Get("val"));

                object[] params_tab = params_request.ToArray();

                // On récupère la classe et la méthode
                Type type = typeof(MyMethods);
                MethodInfo method = type.GetMethod(last_segment);

                // Initialisation du résultat à afficher
                string result = "";

                // Si la méthode existe on l'appelle avec les arguments nécessaires
                // Évite de faire buguer le programme lorsque la requête pour la `favicon` est lancée automatiquement par le navigateur
                if (method != null)
                {
                    MyMethods myMethods = new MyMethods();
                    result = (string) method.Invoke(myMethods, params_tab);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Error: no method found");
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