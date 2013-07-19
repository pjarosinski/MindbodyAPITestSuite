using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCalls.RestObjects
{
    public class RestStaff
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsFemale { get; set; }
    }
}
