using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbUnitExperiments
{
    public abstract class AbstractBaseRestSetup
    {
        public string AccessToken {
            get { return _accessToken; }
        }

        public string RefreshToken {
            get { return _refreshToken; }
        }

        private readonly string _accessToken =
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOi8vYXV0aC5tYm9kZXYubWUvdHJ1c3QvdjIiLCJhdWQiOiJ1cm46bWJvZnJhbWV3b3JrYXBpIiwibmJmIjoxMzcyNzAxNzM0LCJleHAiOjEzNzI3MDg5MzQsIm5hbWVpZCI6ImFwaV91c2VyIiwidW5pcXVlX25hbWUiOiJhcGlfdXNlciIsImF1dGhtZXRob2QiOiJPQXV0aDIiLCJhdXRoX3RpbWUiOiIyMDEzLTA3LTAxVDE4OjAyOjE0LjI3NFoiLCJodHRwOi8vaWRlbnRpdHlzZXJ2ZXIudGhpbmt0ZWN0dXJlLmNvbS9jbGFpbXMvY2xpZW50IjoiVGVzdENsaWVudCIsImh0dHA6Ly9pZGVudGl0eXNlcnZlci50aGlua3RlY3R1cmUuY29tL2NsYWltcy9zY29wZSI6InVybjptYm9mcmFtZXdvcmthcGkiLCJyb2xlIjoiTWluZGJvZHlBcGlDbGllbnQifQ.N-KGbyIN4PX42EuqGoUSyq5_-df84Vvv93i0xXDJJMQ";

        private readonly string _refreshToken = "4955c2ef36f9470987afd420e6ebd9b9";
    }
}
