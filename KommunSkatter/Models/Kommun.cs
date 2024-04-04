using System.Text.Json.Serialization;

namespace KommunSkatter.Models
{
    public class Kommun
    {
        public string next { get; set; }
        public int resultCount { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int queryTime { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string kyrkoavgift { get; set; }

        [JsonPropertyName("summa, inkl. kyrkoavgift")]
        public string summainklkyrkoavgift { get; set; }

        public string församling { get; set; }

        [JsonPropertyName("kommunal-skatt")]
        public string kommunalskatt { get; set; }

        [JsonPropertyName("församlings-kod")]
        public string församlingskod { get; set; }

        public string kommun { get; set; }

        [JsonPropertyName("begravnings-avgift")]
        public string begravningsavgift { get; set; }

        [JsonPropertyName("landstings-skatt")]
        public string landstingsskatt { get; set; }

        [JsonPropertyName("summa, exkl. kyrkoavgift")]
        public string summaexklkyrkoavgift { get; set; }

        public string år { get; set; }
    }

}

