namespace Domain
{
    public class BTCToUSD
    {
        public Guid Id { get; set; }
        public string ExchangeRate { get; set; }
        public DateTime RefreshedTime { get; set; }
        public string? BidPrice { get; set; }
        public string? AskPrice { get; set; }
    }
}
