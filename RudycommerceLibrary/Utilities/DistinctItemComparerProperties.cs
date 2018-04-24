using RudycommerceLibrary.Models;
using RudycommerceLibrary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities
{
    public class DistinctItemComparerProperties : IEqualityComparer<NecessaryProductPropertyViewItem>
    {
        //https://stackoverflow.com/questions/1606679/remove-duplicates-in-the-list-using-linq

        public bool Equals(NecessaryProductPropertyViewItem x, NecessaryProductPropertyViewItem y)
        {
            return x.PropertyID == y.PropertyID &&
                x.LookupName == y.LookupName;
        }

        public int GetHashCode(NecessaryProductPropertyViewItem obj)
        {
            return obj.PropertyID.GetHashCode() ^
                obj.LookupName.GetHashCode() ;
        }
    }
}
