using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCalls.RestObjects
{
    public class RestStaffInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Scope { get; set; }
        public string GrantType { get; set; }
        public int SubscriberId { get; set; }
    }
}
