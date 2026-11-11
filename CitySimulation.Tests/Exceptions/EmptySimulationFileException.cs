using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitySimulation.Exceptions;

namespace CitySimulation.Tests.Exceptions
{
    [TestClass]
    public class EmptySimulationFileExceptionTests
    {
        [TestMethod]
        public void Constructor_MegadottUzenettel_HelyesenBeallitjaAMessagePropertyt()
        {
            // Arrange
            string vartUzenet = "Ez egy teszt hibaüzenet az üres fájlhoz.";

            // Act
            var kivetel = new EmptySimulationFileException(vartUzenet);

            // Assert
            Assert.AreEqual(vartUzenet, kivetel.Message);
        }
    }
}