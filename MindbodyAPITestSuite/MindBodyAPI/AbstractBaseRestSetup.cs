using MindBodyAPI.RestResponseObjects;

namespace MindBodyAPI
{
    public abstract class AbstractBaseRestSetup
    {
        protected AbstractBaseRestSetup(RestResponseToken generatedToken, RestResponseToken userToken)
        {
            GeneratedToken = generatedToken;
            UserToken = userToken;
        }
        //This is the user token attached to jim3.joneson@mindbodyonline.com's account. chris 7-22-13
        public RestResponseToken UserToken;

        public RestResponseToken GeneratedToken;

        public RestResponseToken StaffUserToken = new RestResponseToken { AccessToken  = "", RefreshToken = "" };
    }
}
