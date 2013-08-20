namespace MindBodyAPI.RequestDataModels
{
    public class ShoppingCartDataModel
    {
        public int SeriesId { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public int UserBillingInfoId { get; set; }
    }
}
