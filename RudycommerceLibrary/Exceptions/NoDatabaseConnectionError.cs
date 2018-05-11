using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Exceptions
{
    public class NoDatabaseConnectionError : Exception
    {
        public NoDatabaseConnectionError(string message) : base(message) { }
    }
}
