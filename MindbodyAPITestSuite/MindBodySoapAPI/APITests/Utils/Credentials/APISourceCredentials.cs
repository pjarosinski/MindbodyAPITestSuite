using System;

namespace MindbodySoapAPI.APITests.Utils.Credentials
{
    public class APISourceCredentials : APICredentials
    {
        public APISourceCredentials(string sourceUser, string sourcePassword, int siteId)
            : base(siteId)
        {
            SourceUser = sourceUser;
            SourcePassword = sourcePassword;
        }

        public string SourceUser { get; set; }
        public string SourcePassword { get; set; }
 
        public override object ConvertToServiceCreds<T>()
        {
            dynamic creds = Activator.CreateInstance(GetCredentialType<T>("SourceCredentials"));
            creds.SourceName = SourceUser;
            creds.Password = SourcePassword;
            creds.SiteIDs = base.SiteIds;
            return creds;
        }


    }
}
