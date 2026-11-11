using CitySimulation.Exceptions;
using CitySimulation.Models;
using CitySimulation.Tourists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.Tourists
{
    [TestClass]
    public class WesternTouristTests
    {
        [TestMethod]
        public void Constructor_NegativLetszam_InvalidTouristCountExceptiontDob()
        {
            // Arrange
            int hibasLetszam = -5;

            // Act & Assert
            Assert.ThrowsException<InvalidTouristCountException>(() => new WesternTourist(hibasLetszam));
        }

        [TestMethod]
        public void CityTooDirtyToVisit_Meghivaskor_VartLetszamLeszATenylegesLetszam()
        {
            // Arrange
            var turista = new WesternTourist(1000);

            // Act
            turista.CityTooDirtyToVisit();

            // Assert
            Assert.AreEqual(1000, turista.ActualCount);
        }

        [TestMethod]
        public void CityAverageToVisit_Meghivaskor_TizSzazalekkalNoATenylegesLetszam()
        {
            // Arrange
            var turista = new WesternTourist(1000);

            // Act
            turista.CityAverageToVisit();

            // Assert
            Assert.AreEqual(1100, turista.ActualCount);
        }

        [TestMethod]
        public void CityPerfectToVisit_Meghivaskor_HarmincSzazalekkalNoATenylegesLetszam()
        {
            // Arrange
            var turista = new WesternTourist(1000);

            // Act
            turista.CityPerfectToVisit();

            // Assert
            Assert.AreEqual(1300, turista.ActualCount);
        }

        [TestMethod]
        public void Visit_ErvenyesVaros_KoltEsSzemetelSzazFonkentEgyet()
        {
            // Arrange
            var city = new City(50);
            var turista = new WesternTourist(1000);
            turista.CityTooDirtyToVisit();

            // Act
            turista.Visit(city);

            // Assert
            Assert.AreEqual(100_000_000L, city.Revenue);
            Assert.AreEqual(40, city.Status);
        }
    }
}