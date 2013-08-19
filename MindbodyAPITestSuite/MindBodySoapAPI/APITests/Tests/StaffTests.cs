using MbUnit.Framework;
using MindbodySoapAPI.APITests.Requests;
using MindbodySoapAPI.APITests.Utils.AssertHelpers;

namespace MindbodySoapAPI.APITests.Tests
{
    [TestFixture, Category("StaffTests"), Category("APITests")]
    public class StaffTests : APITestSuite
    {
        [Test,  Parallelizable]
        public void GetAllStaff()
        {
            var test = GetTest("testGetStaff");
            var domainOneReturnedStaff = StaffRequests.GetStaff(test.ArgList, DomainOne);
            var domainTwoReturnedStaff = StaffRequests.GetStaff(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneReturnedStaff, domainTwoReturnedStaff);
        }

        [Test,  Parallelizable]
        public void GetStaffPermissions()
        {
            var test = GetTest("testGetStaffPermissions");
            var domainOnePermissions = StaffRequests.GetStaffPermissions(test.ArgList, DomainOne);
            var domainTwoPermissions = StaffRequests.GetStaffPermissions(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOnePermissions, domainTwoPermissions);
        }

        [Test,  Parallelizable]
        public void AddOrUpdateStaff()
        {
            var test = GetTest("testAddOrUpdateStaff");
            var domainOneRetrunedStaff = StaffRequests.AddOrUpdateStaff(test.ArgList, DomainOne);
            var domainTwoReturnedStaff = StaffRequests.AddOrUpdateStaff(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneRetrunedStaff, domainTwoReturnedStaff);
        }
    }
}
