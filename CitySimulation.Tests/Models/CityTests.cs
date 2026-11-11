using CitySimulation.Exceptions;
using CitySimulation.Models;
using CitySimulation.States;
using CitySimulation.Tourists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.Models
{
    [TestClass]
    public class CityTests
    {
        //Constructor tesztek

        [TestMethod]
        public void Constructor_ErvenyesAtlagosPontszam_KezdetiAllapotBeallitva()
        {
            // Arrange
            int ervenyesPontszam = 50;

            // Act
            var city = new City(ervenyesPontszam);

            // Assert
            Assert.AreEqual(ervenyesPontszam, city.Status);
            Assert.AreEqual(0, city.Revenue);
            Assert.IsInstanceOfType(city.CurrentState, typeof(AverageState));
        }

        [TestMethod]
        public void Constructor_KisebbMintEgy_InvalidCityStatusExceptiontDob()
        {
            // Arrange
            int ervenytelenPontszam = 0;

            // Act & Assert
            Assert.ThrowsException<InvalidCityStatusException>(() => new City(ervenytelenPontszam));
        }

        [TestMethod]
        public void Constructor_NagyobbMintSzaz_InvalidCityStatusExceptiontDob()
        {
            // Arrange
            int ervenytelenPontszam = 101;

            // Act & Assert
            Assert.ThrowsException<InvalidCityStatusException>(() => new City(ervenytelenPontszam));
        }

        //Clean tesztek

        [TestMethod]
        public void Clean_NovelesSzazAlatt_HelyesenNovel()
        {
            // Arrange
            var city = new City(50);
            int javitas = 20;

            // Act
            city.Clean(javitas);

            // Assert
            Assert.AreEqual(70, city.Status);
        }

        [TestMethod]
        public void Clean_NovelesSzazFelett_SzaznalMegall()
        {
            // Arrange
            var city = new City(90);
            int javitas = 30;

            // Act
            city.Clean(javitas);

            // Assert
            Assert.AreEqual(100, city.Status);
        }

        [TestMethod]
        public void Clean_NegativErtek_ArgumentOutOfRangeExceptiontDob()
        {
            // Arrange
            var city = new City(50);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => city.Clean(-10));
        }

        //Litter tesztek

        [TestMethod]
        public void Litter_CsokkentesEgyFelett_HelyesenCsokkent()
        {
            // Arrange
            var city = new City(50);
            int rontas = 20;

            // Act
            city.Litter(rontas);

            // Assert
            Assert.AreEqual(30, city.Status);
        }

        [TestMethod]
        public void Litter_CsokkentesEgyAla_EgynelMegall()
        {
            // Arrange
            var city = new City(10);
            int rontas = 20;

            // Act
            city.Litter(rontas);

            // Assert
            Assert.AreEqual(1, city.Status);
        }

        [TestMethod]
        public void Litter_NegativErtek_ArgumentOutOfRangeExceptiontDob()
        {
            // Arrange
            var city = new City(50);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => city.Litter(-10));
        }

        //Pénzügyi tesztek

        [TestMethod]
        public void Spend100k_PozitivLetszam_BevetelNo()
        {
            // Arrange
            var city = new City(50);
            int letszam = 5;

            // Act
            city.Spend100k(letszam);

            // Assert
            Assert.AreEqual(500_000L, city.Revenue);
        }

        [TestMethod]
        public void Spend100k_NegativLetszam_ArgumentOutOfRangeExceptiontDob()
        {
            // Arrange
            var city = new City(50);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => city.Spend100k(-5));
        }

        [TestMethod]
        public void ResetRevenue_HivasUtan_NullazzaABevetelt()
        {
            // Arrange
            var city = new City(50);
            city.Spend100k(10);

            // Act
            city.ResetRevenue();

            // Assert
            Assert.AreEqual(0, city.Revenue);
        }

        //UpdateState tesztek-

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(33)]
        public void UpdateState_HarmincharomVagyAlatta_TooDirtyStateLesz(int pont)
        {
            // Arrange
            var city = new City(100);
            city.Litter(100 - pont);

            // Act
            city.UpdateState();

            // Assert
            Assert.IsInstanceOfType(city.CurrentState, typeof(TooDirtyState));
        }

        [DataTestMethod]
        [DataRow(34)]
        [DataRow(67)]
        public void UpdateState_HatvanhetVagyAlatta_AverageStateLesz(int pont)
        {
            // Arrange
            var city = new City(100);
            city.Litter(100 - pont);

            // Act
            city.UpdateState();

            // Assert
            Assert.IsInstanceOfType(city.CurrentState, typeof(AverageState));
        }

        [DataTestMethod]
        [DataRow(68)]
        [DataRow(100)]
        public void UpdateState_HatvannyolctolFelfele_PerfectStateLesz(int pont)
        {
            // Arrange
            var city = new City(50);
            city.Clean(pont - 50);

            // Act
            city.UpdateState();

            // Assert
            Assert.IsInstanceOfType(city.CurrentState, typeof(PerfectState));
        }

        //Objektum interakciós tesztek

        [TestMethod]
        public void ExpectedTourists_NullLista_ArgumentNullExceptiontDob()
        {
            // Arrange
            var city = new City(50);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => city.ExpectedTourists(null!));
        }

        [TestMethod]
        public void Accept_NullTurista_ArgumentNullExceptiontDob()
        {
            // Arrange
            var city = new City(50);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => city.Accept(null!));
        }
    }
}