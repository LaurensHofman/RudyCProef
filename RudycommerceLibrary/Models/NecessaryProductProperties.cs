using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Models
{
    public class NecessaryProductProperties
    {
        public string LookupName { get; set; }

        public bool IsBool { get; set; }

        public bool IsMultilingual { get; set; }

        public bool IsRequired { get; set; }

        public int CategoryID { get; set; }

        public int PropertyID { get; set; }
    }
}
