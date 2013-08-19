using MindBodyAPI.RestResponseObjects;

namespace MindBodyAPI
{
    public abstract class AbstractBaseRestSetup
    {
        //This is the user token attached to jim3.joneson@mindbodyonline.com's account. chris 7-22-13
        public RestResponseToken UserToken = new RestResponseToken
            {
                AccessToken =
                    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOi8vYXV0aC5tYm9kZXYubWUvdHJ1c3QvdjIiLCJhdWQiOiJ1cm46bWJvZnJhbWV3b3JrYXBpIiwibmJmIjoxMzc0NTA4ODMyLCJleHAiOjEzNzQ1MTYwMzIsIm5hbWVpZCI6ImppbTMuam9uZXNvbkBtaW5kYm9keW9ubGluZS5jb20iLCJ1bmlxdWVfbmFtZSI6ImppbTMuam9uZXNvbkBtaW5kYm9keW9ubGluZS5jb20iLCJhdXRobWV0aG9kIjoiT0F1dGgyIiwiYXV0aF90aW1lIjoiMjAxMy0wNy0yMlQxNjowMDozMi42MjRaIiwiaHR0cDovL2lkZW50aXR5c2VydmVyLnRoaW5rdGVjdHVyZS5jb20vY2xhaW1zL2NsaWVudCI6IlRlc3RDbGllbnQiLCJodHRwOi8vaWRlbnRpdHlzZXJ2ZXIudGhpbmt0ZWN0dXJlLmNvbS9jbGFpbXMvc2NvcGUiOiJ1cm46bWJvZnJhbWV3b3JrYXBpIiwiZW1haWwiOiJqaW0zLmpvbmVzb25AbWluZGJvZHlvbmxpbmUuY29tIn0.LwX1XqF8EaNyzIzvKkgpl9wKR9I2jhuKl0Mx52VU1Uo",
                RefreshToken = "5e1e9cfcbc9f4fcfabd03fd982407e11"
            };


        public RestResponseToken GeneratedToken = new RestResponseToken
            {
                AccessToken =
                    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOi8vYXV0aC5tYm9kZXYubWUvdHJ1c3QvdjIiLCJhdWQiOiJ1cm46bWJvZnJhbWV3b3JrYXBpIiwibmJmIjoxMzc2OTI4MjIwLCJleHAiOjEzNzY5MzU0MjAsIm5hbWVpZCI6ImFwaV91c2VyIiwidW5pcXVlX25hbWUiOiJhcGlfdXNlciIsImF1dGhtZXRob2QiOiJPQXV0aDIiLCJhdXRoX3RpbWUiOiIyMDEzLTA4LTE5VDE2OjAzOjQwLjQ5NVoiLCJodHRwOi8vaWRlbnRpdHlzZXJ2ZXIudGhpbmt0ZWN0dXJlLmNvbS9jbGFpbXMvY2xpZW50IjoiVGVzdENsaWVudCIsImh0dHA6Ly9pZGVudGl0eXNlcnZlci50aGlua3RlY3R1cmUuY29tL2NsYWltcy9zY29wZSI6InVybjptYm9mcmFtZXdvcmthcGkiLCJyb2xlIjoiTWluZGJvZHlBcGlDbGllbnQifQ.Ck5E66uh6PSaXsSnGnJeuDPT50kedEWMjIinOnKugJ8",
                RefreshToken = "271a307710af45378bb1160d5a22e137"
            };

        public RestResponseToken StaffUserToken = new RestResponseToken { AccessToken = "", RefreshToken = "" };
    }
}
