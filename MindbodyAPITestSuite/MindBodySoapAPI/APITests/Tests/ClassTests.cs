using System.Collections.Generic;
using MbUnit.Framework;
using MindbodySoapAPI.APITests.Requests;
using MindbodySoapAPI.APITests.Utils.AssertHelpers;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using Test = MindbodySoapAPI.APITests.Utils.ParsingTools.Test;

namespace MindbodySoapAPI.APITests.Tests
{
    [TestFixture, Category("ClassTests"), Category("APITests")]
    public class ClassTests : APITestSuite
    {
        [Test,  Parallelizable]
        public void GetAllClasses()
        {
            var test = GetTest("testGetClasses");
            var domainOneClasses = ClassRequests.GetClasses(test.ArgList, DomainOne);
            var domainTwoClasses = ClassRequests.GetClasses(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneClasses, domainTwoClasses);
        }

        [Test,  Parallelizable]
        public void GetClassDescriptionsTest()
        {
            var test = GetTest("testGetClassDescriptions");
            var domainOneClassDescriptions = ClassRequests.GetClassDescriptions(test.ArgList, DomainOne);
            var domainTwoClassDescriptions = ClassRequests.GetClassDescriptions(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneClassDescriptions, domainTwoClassDescriptions);
        }

        [Test,  Parallelizable]
        public void GetEnrollmentsTest()
        {
            var test = GetTest("testGetEnrollments");
            var domainOneEnrollments = ClassRequests.GetEnrollments(test.ArgList, DomainOne);
            var domainTwoEnrollments = ClassRequests.GetEnrollments(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneEnrollments, domainTwoEnrollments);
        }

        [Test,  Parallelizable]
        public void GetClassSchedulesTest()
        {
            var test = GetTest("testGetClassSchedules");
            var domainOneClassSchedules = ClassRequests.GetClassSchedules(test.ArgList, DomainOne);
            var domainTwoClassSchedules = ClassRequests.GetClassSchedules(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneClassSchedules, domainTwoClassSchedules);
        }

        [Test,  Parallelizable]
        public void GetAllClassVisits()
        {
            var test = GetTest("testGetClassVisits");
            var domainOneVisits = ClassRequests.GetClassVisits(test.ArgList, DomainOne);
            var domainTwoVisits = ClassRequests.GetClassVisits(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneVisits, domainTwoVisits);
        }

        [Test,  Parallelizable]
        public void CancelClassVisit()
        {
            var test = GetTest("testUpdateClientVisits");
            var domainOneVisits = ClassRequests.UpdateClientVisits(test.ArgList, DomainOne);
            var domainTwoVisits = ClassRequests.UpdateClientVisits(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneVisits, domainTwoVisits);


        }

        [Test,  Parallelizable]
        public void RemoveClientsFromClassesTest()
        {
            var test = GetTest("testRemoveClientsFromClasses");
            var domainOneClasses = ClassRequests.RemoveClientsFromClasses(test.ArgList, DomainOne);
            var domainTwoClasses = ClassRequests.RemoveClientsFromClasses(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneClasses, domainTwoClasses);

        }

        [Test,  Parallelizable]
        public void AddClientsToClasses()
        {
            var test = GetTest("testAddClientsToClasses");
            var domainOneClasses = ClassRequests.AddClientsToClasses(test.ArgList, DomainOne);
            var domainTwoClasses = ClassRequests.AddClientsToClasses(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneClasses, domainTwoClasses);
        }

        [Test,  Parallelizable]
        public void AddClientToWorkshop()
        {
            var test = GetTest("testAddClientsToEnrollments");
            var domainOneEnrollments = ClassRequests.AddClientsToEnrollments(test.ArgList, DomainOne);
            var domainTwoEnrollments = ClassRequests.AddClientsToEnrollments(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneEnrollments, domainTwoEnrollments);


        }

        //i think this call is legitimately broken. chris 10-4-2012
        [Test,  Parallelizable]
        public void RemoveClientFromWaitlist()
        {
            var test = new Test
                {
                    ArgList = new List<Argument> {new Argument {SoapNodeName = "WaitlistEntryIDs", Value = "100015016"}}
                };
            var domainOneRemovedClientStatus = ClassRequests.RemoveFromWaitlist(test.ArgList, DomainOne);
            test.ArgList = new List<Argument> { new Argument { SoapNodeName = "WaitlistEntryIDs", Value = "100015016" } };
            var domainTwoRemovedClientStatus = ClassRequests.RemoveFromWaitlist(test.ArgList, DomainTwo);

           Assert_Api.AssertResults(domainOneRemovedClientStatus, domainTwoRemovedClientStatus);

        }

        [Test,  Parallelizable]
        public void GetAllSemesters()
        {
            var test = GetTest("testGetSemesters");
            test.ArgList.Add(new Argument { SoapNodeName = "SiteIDs", Value = "-40000" });
            var domainOneSemesters = ClassRequests.GetSemesters(test.ArgList, DomainOne);
            var domainTwoSemesters = ClassRequests.GetSemesters(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneSemesters, domainTwoSemesters);
        }

        [Test,  Parallelizable]
        public void GetAllCourses()
        {
            var test = GetTest("testGetCourses");
            var domainOneCourses = ClassRequests.GetCourses(test.ArgList, DomainOne);
            var domainTwoCourses = ClassRequests.GetCourses(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneCourses, domainTwoCourses);

        }

        [Test,  Parallelizable]
        public void GetAllWaitlistEntries()
        {
            var test = GetTest("testGetWaitlistEntries");
            var domainOneWaitlistEntries = ClassRequests.GetWaitlistEntries(test.ArgList, DomainOne);
            var domainTwoWaitListEntries = ClassRequests.GetWaitlistEntries(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneWaitlistEntries, domainTwoWaitListEntries);

        }
    }
}
