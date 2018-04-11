using RudycommerceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities
{
    public class DistinctItemComparerProperties : IEqualityComparer<NecessaryProductProperties>
    {
        //https://stackoverflow.com/questions/1606679/remove-duplicates-in-the-list-using-linq

        public bool Equals(NecessaryProductProperties x, NecessaryProductProperties y)
        {
            return x.PropertyID == y.PropertyID &&
                x.LookupName == y.LookupName;
        }

        public int GetHashCode(NecessaryProductProperties obj)
        {
            return obj.PropertyID.GetHashCode() ^
                obj.LookupName.GetHashCode() ;
        }
    }
}
