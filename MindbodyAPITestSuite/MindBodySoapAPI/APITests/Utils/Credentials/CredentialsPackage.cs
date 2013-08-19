using System;
using System.Reflection;

namespace MindbodySoapAPI.APITests.Utils.Credentials
{
    public class CredentialsPackage
    {

        public CredentialsPackage(APISourceCredentials sourceCreds, APIUserCredentials userCreds, APIStaffCredentials staffCreds)
        {
            SourceCredentials = sourceCreds;
            UserCredentials = userCreds;
            StaffCredential = staffCreds;
        }

        public static CredentialsPackage GetDefault(bool production)
        {
            var siteId = production ? DefaultCredentials.ProductionSiteId : DefaultCredentials.DevSiteId;
            var userCreds = new APIUserCredentials(DefaultCredentials.UserName, DefaultCredentials.UserPassword, siteId);
            var staffCreds = new APIStaffCredentials(DefaultCredentials.StaffUsername, DefaultCredentials.StaffPassword, siteId);
            var sourceCreds = production
                                  ? new APISourceCredentials(DefaultCredentials.SourceUser, DefaultCredentials.ProductionSourcePassword, siteId)
                                  : new APISourceCredentials(DefaultCredentials.SourceUser, DefaultCredentials.DevSourcePassword, siteId);

            return new CredentialsPackage(sourceCreds, userCreds, staffCreds);
        }

        public APISourceCredentials SourceCredentials { get; set; }

        public APIUserCredentials UserCredentials { get; set; }

        public APIStaffCredentials StaffCredential { get; set; }

        public static object GetXmlDetailLevel<T>()
        {
            var serviceName = typeof(T).Namespace;
            var xmlDetailType = Assembly.GetExecutingAssembly().GetType(serviceName + "." + "XMLDetailLevel");
            var enumer = Enum.ToObject(xmlDetailType, 2);
            return enumer;
        }
       
    }
}
