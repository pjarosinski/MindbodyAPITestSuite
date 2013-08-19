using System;

namespace MindbodySoapAPI.APITests.Utils.Credentials
{
    public class APIUserCredentials : APICredentials
    {
        public APIUserCredentials(string userName, string password, int siteId)
            : base(siteId)
        {
            Username = userName;
            Password = password;
        }

        public override object ConvertToServiceCreds<T>()
        {
            dynamic userCreds = Activator.CreateInstance(GetCredentialType<T>("UserCredentials"));
            userCreds.Username = Username;
            userCreds.Password = Password;
            userCreds.SiteIDs = base.SiteIds;
            return userCreds;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
