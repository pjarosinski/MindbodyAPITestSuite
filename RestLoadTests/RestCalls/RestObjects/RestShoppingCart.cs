using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCalls.RestObjects
{
    public class RestShoppingCart
    {
        public int SeriesId { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public int UserBillingInfoId { get; set; }
    }
}
