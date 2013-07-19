using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestCalls.TaxRestCalls
{
    public class TaxRestCalls : AbstractBaseRestSetup
    {
        public IRestResponse GetTaxRates(int locationId, int siteId)
        {
            return new RestResponse();
        }

        public IRestResponse UpdateTaxRates(int locationId, int siteId)
        {
            return new RestResponse();
        }
    }
}
