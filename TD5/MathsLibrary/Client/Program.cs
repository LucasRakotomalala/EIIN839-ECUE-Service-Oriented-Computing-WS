using Client.MathsOperations;
using System;
using System.IO;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient clientSOAP1 = new MathsOperationsClient("SOAPEndPoint1");
            MathsOperationsClient clientSOAP2 = new MathsOperationsClient("SOAPEndPoint2");
            MathsOperationsClient clientSOAP3 = new MathsOperationsClient("SOAPEndPoint3");

            Console.WriteLine("Client SOAP 1");
            Console.WriteLine("1 + 2 = {0}", clientSOAP1.Add(1, 2));
            Console.WriteLine("2 x 2 = {0}", clientSOAP1.Multiply(2, 2));
            Console.WriteLine("5 - 3 = {0}", clientSOAP1.Subtract(5, 3));
            Console.WriteLine("3 / 4 = {0}\n", clientSOAP1.Divide(3, 4));

            Console.WriteLine("Client SOAP 2");
            Console.WriteLine("1 + 4 = {0}", clientSOAP2.Add(1, 4));
            Console.WriteLine("2 x 2 = {0}", clientSOAP2.Multiply(2, 2));
            Console.WriteLine("5 - 10 = {0}", clientSOAP2.Subtract(5, 10));
            Console.WriteLine("3 / 4 = {0}\n", clientSOAP2.Divide(3, 4));

            Console.WriteLine("Client SOAP 3");
            Console.WriteLine("1 + 4 = {0}", clientSOAP3.Add(1, 4));
            Console.WriteLine("2 x 2 = {0}", clientSOAP3.Multiply(2, 2));
            Console.WriteLine("5 - 10 = {0}", clientSOAP3.Subtract(5, 10));
            Console.WriteLine("3 / 4 = {0}\n", clientSOAP3.Divide(3, 4));

            clientSOAP1.Close();
            clientSOAP2.Close();
            clientSOAP3.Close();

            Console.WriteLine("REST Call : Substraction (10 - 9)");
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/RESTEndPoint/Subtract?x=10&y=9");

            //Get the Web Response
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            
            //Setting up the Stream Reader
            StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
            string responseString = readerStream.ReadToEnd();
            readerStream.Close();

            Console.WriteLine(responseString);

            Console.ReadLine();
        }
    }
}
