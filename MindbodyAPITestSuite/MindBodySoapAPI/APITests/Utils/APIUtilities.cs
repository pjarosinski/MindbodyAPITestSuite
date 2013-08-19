using System.Collections.Generic;
using MindbodySoapAPI.APITests.Utils.ParsingTools;

namespace MindbodySoapAPI.APITests.Utils
{
    public static class APIUtilities
    {
        public static TService BuildService<TService>(string domain, bool useHttps) where TService : new()
        {
            dynamic service = new TService();
            service.Url = ApiUrlBuilder.BuildUrl(domain, typeof (TService).Name, useHttps);
            return service;
        }

        public static T BuildService<T>(T service, string domain, bool useHttps)
        {
            dynamic serviceObj = service;
            serviceObj.Url = ApiUrlBuilder.BuildUrl(domain, typeof (T).Name, useHttps);
            return serviceObj;
        }

        public static T BuildRequestFromBase<T>(T baseRequest, List<Argument> args)
        {
            return (T) new RequestBuilder(baseRequest, args).Build();
        }

        public static T BuildBaseRequest<T>(List<Argument> args, string domain, bool useStaffCreds = false) where T : new()
        {
            return RequestBuilder.GetBaseRequest<T>(Production(domain), useStaffCreds);
            //return BuildRequestFromBase(baseRequest, args);
        }

        private static bool Production(string subdomain)
        {
            return subdomain.Contains("clients") || subdomain.Equals("api");
        }
    }
}
