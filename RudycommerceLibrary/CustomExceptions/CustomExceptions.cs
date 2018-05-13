﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.CustomExceptions
{
    public class AlreadyADefaultLanguage : Exception
    {
        public AlreadyADefaultLanguage() : base("") { }
    }

    public class DatabaseQueryError : Exception
    {
        public DatabaseQueryError() : base("") { }
    }

    public class SaveFailed : Exception
    {
        public SaveFailed() : base ("") { }
    }
}
