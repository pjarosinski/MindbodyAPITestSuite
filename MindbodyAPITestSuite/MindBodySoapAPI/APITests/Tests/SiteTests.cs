using MbUnit.Framework;
using MindbodySoapAPI.APITests.Requests;
using MindbodySoapAPI.APITests.Utils.AssertHelpers;

namespace MindbodySoapAPI.APITests.Tests
{
    [TestFixture, Category("SiteTests"), Category("APITests")]
    public class SiteTests : APITestSuite
    {
        [Test,  Parallelizable]
        public void GetSitesTest()
        {
            var test = GetTest("testGetSitesRequest");
            var domainOneSites = SiteRequests.GetSites(test.ArgList, DomainOne);
            var domainTwoSites = SiteRequests.GetSites(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneSites, domainTwoSites);
        }

        [Test,  Parallelizable]
        public void GetLocationsTest()
        {
            var test = GetTest("testGetLocationsRequest");
            var domainOneLocations = SiteRequests.GetLocations(test.ArgList, DomainOne);
            var domainTwoLocations = SiteRequests.GetLocations(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneLocations, domainTwoLocations);
        }

        [Test,  Parallelizable]
        public void GetActivationCodeTest()
        {
            var test = GetTest("testGetActivationCodeRequest");
            var domainOneLocations = SiteRequests.GetActiviationCode(test.ArgList, DomainOne);
            var domainTwoLocations = SiteRequests.GetActiviationCode(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneLocations, domainTwoLocations);
        }


        [Test,  Parallelizable]
        public void GetProgramsTest()
        {

            var test = GetTest("testGetProgramsRequest");
            var domainOnePrograms = SiteRequests.GetPrograms(test.ArgList, DomainOne);
            var domainTwoPrograms = SiteRequests.GetPrograms(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOnePrograms, domainTwoPrograms);
        }

        [Test,  Parallelizable]
        public void GetSessionTypesTest()
        {
            var test = GetTest("testGetSessionTypesRequest");
            var domainOneSessionTypes = SiteRequests.GetSessionTypes(test.ArgList, DomainOne);
            var domainTwoSessionTypes = SiteRequests.GetSessionTypes(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneSessionTypes, domainTwoSessionTypes);
        }

        [Test,  Parallelizable]
        public void GetResourcesTest()
        {
            var test = GetTest("testGetResourcesRequest");
            var domainOneResouces = SiteRequests.GetResources(test.ArgList, DomainOne);
            var domainTwoReources = SiteRequests.GetResources(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResouces, domainTwoReources);
        }

        [Test,  Parallelizable]
        public void GetRelationshipsTest()
        {
            var test = GetTest("testGetRelationshipsRequest");
            var domainOneRelationships = SiteRequests.GetRelationships(test.ArgList, DomainOne);
            var domainTwoRelationships = SiteRequests.GetRelationships(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneRelationships, domainTwoRelationships);
        }
    }
}
