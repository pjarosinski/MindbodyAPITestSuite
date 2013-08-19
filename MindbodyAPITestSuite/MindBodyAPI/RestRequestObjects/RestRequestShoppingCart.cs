namespace MindBodyAPI.RestRequestObjects
{
    public class RestRequestShoppingCart
    {
        public int SeriesId { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public int UserBillingInfoId { get; set; }
    }
}
