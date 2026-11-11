using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitySimulation.Exceptions;

namespace CitySimulation.Tests.Exceptions
{
    [TestClass]
    public class InvalidTouristCountExceptionTests
    {
        [TestMethod]
        public void Constructor_MegadottUzenettel_HelyesenBeallitjaAMessagePropertyt()
        {
            // Arrange
            string vartUzenet = "Ez egy teszt hibaüzenet a turisták számához.";

            // Act
            var kivetel = new InvalidTouristCountException(vartUzenet);

            // Assert
            Assert.AreEqual(vartUzenet, kivetel.Message);
        }
    }
}