using CitySimulation.States;
using CitySimulation.Tourists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.States
{
    [TestClass]
    public class AverageStateTests
    {
        [TestMethod]
        public void CalculateActual_NullTurista_ArgumentNullExceptiontDob()
        {
            // Arrange
            var state = new AverageState();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => state.CalculateActual(null!));
        }

        [TestMethod]
        public void CalculateActual_ErvenyesTurista_MegfeleloMetodustHivja()
        {
            // Arrange
            var state = new AverageState();
            var turista = new WesternTourist(1000);

            // Act
            state.CalculateActual(turista);

            // Assert
            Assert.AreEqual(1100, turista.ActualCount);
        }
    }
}