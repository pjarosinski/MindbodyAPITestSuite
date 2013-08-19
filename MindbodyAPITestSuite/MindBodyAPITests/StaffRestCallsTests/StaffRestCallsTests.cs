using System;
using MbUnit.Framework;
using MindBodyAPI.RestRequestObjects;
using MindBodyAPI.StaffRestCalls;
using RestSharp;

namespace MindBodyAPITests.StaffRestCallsTests
{
    public class StaffRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void StaffTokenTest()
        {
            RestRequestStaffInfo staff = new RestRequestStaffInfo
                {
                    Username = "masteryoda",
                    Password = "test1234",
                    Scope = "urn:mboframeworkapi",
                    GrantType = "password",
                    SubscriberId = -4926
                };

            StaffRestCalls staffRestCalls = new StaffRestCalls(null, null);

            IRestResponse response = staffRestCalls.StaffToken(staff);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddStaffTest()
        {
            RestRequestStaff staff = new RestRequestStaff
                {
                    Firstname = "chris",
                    Lastname = "essley4",
                    Bio = "cali",
                    Email = "chris.essley@mindbodyonline.com",
                    Phone = "555-555-5555",
                    IsFemale = false
                };

            int siteId = -40000;

            StaffRestCalls staffRestCalls = new StaffRestCalls(null, null);

            IRestResponse response = staffRestCalls.AddStaff(siteId, staff);
            
            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void UpdateStaffTest()
        {
            RestRequestStaff staff = new RestRequestStaff
            {
                Firstname = "chris",
                Lastname = "essley4",
                Bio = "cali",
                Email = "chris.essley@mindbodyonline.com",
                Phone = "555-555-5555",
                IsFemale = false
            };

            int siteId = -40000;

            int staffId = 3;

            StaffRestCalls staffRestCalls = new StaffRestCalls(null, null);

            IRestResponse response = staffRestCalls.UpdateStaff(siteId, staffId, staff);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void StaffPhotoTest()
        {
            string file = "3452w34523452345dfgsdfg";

            int siteId = -40000;

            int staffId = 3;

            StaffRestCalls staffRestCalls = new StaffRestCalls(null, null);

            IRestResponse response = staffRestCalls.StaffPhoto(siteId, staffId, file);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
