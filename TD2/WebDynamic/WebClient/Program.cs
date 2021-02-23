using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebClient
{
    class Program
    {
        // Docs: https://docs.microsoft.com/fr-fr/dotnet/api/system.net.http.httpclient?view=net-5.0
        static readonly HttpClient client = new HttpClient();

        static async Task Incr(string url, string value)
        {
            HttpResponseMessage response = await client.GetAsync(url + "webservice/incr?val=" + value);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write a number to increment :\n");
            while (true)
            {
                string input = Console.ReadLine();
                Incr(args[0], input).GetAwaiter().GetResult();
            }
        }
    }
}
