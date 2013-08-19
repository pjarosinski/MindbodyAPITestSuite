using System.Collections.Generic;
using MindbodySoapAPI.APITests.Models;
using MindbodySoapAPI.APITests.Utils;
using MindbodySoapAPI.APITests.Utils.ParsingTools;
using MindbodySoapAPI.SaleService;

namespace MindbodySoapAPI.APITests.Requests
{
    public class SaleRequests
    {
        public static SaleService.SaleService Service { get { return new SaleService.SaleService(); } }

        public static APIResult<GetAcceptedCardTypeResult, string[]> AcceptedCardTypes(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetAcceptedCardTypeRequest>(args, domain);
            request.CurrentPageIndex = Argument.GetArgument(args, "CurPageIndex").ConvertToIntNullable();
            request.PageSize = Argument.GetArgument(args, "PageSize").ConvertToIntNullable();

            GetAcceptedCardTypeResult results = service.GetAcceptedCardType(request);
            return new APIResult<GetAcceptedCardTypeResult, string[]>(results, results.CardTypes, domain);
        }

        public static APIResult<GetSalesResult, Sale[]> GetSales(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetSalesRequest>(args, domain);

            request.StartSaleDateTime = Argument.GetArgument(args, "StartSaleDateTime").ConvertToDateTime();
            request.EndSaleDateTime = Argument.GetArgument(args, "EndSaleDateTime").ConvertToDateTime();
            request.PaymentMethodID = Argument.GetArgument(args, "PaymentMethodID").ConvertToIntNullable();
            request.SaleID = Argument.GetArgument(args, "SaleID").ConvertToLongNullable();

            GetSalesResult results = service.GetSales(request);
            return new APIResult<GetSalesResult, Sale[]>(results, results.Sales, domain);
        }

        public static APIResult<GetServicesResult, Service[]> GetServices(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetServicesRequest>(args, domain);

            request.ClassID = Argument.GetArgument(args, "ClassID").ConvertToInt();
            request.ClassScheduleID = Argument.GetArgument(args, "ClassScheduleID").ConvertToInt();
            request.ProgramIDs = Argument.GetArgument(args, "ProgramIDs").ConvertToIntArray();
            request.SessionTypeIDs = Argument.GetArgument(args, "SessionTypeIDs").ConvertToIntArray();
            request.SellOnline = Argument.GetArgument(args, "SellOnline").ConvertToBool();
            request.LocationID = Argument.GetArgument(args, "LocationID").ConvertToInt();
            request.ServiceIDs = Argument.GetArgument(args, "ServiceIDs").ConvertToStringArray();

            GetServicesResult results = service.GetServices(request);
            return new APIResult<GetServicesResult, Service[]>(results, results.Services, domain);
        }

        public static APIResult<UpdateServicesResult, Service[]> UpdateServices(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<UpdateServicesRequest>(args, domain);

            request.Services = Argument.GetArgument(args, "Services").ConvertToServiceArray();
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();

            UpdateServicesResult results = service.UpdateServices(request);
            return new APIResult<UpdateServicesResult, Service[]>(results, results.Services, domain);
        }

        public static APIResult<GetPackagesResult, Package[]> GetPackages(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetPackagesRequest>(args, domain);

            request.PackageIDs = Argument.GetArgument(args, "PackageIDs").ConvertToIntArray();
            request.SellOnline = Argument.GetArgument(args, "SellOnline").ConvertToBool();

            GetPackagesResult results = service.GetPackages(request);
            return new APIResult<GetPackagesResult, Package[]>(results, results.Packages, domain);
        }

        public static APIResult<GetProductsResult, Product[]> GetProducts(List<Argument> args, string domain,bool useHttps = false)                                               
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<GetProductsRequest>(args, domain);

            request.ProductIDs = Argument.GetArgument(args, "ProductIDs").ConvertToStringArray();

            GetProductsResult results = service.GetProducts(request);
            return new APIResult<GetProductsResult, Product[]>(results, results.Products, domain);
        }

        public static APIResult<UpdateProductsResult, Product[]> UpdateProducts(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<UpdateProductsRequest>(args, domain);

            request.Products = Argument.GetArgument(args, "Products").ConvertToProductArray();
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();

            UpdateProductsResult results = service.UpdateProducts(request);
            return new APIResult<UpdateProductsResult, Product[]>(results, results.Products, domain);
        }

        public static APIResult<CheckoutShoppingCartResult, CartItem[]> CheckoutShoppingCart(List<Argument> args, string domain, bool useHttps = false)
        {
            var service = APIUtilities.BuildService(Service, domain, useHttps);
            var request = APIUtilities.BuildBaseRequest<CheckoutShoppingCartRequest>(args, domain);

            var fieldsArr = new[] { "noauth" };
            //add this to json 
            const int itemId = 1364;
            request.Payments = Argument.GetArgument(args, "Payments").ConvertToCreditCardInfoArray();
            request.CartItems = Argument.GetArgument(args, "CartItems").ConvertToCartItemArray(itemId);
            request.Test = Argument.GetArgument(args, "Test").ConvertToBoolNullable();
            request.ClientID = Argument.GetArgument(args, "ClientID").Value;
            request.Fields = fieldsArr;

            CheckoutShoppingCartResult results = service.CheckoutShoppingCart(request);
            return new APIResult<CheckoutShoppingCartResult, CartItem[]>(results, results.ShoppingCart.CartItems, domain);
        }
    }
}
