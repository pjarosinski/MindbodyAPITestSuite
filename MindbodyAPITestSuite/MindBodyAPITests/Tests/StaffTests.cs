using System;
using MbUnit.Framework;
using MindBodyAPI.RequestDataModels;
using MindBodyAPI.RestCalls;
using RestSharp;

namespace MindBodyAPITests.Tests
{
    public class StaffTests : AbstractTestSuite
    {
        [Test]
        public void StaffTokenTest()
        {
            StaffInfoDataModel staff = new StaffInfoDataModel
                {
                    Username = "masteryoda",
                    Password = "test1234",
                    Scope = "urn:mboframeworkapi",
                    GrantType = "password",
                    SubscriberId = -4926
                };

            Staff staffCalls = new Staff(null, null);

            IRestResponse response = staffCalls.StaffToken(staff);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddStaffTest()
        {
            StaffDataModel staff = new StaffDataModel
                {
                    Firstname = "chris",
                    Lastname = "essley4",
                    Bio = "cali",
                    Email = "chris.essley@mindbodyonline.com",
                    Phone = "555-555-5555",
                    IsFemale = false
                };

            int siteId = -40000;

            Staff staffCalls = new Staff(null, null);

            IRestResponse response = staffCalls.AddStaff(siteId, staff);
            
            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void UpdateStaffTest()
        {
            StaffDataModel staff = new StaffDataModel
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

            Staff staffCalls = new Staff(null, null);

            IRestResponse response = staffCalls.UpdateStaff(siteId, staffId, staff);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void StaffPhotoTest()
        {
            string file = "3452w34523452345dfgsdfg";

            int siteId = -40000;

            int staffId = 3;

            Staff staffCalls = new Staff(null, null);

            IRestResponse response = staffCalls.StaffPhoto(siteId, staffId, file);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
