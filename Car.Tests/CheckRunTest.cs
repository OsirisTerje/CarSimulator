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
    }
}
