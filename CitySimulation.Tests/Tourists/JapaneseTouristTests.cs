using CitySimulation.Exceptions;
using CitySimulation.Models;
using CitySimulation.Tourists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.Tourists
{
    [TestClass]
    public class JapaneseTouristTests
    {
        [TestMethod]
        public void Constructor_NegativLetszam_InvalidTouristCountExceptiontDob()
        {
            // Arrange
            int hibasLetszam = -100;

            // Act & Assert
            Assert.ThrowsException<InvalidTouristCountException>(() => new JapaneseTourist(hibasLetszam));
        }

        [TestMethod]
        public void CityTooDirtyToVisit_Meghivaskor_NullaLeszATenylegesLetszam()
        {
            // Arrange
            var turista = new JapaneseTourist(1000);

            // Act
            turista.CityTooDirtyToVisit();

            // Assert
            Assert.AreEqual(0, turista.ActualCount);
        }

        [TestMethod]
        public void CityAverageToVisit_Meghivaskor_VartLetszamLeszATenylegesLetszam()
        {
            // Arrange
            var turista = new JapaneseTourist(1000);

            // Act
            turista.CityAverageToVisit();

            // Assert
            Assert.AreEqual(1000, turista.ActualCount);
        }

        [TestMethod]
        public void CityPerfectToVisit_Meghivaskor_HuszSzazalekkalNoATenylegesLetszam()
        {
            // Arrange
            var turista = new JapaneseTourist(1000);

            // Act
            turista.CityPerfectToVisit();

            // Assert
            Assert.AreEqual(1200, turista.ActualCount);
        }

        [TestMethod]
        public void Visit_NullVaros_ArgumentNullExceptiontDob()
        {
            // Arrange
            var turista = new JapaneseTourist(1000);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => turista.Visit(null!));
        }

        [TestMethod]
        public void Visit_ErvenyesVaros_CsakKoltNemSzemetel()
        {
            // Arrange
            var city = new City(50);
            var turista = new JapaneseTourist(1000);
            turista.CityAverageToVisit();

            // Act
            turista.Visit(city);

            // Assert
            Assert.AreEqual(100_000_000L, city.Revenue);
            Assert.AreEqual(50, city.Status);
        }
    }
}