using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MindBodyAPI.RequestDataModels;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface ISeries
    {
        IRestResponse GetPricingOptionsForSpecificClass(int siteId, int classInstanceId);
        IRestResponse AddSeries(int siteId, SeriesDataModel series);
        IRestResponse UpdateSeries(int siteId, SeriesDataModel series);

    }
}
