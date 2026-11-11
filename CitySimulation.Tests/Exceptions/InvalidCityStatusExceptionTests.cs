using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitySimulation.Exceptions;

namespace CitySimulation.Tests.Exceptions
{
    [TestClass]
    public class InvalidCityStatusExceptionTests
    {
        [TestMethod]
        public void Constructor_MegadottUzenettel_HelyesenBeallitjaAMessagePropertyt()
        {
            // Arrange
            string vartUzenet = "Ez egy teszt hibaüzenet a város állapotához.";

            // Act
            var kivetel = new InvalidCityStatusException(vartUzenet);

            // Assert
            Assert.AreEqual(vartUzenet, kivetel.Message);
        }
    }
}