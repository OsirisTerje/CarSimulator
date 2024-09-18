using System;
using NUnit.Framework;

namespace CarSimulator.Tests
{
    public class CheckRunTest
    {
        [Test]
        public void CheckIt()
        {
            var webAppUrl = TestContext.Parameters["webAppUrl"];
            Assert.That(webAppUrl, Is.EqualTo("http://localhost"));
        }

        [Explicit]
        [Test]
        public void CheckExceptionHandling()
        {
            try
            {
                Assert.Fail();
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
