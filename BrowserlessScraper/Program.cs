using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.Write("Enter your Browserless API key: ");
        string apiKey = Console.ReadLine();

        var targetUrl = "https://asgerdl.github.io/SessionSaverSite/";
        var client = new HttpClient();
        var requestUri = $"https://production-sfo.browserless.io/content?token={apiKey}";

        var jsonPayload = $"{{\"url\": \"{targetUrl}\"}}";
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(requestUri, content);
            var html = await response.Content.ReadAsStringAsync();

            Console.WriteLine("\n--- Rendered HTML ---\n");
            Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}