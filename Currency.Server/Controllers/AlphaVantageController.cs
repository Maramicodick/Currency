using Domain;
using Domain.Deserialized;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence;
using System.Net;

namespace Currency.Server.Controllers
{
    public class AlphaVantageController : BaseApiController
    {
        private readonly DataContext _context;

        public AlphaVantageController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BTCToUSD>>> GetAllCurences()
        {
            return await _context.BTCToUSDLiveCurrency.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BTCToUSD>> GetCurrency(Guid id)
        {
            return await _context.BTCToUSDLiveCurrency.FindAsync(id);
        }

        [HttpGet("alpha")]
        public async Task<ActionResult<RootObject>> AlphaVantageLiveCurrency()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=USD&apikey=7YXP3O0J664WGDFM";
            Uri queryUri = new Uri(QUERY_URL);
            RootObject result;

            using (WebClient client = new WebClient())
            {
                result = JsonConvert.DeserializeObject<RootObject>(client.DownloadString(queryUri));
            }

            return result;
        }

        [HttpGet("GetMonthly")]
        public async Task<ActionResult<MonthlyExchangeRate>> AlphaVantageMonthlyCurrency()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=DIGITAL_CURRENCY_MONTHLY&symbol=BTC&market=USD&apikey=HVTDKKVYMAQYY6LO";
            Uri queryUri = new Uri(QUERY_URL);
            MonthlyExchangeRate monthlyExchange;

            using (WebClient client = new WebClient())
            {
                monthlyExchange = JsonConvert.DeserializeObject<MonthlyExchangeRate>(client.DownloadString(queryUri));
            }

            return monthlyExchange;
        }
    }
}
