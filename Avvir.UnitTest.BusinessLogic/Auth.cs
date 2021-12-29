using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avvir.BusinessLogic.Auth;

namespace Avvir.UnitTest.BusinessLogic
{
    [TestClass]
    public class Auth
    {
        [TestMethod]
        public void TestHashPassword()
        {
            var hashPasswordObject = new HashPassword("password");
            hashPasswordObject.ProcessLogic();

            Assert.IsNotNull(hashPasswordObject.Hash);
        }
    }
}
