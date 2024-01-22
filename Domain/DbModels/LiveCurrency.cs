using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class LiveCurrency
    {
        public string FromCurrencyCode { get; set; }

        public string ToCurrencyCode { get; set; }

        public string ExchangeRate { get; set; }

        public DateTime LastRefreshed { get; set; }

        public string BidPrice { get; set; }

        public string AskPrice { get; set; }
    }
}
