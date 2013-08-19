using MbUnit.Framework;
using MindbodySoapAPI.APITests.Requests;
using MindbodySoapAPI.APITests.Utils.AssertHelpers;

namespace MindbodySoapAPI.APITests.Tests
{
    [TestFixture, Category("SaleTests"), Category("APITests")]
    public class SaleTests : APITestSuite
    {
        [Test,  Parallelizable]
        public void CheckAcceptedCardTypes()
        {
            var test = GetTest("testGetAcceptedCardTypes");
            var domainOneCardTypes = SaleRequests.AcceptedCardTypes(test.ArgList, DomainOne);
            var domainTwoCardTypes = SaleRequests.AcceptedCardTypes(test.ArgList, DomainOne);

            Assert_Api.AssertResults(domainOneCardTypes, domainTwoCardTypes);
        }

        [Test,  Parallelizable]
        public void CheckSales()
        {
            var test = GetTest("testGetSales");
            var domainOneSales = SaleRequests.GetSales(test.ArgList, DomainOne);
            var domainTwoSales = SaleRequests.GetSales(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneSales, domainTwoSales);
        }

        [Test,  Parallelizable]
        public void GetServices()
        {
            var test = GetTest("testGetServices");
            var domainOneServices = SaleRequests.GetServices(test.ArgList, DomainOne);
            var domainTwoServices = SaleRequests.GetServices(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneServices, domainTwoServices);
        }

        [Test,  Parallelizable]
        public void UpdateServices()
        {
            var Test = GetTest("testUpdateServices");
            var domainOneServices = SaleRequests.UpdateServices(Test.ArgList, DomainOne);
            var domainTwoServices = SaleRequests.UpdateServices(Test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneServices, domainTwoServices);
        }

        [Test,  Parallelizable]
        public void GetPackages()
        {
            var test = GetTest("testGetPackages");
            var domainOnePackages = SaleRequests.GetPackages(test.ArgList, DomainOne);
            var domainTwoPackages = SaleRequests.GetPackages(test.ArgList, DomainOne);

            Assert_Api.AssertResults(domainOnePackages, domainTwoPackages);
        }

        [Test,  Parallelizable]
        public void GetProducts()
        {
            var test = GetTest("testGetProducts");
            var domainOneProducts = SaleRequests.GetProducts(test.ArgList, DomainOne);
            var domainTwoProducts = SaleRequests.GetProducts(test.ArgList, DomainOne);

            Assert_Api.AssertResults(domainOneProducts, domainTwoProducts);
        }

        [Test,  Parallelizable]
        public void UpdateProducts()
        {
            var test = GetTest("testUpdateProducts");
            var domainOneProducts = SaleRequests.UpdateProducts(test.ArgList, DomainOne);
            var domainTwoProducts = SaleRequests.UpdateProducts(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneProducts, domainTwoProducts);
        }

        [Test,  Parallelizable]
        public void CheckoutShoppingCart()
        {
            //Todo make json test prepresentation
            var test = GetTest("testCheckoutShoppingCart");
            var domainOneCart = SaleRequests.CheckoutShoppingCart(test.ArgList, DomainOne);
            var domainTwoCart = SaleRequests.CheckoutShoppingCart(test.ArgList, DomainTwo);

            Assert_Api.AssertResults(domainOneCart, domainTwoCart);
        }


    }

}
