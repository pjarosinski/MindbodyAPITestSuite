namespace MindbodySoapAPI.APITests.Utils
{
    public class ApiUrlBuilder
    {
        private const string Clients = "clients";
        private const string Mindbody = ".mindbodyonline.com";
        private const string Https = "https://";
        private const string Http = "http://";
        private const string ApiVersion = "/0_5/";
        private string _builtUrl = "";
        private bool UseHttps { get; set; }
        private bool IsDefaultApiDomain { get; set; }
        private string Domain { get; set; }
        private string Url { get { return _builtUrl; } }
        private readonly string _serviceName;

        public ApiUrlBuilder(string domain, string serviceName, bool useHttps = false)
        {
            UseHttps = useHttps;
            _serviceName = serviceName;
            CheckDomain(domain);
        }

        public static string BuildUrl(string domain, string serviceName, bool useHttps)
        {
            return new ApiUrlBuilder(domain, serviceName, useHttps).Build();
        }

        public string Build()
        {
            return SetHttpOrHttpsSegment().SetDomainSegment().SetServiceSegment().Url;
        }

        private void CheckDomain(string domain)
        {
            IsDefaultApiDomain = domain.Equals("api");
            Domain = domain.Contains("-api") ? domain.Split('-')[0] : domain;
        }

        private ApiUrlBuilder SetHttpOrHttpsSegment()
        {
            _builtUrl = UseHttps ? Https : Http;
            return this;
        }

        private ApiUrlBuilder SetDomainSegment()
        {
            _builtUrl += IsClientsDomain() ? BuildClientsSegment() : BuildSubDomainSegment();
            return this;
        }

        private ApiUrlBuilder SetServiceSegment()
        {
            _builtUrl += ApiVersion + _serviceName + ".asmx?wsdl";
            return this;
        }

        private bool IsClientsDomain()
        {
            return Domain.Equals("clients");
        }

        private static string BuildClientsSegment()
        {
            return Clients + Mindbody + "/api";
        }

        private string BuildSubDomainSegment()
        {
            if (IsDefaultApiDomain)
            {
                return Domain + Mindbody;
            }
            return Domain + "-api" + Mindbody;
        }

    }
}


