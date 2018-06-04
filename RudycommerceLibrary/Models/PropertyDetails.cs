using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Models
{
    public class PropertyDetails
    {
        public int PropertyID { get; set; }

        public bool IsMultilingual { get; set; }

        public string LookupName { get; set; }

        public bool IsEnumeration { get; set; }

        public bool IsBool { get; set; } 

        public string AdviceDescription { get; set; }
    }
}
