using App;
using Domain.DbModels;
using Domain.Deserialized;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Currency.Server.Controllers
{
    public class AlphaVantageController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AlphaVantageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GraphCurrency>>> GetAllCurrencies()
        {
            return await _mediator.Send(new CurrencyList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GraphCurrency>> GetCurrency(Guid id)
        {
            return Ok();
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
        /*[HttpGet("Monthly")]
        public async Task<ActionResult<MonthlyExchangeRate>> MonthlyFromDb()
        {
            return await _context
        }*/
    }
}
