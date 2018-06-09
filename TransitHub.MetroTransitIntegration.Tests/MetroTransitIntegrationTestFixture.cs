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
            client = MetroTransitClient.Client;
        }

        [Test] 
        public void GetProvidersTest()
        {
            var providers = client.GetProvidersAsync().Result;
            Assert.IsNotEmpty(providers);
        }

        [Test]
        public void GetRoutesTest()
        {
            //Assert.IsNotEmpty(client.GetRoutesAsync().Result);
        }
    }
}
