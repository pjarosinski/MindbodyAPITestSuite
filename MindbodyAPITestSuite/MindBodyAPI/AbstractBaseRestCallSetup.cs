using MindBodyAPI.ResponseModels;

namespace MindBodyAPI
{
    public abstract class AbstractBaseRestCallSetup
    {
        protected AbstractBaseRestCallSetup(TokenModel generatedToken, TokenModel userToken)
        {
            GeneratedToken = generatedToken;
            UserToken = userToken;
        }
        //This is the user token attached to jim3.joneson@mindbodyonline.com's account. chris 7-22-13
        public TokenModel UserToken;

        public TokenModel GeneratedToken;

        public TokenModel StaffUserToken = new TokenModel { AccessToken  = "", RefreshToken = "" };
    }
}
