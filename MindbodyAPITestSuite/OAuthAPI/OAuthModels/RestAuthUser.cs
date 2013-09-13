namespace OAuthAPI.OAuthModels
{
    public class RestAuthUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public string Scope = "urn:mboframeworkapi"; 
        
        public string GrantType  = "password"; 
    }
}
