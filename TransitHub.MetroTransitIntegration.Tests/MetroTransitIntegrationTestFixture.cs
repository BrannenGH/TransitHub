using System.Diagnostics;
using NUnit.Framework;
using TransitHub.MetroTransitIntegration;
using Moq;
using TransitHub.MetroTransitIntegration.Models;

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
            var routes = client.GetRoutesAsync().Result;
            Assert.IsNotEmpty(routes);
        }

        [Test]
        public void GetDirectionsTest()
        {
            var mockRoute = new Mock<MetroTransitRoute>();
            mockRoute.SetupGet(o => o.Id).Returns(5);
            Assert.IsNotEmpty(mockRoute.Object.Directions);
        }

        [Test]
        public void GetStopsTest()
        {
            var mockRoute = new Mock<MetroTransitRoute>();
            mockRoute.SetupGet(o => o.Id).Returns(5);
            Assert.IsNotEmpty(
                mockRoute.Object
                .GetStopsForDirection(MetroTransitDirection.North)
                );
        }

        [Test]
        public void GetBusLocationsTest()
        {
            var mockRoute = new Mock<MetroTransitRoute>();
            mockRoute.SetupGet(o => o.Id).Returns(10);
            Assert.IsNotEmpty(
                mockRoute.Object
                .GetVehicles()
                );
        }
    }
}
