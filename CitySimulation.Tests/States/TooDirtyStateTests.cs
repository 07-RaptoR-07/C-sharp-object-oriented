using CitySimulation.States;
using CitySimulation.Tourists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.States
{
    [TestClass]
    public class TooDirtyStateTests
    {
        [TestMethod]
        public void CalculateActual_NullTurista_ArgumentNullExceptiontDob()
        {
            // Arrange
            var state = new TooDirtyState();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => state.CalculateActual(null!));
        }

        [TestMethod]
        public void CalculateActual_ErvenyesTurista_MegfeleloMetodustHivja()
        {
            // Arrange
            var state = new TooDirtyState();
            var turista = new JapaneseTourist(1000);

            // Act
            state.CalculateActual(turista);

            // Assert
            Assert.AreEqual(0, turista.ActualCount);
        }
    }
}