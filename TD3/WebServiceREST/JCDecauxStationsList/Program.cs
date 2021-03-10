using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace JCDecauxStationsList
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static readonly string URL = "https://api.jcdecaux.com/vls/v3/";
        static readonly string DATA = "stations";
        static readonly string API_KEY = "ff987c28b1313700e2c97651cec164bd6cb4ed76";

        static async Task Main(string[] args)
        {
            string contract_name = args[0];
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + DATA + "?contract=" + contract_name + "&apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);

                foreach (Station station in stations)
                {
                    Console.WriteLine(station.ToString());
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
