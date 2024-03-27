using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry.Model
{
    internal class Contact
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal Phone Phone { get; set; }
        internal Email Email { get; set; }
        internal Address Address { get; set; }
    }
}
