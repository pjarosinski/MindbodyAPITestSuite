using MbUnit.Framework;
using MindbodySoapAPI.APITests.Requests;
using MindbodySoapAPI.APITests.Utils.AssertHelpers;

namespace MindbodySoapAPI.APITests.Tests
{
    [TestFixture, Category("AppointmentTests"), Category("APITests")]
    public class AppointmentTests : APITestSuite
    {
        [Test,  Parallelizable]
        public void GetAppointments()
        {
            var test = GetTest("testGetStaffAppointments");
            var domainOneApps = AppointmentRequests.GetStaffAppointments(test.ArgList, DomainOne);
            var domainTwoApps = AppointmentRequests.GetStaffAppointments(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneApps, domainTwoApps);
        }

        [Test,  Parallelizable]
        public void CheckAddOrUpdateAppointments()
        {
            var test = GetTest("testAddOrUpdateAppointments");
            var domainOneApps = AppointmentRequests.AddOrUpdateAppointments(test.ArgList, DomainOne);
            var domainTwoApps = AppointmentRequests.AddOrUpdateAppointments(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneApps, domainTwoApps);
        }

        [Test,  Parallelizable]
        public void CheckBookableItems()
        {
            var test = GetTest("testGetBookableItems");
            var domainOneScheduleItems = AppointmentRequests.GetBookableItems(test.ArgList, DomainOne);
            var domainTwoScheduleItems = AppointmentRequests.GetBookableItems(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneScheduleItems, domainTwoScheduleItems);
        }

        [Test,  Parallelizable]
        public void CheckScheduleItems()
        {
            var test = GetTest("testGetScheduleItems");
            var domainOneStaff = AppointmentRequests.GetScheduleItems(test.ArgList, DomainOne);
            var domainTwoStaff = AppointmentRequests.GetScheduleItems(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneStaff, domainTwoStaff);
        }

        [Test,  Parallelizable]
        public void CheckAddOrUpdateAvailabilities()
        {

            var test = GetTest("testAddOrUpdateAvailabilities");
            var apptsDomainOne = AppointmentRequests.AddOrUpdateAvailabilities(test.ArgList, DomainOne);
            var apptsDomainTwo = AppointmentRequests.AddOrUpdateAvailabilities(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(apptsDomainOne, apptsDomainTwo);
        }

        [Test,  Parallelizable]
        public void CheckActiveSessionTimes()
        {

            var test = GetTest("testGetActiveSessionTimes");
            var datetimesDomainOne = AppointmentRequests.GetActiveSessionTimes(test.ArgList, DomainOne);
            var dateTimesDomainTwo = AppointmentRequests.GetActiveSessionTimes(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(datetimesDomainOne, dateTimesDomainTwo);
        }

        [Test,  Parallelizable]
        public void CheckAppointmentOptions()
        {

            var test = GetTest("testGetAppointmentOptions");
            var optionsDomainOne = AppointmentRequests.GetAppointmentOptions(test.ArgList, DomainOne);
            var optionsDomainTwo = AppointmentRequests.GetAppointmentOptions(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(optionsDomainOne, optionsDomainTwo);
        }

    }
}
