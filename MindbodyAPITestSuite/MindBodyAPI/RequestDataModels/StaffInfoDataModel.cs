namespace MindBodyAPI.RequestDataModels
{
    public class StaffInfoDataModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Scope { get; set; }
        public string GrantType { get; set; }
        public int SubscriberId { get; set; }
    }
}
