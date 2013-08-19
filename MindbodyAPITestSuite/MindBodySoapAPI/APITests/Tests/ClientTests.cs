using MbUnit.Framework;
using MindbodySoapAPI.APITests.Requests;
using MindbodySoapAPI.APITests.Utils.AssertHelpers;

namespace MindbodySoapAPI.APITests.Tests
{
    [TestFixture, Category("ClientTests"), Category("APITests")]
    public class ClientTests : APITestSuite
    {
        //Works fine for clients with an "active arrival Client Service", cannot repeat IDs
        //Test fails for clients without arrival service
        [Test,  Parallelizable]
        public void CheckAddArrival()
        {
            var test = GetTest("testAddArrival");
            var domainOneResult = ClientRequests.AddArrival(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.AddArrival(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine
        [Test,  Parallelizable]
        public void CheckGetClients()
        {
            var test = GetTest("testGetClients");
            var domainOneClients = ClientRequests.GetClients(test.ArgList, DomainOne);
            var domainTwoClients = ClientRequests.GetClients(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneClients, domainTwoClients);
        }


        //Works fine, no args, returns nothing with test credentials
        [Test,  Parallelizable]
        public void CheckGetCustomClientFields()
        {
            var test = GetTest("testGetCustomClientFields");
            var domainOneResult = ClientRequests.GetCustomClientFields(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetCustomClientFields(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine, no args
        [Test,  Parallelizable]
        public void CheckGetClientIndexes()
        {
            var test = GetTest("testGetClientIndexes");
            var domainOneResult = ClientRequests.GetClientIndexes(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientIndexes(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine
        [Test,  Parallelizable]
        public void CheckGetClientContactLogs()
        {
            var test = GetTest("testGetClientContactLogs");
            var domainOneResult = ClientRequests.GetClientContactLogs(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientContactLogs(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine, most of the work is in the JSON
        [Test,  Parallelizable]
        public void CheckAddOrUpdateContactLogs()
        {
            var test = GetTest("testAddOrUpdateContactLogs");
            var domainOneResult = ClientRequests.AddOrUpdateContactLogs(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.AddOrUpdateContactLogs(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine, no args
        [Test,  Parallelizable]
        public void CheckGetContactLogTypes()
        {
            var test = GetTest("testGetContactLogTypes");
            var domainOneResult = ClientRequests.GetContactLogTypes(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetContactLogTypes(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //"Works", BitConverter does NOT seem to correspond with result.FileSize, doesn't affect it much in SoapUI either
        // From a it uploads a blank file of whatever extension from no apparent location. 
        [Test,  Parallelizable]
        public void CheckUploadClientDocument()
        {
            var test = GetTest("testUploadClientDocument");
            var domainOneResult = ClientRequests.UploadClientDocument(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.UploadClientDocument(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine, no args
        [Test,  Parallelizable]
        public void CheckGetClientReferralTypes()
        {
            var test = GetTest("testGetClientReferralTypes");
            var domainOneResult = ClientRequests.GetClientReferralTypes(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientReferralTypes(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works Fine
        [Test,  Parallelizable]
        public void CheckGetActiveClientMemberships()
        {
            var test = GetTest("testGetActiveClientMemberships");
            var domainOneResult = ClientRequests.GetActiveClientMemberships(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetActiveClientMemberships(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine w/ or w/out LocationID
        [Test,  Parallelizable]
        public void CheckGetClientContracts()
        {
            var test = GetTest("testGetClientContracts");
            var domainOneResult = ClientRequests.GetClientContracts(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientContracts(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine
        [Test,  Parallelizable]
        public void CheckGetClientAccountBalancesRequest()
        {
            var test = GetTest("testGetClientAccountBalances");
            var domainOneResult = ClientRequests.GetClientAccountBalances(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientAccountBalances(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Requires valid Client/Program IDs, can't seem to pinpoint services
        [Test,  Parallelizable]
        public void CheckGetClientServices()
        {
            var test = GetTest("testGetClientServices");
            var domainOneResult = ClientRequests.GetClientServices(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientServices(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine
        [Test,  Parallelizable]
        public void CheckGetClientVisits()
        {
            var test = GetTest("testGetClientVisits");
            var domainOneResult = ClientRequests.GetClientVisits(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientVisits(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine
        [Test,  Parallelizable]
        public void CheckGetClientPurchases()
        {
            var test = GetTest("testGetClientPurchases");
            var domainOneResult = ClientRequests.GetClientPurchases(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientPurchases(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine
        [Test,  Parallelizable]
        public void CheckGetClientSchedule()
        {
            var test = GetTest("testGetClientSchedule");
            var domainOneResult = ClientRequests.GetClientSchedule(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetClientSchedule(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine, returns nothing with test credentials
        [Test,  Parallelizable]
        public void CheckGetRequiredClientFields()
        {
            var test = GetTest("testGetRequiredClientFields");
            var domainOneResult = ClientRequests.GetRequiredClientFields(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.GetRequiredClientFields(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }


        //Works fine, used for client credentials
        [Test,  Parallelizable]
        public void CheckValidateLogin()
        {
            var test = GetTest("testValidateLogin");
            var domainOneResult = ClientRequests.ValidateLogin(test.ArgList, DomainOne);
            var domainTwoResult = ClientRequests.ValidateLogin(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneResult, domainTwoResult);
        }
    }
}
