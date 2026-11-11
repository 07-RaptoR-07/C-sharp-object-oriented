using CitySimulation.Exceptions;
using CitySimulation.Models;
using CitySimulation.Tourists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.Tourists
{
    [TestClass]
    public class OtherTouristTests
    {
        [TestMethod]
        public void Constructor_NegativLetszam_InvalidTouristCountExceptiontDob()
        {
            // Arrange
            int hibasLetszam = -10;

            // Act & Assert
            Assert.ThrowsException<InvalidTouristCountException>(() => new OtherTourist(hibasLetszam));
        }

        [TestMethod]
        public void CityTooDirtyToVisit_Meghivaskor_VartLetszamLeszATenylegesLetszam()
        {
            // Arrange
            var turista = new OtherTourist(1000);

            // Act
            turista.CityTooDirtyToVisit();

            // Assert
            Assert.AreEqual(1000, turista.ActualCount);
        }

        [TestMethod]
        public void CityAverageToVisit_Meghivaskor_TizSzazalekkalNoATenylegesLetszam()
        {
            // Arrange
            var turista = new OtherTourist(1000);

            // Act
            turista.CityAverageToVisit();

            // Assert
            Assert.AreEqual(1100, turista.ActualCount);
        }

        [TestMethod]
        public void CityPerfectToVisit_Meghivaskor_VartLetszamLeszATenylegesLetszam()
        {
            // Arrange
            var turista = new OtherTourist(1000);

            // Act
            turista.CityPerfectToVisit();

            // Assert
            Assert.AreEqual(1000, turista.ActualCount);
        }

        [TestMethod]
        public void Visit_ErvenyesVaros_KoltEsSzemetelOtvenFonkentEgyet()
        {
            // Arrange
            var city = new City(50);
            var turista = new OtherTourist(1000);
            turista.CityPerfectToVisit();

            // Act
            turista.Visit(city);

            // Assert
            Assert.AreEqual(100_000_000L, city.Revenue);
            Assert.AreEqual(30, city.Status);
        }
    }
}