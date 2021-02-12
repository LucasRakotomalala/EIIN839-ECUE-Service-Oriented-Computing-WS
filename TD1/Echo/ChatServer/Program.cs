using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Echo
{
    class EchoServer
    {
        [Obsolete]
        static void Main(string[] args)
        {

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0);
            };

            TcpListener ServerSocket = new TcpListener(8080);
            ServerSocket.Start();

            Console.WriteLine("Server started.");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                handleClient client = new handleClient();
                client.startClient(clientSocket);
            }


        }
    }

    public class handleClient
    {
        static readonly string HTTP_ROOT = @"E:\SI4\Semestre 8\Service Oriented Computing\eiin839\TD1\www\pub";
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Echo);
            ctThread.Start();
        }



        private void Echo()
        {
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {
                string str = reader.ReadString();
                Console.WriteLine(str);
                string response = "";
                if (str.StartsWith("GET"))
                {
                    string[] input = str.Split(" ");
                    string requestPath = input.FirstOrDefault(input => input.StartsWith('/'));
                    if (requestPath == null)
                    {
                        response = "403 Bad Request";
                        Console.WriteLine("Response :\n" + response);
                        writer.Write(response);
                    }
                    else
                    {
                        requestPath = requestPath.Equals("/") ? HTTP_ROOT + "\\index.html" : HTTP_ROOT + requestPath.Replace("/", "\\");
                        try
                        {
                            response = "HTTP/1.0 200 OK\n\n";
                            response = response + File.ReadAllText(requestPath);
                            Console.WriteLine("Response :\n" + response);
                            writer.Write(response);
                        }
                        catch (FileNotFoundException)
                        {
                            response = "404 Not Found";
                            Console.WriteLine("Response :\n" + response);
                            writer.Write(response);
                        }
                    }
                }
                else
                {
                    response = "403 Bad Request";
                    Console.WriteLine("Response :\n" + response);
                    writer.Write(response);
                }
            }
        }



    }

}