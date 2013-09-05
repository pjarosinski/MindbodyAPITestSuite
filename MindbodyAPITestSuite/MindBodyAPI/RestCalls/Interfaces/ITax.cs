using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MindBodyAPI.RequestDataModels;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface ITax
    {
        IRestResponse GetTaxRates(int locationId, int siteId);
        IRestResponse UpdateTaxRates(int locationId, int siteId, TaxDataModel taxes);
    }
}
