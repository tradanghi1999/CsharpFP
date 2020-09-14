using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExchangeConverter
{
    public class ExchangeCurrency
    {
        public string CurrencyName { get; set; }
        public double ExchangeRate { get; set; }
        public double BuyRate { get; set; }
        public double SellRate { get; set; }
    }
}
