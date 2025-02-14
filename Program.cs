using consumir_api.Models;
using System.Text.Json;

namespace consumir_api
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string apiUrl = "https://webapplication1-production.up.railway.app/WeatherForecast";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        // Deserializar la respuesta JSON a un array de objetos
                        var get = JsonSerializer.Deserialize<GetWeather[]>(responseData);

                        foreach (var data in get)
                        {
                            Console.WriteLine($"Fecha: {data.date}, Celsius: {data.temperatureC}, Farenheint: {data.temperatureF}, Zona: {data.summary}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error en la solicitud: {e.Message}");
                }
            }
        }
    }
}
