using KommunSkatter.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace KommunSkatter.Data
{
    public class SkatteAPI
    {
        private static List<Kommun> _Kommuner = null;

        public static async Task<List<Kommun>> GetAPIdataAsync()
        {
            if (_Kommuner == null)
            {
                 _Kommuner = new List<Kommun>();
            } 
            else
            {
                if (_Kommuner.Count == 0)
                {

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://skatteverket.entryscape.net/");
                    client.DefaultRequestHeaders.Clear();
                    HttpResponseMessage response = await client.GetAsync("rowstore/dataset/c67b320b-ffee-4876-b073-dd9236cd2a99");

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        var json = JsonSerializer.Deserialize<Kommun>(data);
                        _Kommuner.Add(json);
                        Console.WriteLine("Data hämtad");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                else
                {
                    Console.WriteLine("Data redan hämtad");
                }
            }
        
            return _Kommuner;
        }
    }
}
