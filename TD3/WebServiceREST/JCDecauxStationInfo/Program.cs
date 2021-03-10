using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace JCDecauxStationInfo
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
            string contract_id = args[1];
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + DATA + "/" + contract_id + "?contract=" + contract_name + "&apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                DetailedStation station = JsonSerializer.Deserialize<DetailedStation>(responseBody);
                Console.WriteLine(station.ToString());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
