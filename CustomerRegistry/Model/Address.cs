using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry.Model
{
    internal class Address
    {
        internal string Street {  get; set; }
        internal string City { get; set; }
        internal string ZipCode { get; set; }
        internal Countries Countries { get; set; }
    }
}
