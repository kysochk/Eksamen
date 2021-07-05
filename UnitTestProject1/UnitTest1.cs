using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ЭкзаменПМ02;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Class1 c = new Class1();
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(c.Input());
        } 
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsNull(c.a);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(c.a, null);
        }
    }
}
