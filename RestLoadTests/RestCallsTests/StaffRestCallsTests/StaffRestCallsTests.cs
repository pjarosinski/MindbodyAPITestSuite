using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using RestCalls.RestObjects;
using RestCalls.StaffRestCalls;
using RestSharp;

namespace RestCallsTests.StaffRestCallsTests
{
    public class StaffRestCallsTests : AbstractRestCallTestSuite
    {
        [Test]
        public void StaffTokenTest()
        {
            RestStaffInfo staff = new RestStaffInfo
                {
                    Username = "masteryoda",
                    Password = "test1234",
                    Scope = "urn:mboframeworkapi",
                    GrantType = "password",
                    SubscriberId = -4926
                };

            StaffRestCalls staffRestCalls = new StaffRestCalls();

            IRestResponse response = staffRestCalls.StaffToken(staff);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void AddStaffTest()
        {
            RestStaff staff = new RestStaff
                {
                    Firstname = "chris",
                    Lastname = "essley4",
                    Bio = "cali",
                    Email = "chris.essley@mindbodyonline.com",
                    Phone = "555-555-5555",
                    IsFemale = false
                };

            int siteId = -40000;

            StaffRestCalls staffRestCalls = new StaffRestCalls();

            IRestResponse response = staffRestCalls.AddStaff(siteId, staff);
            
            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }

        [Test]
        public void UpdateStaffTest()
        {
            RestStaff staff = new RestStaff
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

            StaffRestCalls staffRestCalls = new StaffRestCalls();

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

            StaffRestCalls staffRestCalls = new StaffRestCalls();

            IRestResponse response = staffRestCalls.StaffPhoto(siteId, staffId, file);

            Console.WriteLine(response.Content);

            Assert.AreNotEqual(0, response.ContentLength);
        }
    }
}
