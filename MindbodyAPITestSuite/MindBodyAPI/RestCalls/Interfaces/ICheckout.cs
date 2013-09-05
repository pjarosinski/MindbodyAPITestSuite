using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MindBodyAPI.RequestDataModels;
using RestSharp;

namespace MindBodyAPI.RestCalls.Interfaces
{
    interface ICheckout
    {
        IRestResponse CheckoutShoppingCart(int siteId, ShoppingCartDataModel cart);
    }
}
