using System;

namespace MindbodySoapAPI.APITests.Utils.Credentials
{
    public class APIStaffCredentials : APIUserCredentials
    {
        public APIStaffCredentials(string userName, string password, int siteId)
            : base(userName, password, siteId)
        {
        }

        public override object ConvertToServiceCreds<T>()
        {
            dynamic userCreds = Activator.CreateInstance(GetCredentialType<T>("StaffCredentials"));
            userCreds.Username = Username;
            userCreds.Password = Password;
            userCreds.SiteIDs = base.SiteIds;
            return userCreds;
        }
    }
}
