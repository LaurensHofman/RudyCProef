using Microsoft.VisualStudio.TestTools.UnitTesting;
using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Utilities.Validations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Rudycommerce.Test
{
    [TestClass]
    public class LanguageTests
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void ISOContains3Letters()
        {
            using (var context = new AppDBContext())
            {
                //var ISOList = BL_Language.GetAllISOCodes();

                var ISOList = context.Languages.Where(l => l.DeletedAt == null).Select(l => l.ISO).ToArray();

                bool testResult = false;

                if (ISOList.Length > 0)
                {
                    testResult = true;

                    foreach (string ISO in ISOList)
                    {
                        if (!StringValidation.IsTextXLetters(ISO, 3))
                        {
                            testResult = false;
                        }
                    }
                }

                Assert.IsTrue(testResult);
            }
        }

    }
}
