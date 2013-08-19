using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthAPI.OAuthModels
{
    public class RestAuthUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public string Scope {
            get { return "urn:mboframeworkapi"; }
        }

        public string GrantType { 
            get { return "password"; } 
        }
    }
}
