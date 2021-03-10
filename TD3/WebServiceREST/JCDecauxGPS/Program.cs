using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Device.Location;

namespace JCDecauxGPS
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

                GeoCoordinate userPosition = new GeoCoordinate(Convert.ToDouble(args[1]), Convert.ToDouble(args[2]));
                Console.WriteLine("Position à comparer:" + userPosition);

                Station nearestStation = null;
                double distance = 0;

                foreach (Station station in stations)
                {
                    if (nearestStation == null)
                    {
                        nearestStation = station;
                        distance = userPosition.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude));
                    }
                    else if (userPosition.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude)) < distance)
                    {
                        nearestStation = station;
                        distance = userPosition.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude));

                    }
                }

                Console.WriteLine("Station la plus près: " + nearestStation.name + " (" + nearestStation.position.latitude + ", " + nearestStation.position .longitude + ") à " + Convert.ToInt32(distance) + " m.\n");

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
