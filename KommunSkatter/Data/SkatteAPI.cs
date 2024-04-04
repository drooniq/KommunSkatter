using KommunSkatter.Models;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace KommunSkatter.Data
{
    public class SkatteAPI
    {
        public static async Task<List<Kommun>> GetAPIdataAsync()
        {
            List<Kommun> kommuner = new List<Kommun>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://skatteverket.entryscape.net");
            client.DefaultRequestHeaders.Clear();

            string nextPageUri = null;

            //rowstore/dataset/c67b320b-ffee-4876-b073-dd9236cd2a99/json?_offset=14700&_limit=100
            string requestUri = string.IsNullOrEmpty(nextPageUri) ? $"{client.BaseAddress}/rowstore/dataset/c67b320b-ffee-4876-b073-dd9236cd2a99" : nextPageUri;

            while (requestUri != null)
            {
                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var json = JsonSerializer.Deserialize<KommunData>(data);
                    kommuner.AddRange(json.results);
                    nextPageUri = json.next;
                    requestUri = nextPageUri;

                    if (kommuner.Count >= 14500)
                    { 
                    //
                    }

                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

            return kommuner;
        }
    }
}
