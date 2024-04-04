using KommunSkatter.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace KommunSkatter.Data
{
    public class SkatteAPI
    {
        public static async Task<List<Kommun>> GetAPIdataAsync()
        {
            List<Kommun> kommuner = new List<Kommun>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://skatteverket.entryscape.net/");
            client.DefaultRequestHeaders.Clear();

            HttpResponseMessage response = await client.GetAsync("rowstore/dataset/c67b320b-ffee-4876-b073-dd9236cd2a99");
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var json = JsonSerializer.Deserialize<Kommun>(data);
                kommuner.Add(json);
            }
            else
            {
                Console.WriteLine("Error");
            }

            return kommuner;
        }
    }
}
