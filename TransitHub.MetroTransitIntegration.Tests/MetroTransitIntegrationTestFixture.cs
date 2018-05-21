using System.Diagnostics;
using NUnit.Framework;
using TransitHub.MetroTransitIntegration;

namespace TransitHub.MetroTransitIntegration.Tests
{
    [TestFixture]
    public class MetroTransitIntegrationTestFixture
    {
        private MetroTransitClient client;
        
        [SetUp]
        public void CreateClient()
        {
            client = new MetroTransitClient();
        }

        [Test] 
        public void GetProvidersTest()
        {
            Assert.IsNotEmpty(client.GetProvidersAsync().Result);
        }

        [Test]
        public void GetRoutesTest()
        {
            Assert.IsNotEmpty(client.GetRoutesAsync().Result);
        }
    }
}
