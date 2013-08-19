using System;
using System.Reflection;

namespace MindbodySoapAPI.APITests.Utils.Credentials
{
    public abstract class APICredentials
    {
        protected APICredentials(int siteId)
        {
            SiteIds = new[] { siteId };
        }

        public int[] SiteIds { get; set; }

        public Type GetCredentialType<T>(string typeName)
        {
            var serviceName = typeof(T).Namespace;
            return Assembly.GetExecutingAssembly().GetType(serviceName + "." + typeName);
        }

        public abstract object ConvertToServiceCreds<T>();

    }
}
