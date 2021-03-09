using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace JCDecauxContractsList
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static readonly string URL = "https://api.jcdecaux.com/vls/v1/";
        static readonly string DATA = "contracts";
        static readonly string API_KEY = "ff987c28b1313700e2c97651cec164bd6cb4ed76";

        static async Task Main()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + DATA + "?apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Contract> contrats = JsonSerializer.Deserialize<List<Contract>>(responseBody);

                foreach (Contract contrat in contrats)
                {
                    Console.WriteLine(contrat.ToString());
                }

                //Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
