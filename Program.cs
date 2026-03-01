using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();

        string json = await client.GetStringAsync("https://api.adviceslip.com/advice");

        using JsonDocument doc = JsonDocument.Parse(json);

        string advice = doc.RootElement
                           .GetProperty("slip")
                           .GetProperty("advice")
                           .GetString();

        Console.WriteLine("Conselho do dia:");
        Console.WriteLine(advice);
    }
}