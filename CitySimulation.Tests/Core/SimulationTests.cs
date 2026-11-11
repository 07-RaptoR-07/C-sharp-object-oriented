using CitySimulation.Core;
using CitySimulation.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CitySimulation.Tests.Core
{
    [TestClass]
    public class SimulationTests
    {
        // LOADFROMFILE metodus tesztek

        [TestMethod]
        public void LoadFromFile_HianyzoFajl_FileNotFoundExceptiontDob()
        {
            // Arrange
            var simulation = new Simulation();
            string nemLetezoFajl = "biztosan_nem_letezo_fajl_999.txt";

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() => simulation.LoadFromFile(nemLetezoFajl));
        }

        [TestMethod]
        public void LoadFromFile_UresFajl_EmptySimulationFileExceptiontDob()
        {
            // Arrange
            var simulation = new Simulation();

            // Létrehozunk egy üres ideiglenes fájlt a rendszer Temp mappájában
            string tempFajlPath = Path.GetTempFileName();

            try
            {
                // Act & Assert
                Assert.ThrowsException<EmptySimulationFileException>(() => simulation.LoadFromFile(tempFajlPath));
            }
            finally
            {
                // Tisztítás: Letöröljük a tesztfájlt, hogy ne foglalja a helyet
                if (File.Exists(tempFajlPath))
                {
                    File.Delete(tempFajlPath);
                }
            }
        }

        [TestMethod]
        public void LoadFromFile_ErvenyesFajl_NemDobKivetelt()
        {
            // Arrange
            var simulation = new Simulation();
            string tempFajlPath = Path.GetTempFileName();

            // Írunk bele egy érvényes tesztadatot (Kezdő állapot: 50, 1. év: 1000 japán, 4000 nyugati, 6000 egyéb)
            File.WriteAllText(tempFajlPath, "50\n1000 4000 6000\n");

            try
            {
                // Act
                simulation.LoadFromFile(tempFajlPath);

                // Assert
                // Ha ide eljut a kód és nem dobott Exceptiont a fenti sor, akkor a beolvasás sikeres volt.
            }
            finally
            {
                if (File.Exists(tempFajlPath))
                {
                    File.Delete(tempFajlPath);
                }
            }
        }

        // RUNSIMULATION METÓDUS TESZTEK

        [TestMethod]
        public void RunSimulation_AdatokBetolteseNelkul_InvalidOperationExceptiontDob()
        {
            // Arrange
            var simulation = new Simulation();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => simulation.RunSimulation());
        }

        [TestMethod]
        public void RunSimulation_ErvenyesBetoltottAdatokkal_HibaNelkulLefut()
        {
            // Arrange
            var simulation = new Simulation();
            string tempFajlPath = Path.GetTempFileName();

            // Komplexebb adat a teszteléshez (3 évnyi szimuláció)
            string tesztAdat = "50\n" +
                               "1000 4000 6000\n" +
                               "2000 3000 8000\n" +
                               "6500 5000 3000\n";
            File.WriteAllText(tempFajlPath, tesztAdat);

            simulation.LoadFromFile(tempFajlPath);

            try
            {
                // Act
                simulation.RunSimulation();

                // Assert
            }
            finally
            {
                if (File.Exists(tempFajlPath))
                {
                    File.Delete(tempFajlPath);
                }
            }
        }
    }
}