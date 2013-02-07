using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;
using BusinessLayer;

namespace BusinessLayerTest.UnitTest
{
    [TestClass]
    public class BusinessManagerTest
    {
        /// <summary>
        /// Pour dire qu'on a fait un test.
        /// </summary>
        [TestMethod]
        public void Test_SHA1()
        {
            String text = "ma chaine à hasher en SHA 1.";
            String encode = new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(text)).ToString();

            Assert.AreEqual(encode,BusinessManager.CalculateSHA1(text));
        }
    }
}
