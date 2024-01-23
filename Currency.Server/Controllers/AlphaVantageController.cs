using App;
using Domain.DbModels;
using Domain.Deserialized;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace Currency.Server.Controllers
{
    public class AlphaVantageController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GraphCurrency>>> GetAllCurrencies()
        {
            return await Mediator.Send(new CurrencyList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GraphCurrency>> GetCurrency(Guid id)
        {
            return Ok();
        }

        /*[HttpGet("alpha")]
        public async Task<ActionResult<LiveCurrency>> AlphaVantageLiveCurrency()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=USD&apikey=7YXP3O0J664WGDFM";
            Uri queryUri = new Uri(QUERY_URL);
            RootObject result;

            using (WebClient client = new WebClient())
            {
                result = JsonConvert.DeserializeObject<RootObject>(client.DownloadString(queryUri));
            }


            LiveCurrency liveCurrency = new LiveCurrency();
            if (result.RealtimeCurrencyExchangeRate != null)
            {
                liveCurrency.BidPrice = result.RealtimeCurrencyExchangeRate.BidPrice;
                liveCurrency.AskPrice = result.RealtimeCurrencyExchangeRate.AskPrice;
                liveCurrency.ExchangeRate = result.RealtimeCurrencyExchangeRate.ExchangeRateValue;
                liveCurrency.LastRefreshed = result.RealtimeCurrencyExchangeRate.LastRefreshed;
                liveCurrency.ToCurrencyCode = result.RealtimeCurrencyExchangeRate.ToCurrencyCode;
                liveCurrency.FromCurrencyCode = result.RealtimeCurrencyExchangeRate.FromCurrencyCode;
            }


            return liveCurrency;
        }*/

        [HttpGet("Currencies")]
        public async Task<ActionResult<List<Domain.DbModels.Currency>>> GetCurrencies()
        {
            return await Mediator.Send(new CurrenciesList.Query());
        }
        /*[HttpGet("Monthly")]
        public async Task<ActionResult<MonthlyExchangeRate>> MonthlyFromDb()
        {
            return await _context
        }*/
    }
}
