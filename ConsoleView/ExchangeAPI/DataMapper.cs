using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeAPI
{
    internal class DataMapper :ExchangeInteractor.DataGateway
    {
        DataAPI api;
        public DataMapper()
        {
            this.api = new DataAPI();
        }
        public string GetExchangeXMLstring()
        {
            return api.GetExchangeXMLstring();
        }
    }
}
