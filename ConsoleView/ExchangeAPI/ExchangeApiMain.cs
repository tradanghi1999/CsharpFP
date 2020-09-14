using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeAPI
{
    public class ExchangeApiMain
    {
        DataMapper dm;
        public ExchangeApiMain()
        {
            dm = new DataMapper();
        }
        public ExchangeInteractor.DataGateway GetDataGateway()
            => dm;
    }
}
