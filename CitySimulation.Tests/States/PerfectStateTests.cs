using CitySimulation.States;
using CitySimulation.Tourists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.States
{
    [TestClass]
    public class PerfectStateTests
    {
        [TestMethod]
        public void CalculateActual_NullTurista_ArgumentNullExceptiontDob()
        {
            // Arrange
            var state = new PerfectState();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => state.CalculateActual(null!));
        }

        [TestMethod]
        public void CalculateActual_ErvenyesTurista_MegfeleloMetodustHivja()
        {
            // Arrange
            var state = new PerfectState();
            var turista = new OtherTourist(1000);

            // Act
            state.CalculateActual(turista);

            // Assert
            Assert.AreEqual(1000, turista.ActualCount);
        }
    }
}