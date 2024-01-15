using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class GraphCurrency
    {
        public int Id { get; set; }
        public string ExchangeRate { get; set; }

        public DateTime Date { get; set; }

    }
}
