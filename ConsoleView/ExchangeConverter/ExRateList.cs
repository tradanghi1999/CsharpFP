using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ExchangeConverter
{
    public class ExRateList
    {
        public ExRateList(DateTime dateTime, string rootcur, IEnumerable<ExchangeCurrency> exCURs)
        {
            DateTime = dateTime;
            RootCurrency = rootcur;
            exList = exCURs.ToList<ExchangeCurrency>();

        }
        public DateTime DateTime { get;  }
        public string RootCurrency { get; }
        public List<ExchangeCurrency> exList { get; }

        public double GetExchangeRate(string currencyToExchange, string currencyToGet)
        =>    currencyToGet.IF(
                (cur) => cur == RootCurrency,
                () => exList.First(x => x.CurrencyName == currencyToExchange).ExchangeRate,
                () => exList.First(x => x.CurrencyName == currencyToExchange).ExchangeRate / exList.First(x => x.CurrencyName == currencyToGet).ExchangeRate
                );
        public double GetExchangeAmount(double amountToExchange, string currencyToExchange, string currencyToGet)
        => amountToExchange * GetExchangeRate(currencyToExchange, currencyToGet); 
        
    }
}
