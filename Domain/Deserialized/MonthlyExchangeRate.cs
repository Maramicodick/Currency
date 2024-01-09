using Newtonsoft.Json;

namespace Domain.Deserialized
{
    public class CryptoData
    {
        [JsonProperty("1a. open (USD)")]
        public string Open { get; set; }

        [JsonProperty("2a. high (USD)")]
        public string High { get; set; }

        [JsonProperty("3a. low (USD)")]
        public string Low { get; set; }

        [JsonProperty("4a. close (USD)")]
        public string Close { get; set; }

        [JsonProperty("5. volume")]
        public string Volume { get; set; }

        [JsonProperty("6. market cap (USD)")]
        public string MarketCap { get; set; }
    }

    public class MonthlyExchangeRate
    {
        [JsonProperty("Time Series (Digital Currency Monthly)")]
        public Dictionary<string, CryptoData> TimeSeries { get; set; }
    }
}
