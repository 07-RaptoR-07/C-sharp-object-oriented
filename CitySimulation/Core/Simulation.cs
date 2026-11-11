using CitySimulation.Models;
using CitySimulation.Tourists;
using CitySimulation.Exceptions;

namespace CitySimulation.Core
{
    public class Simulation
    {
        private City? city;
        private readonly List<List<Tourists.Tourists>> yearlyData;

        public Simulation()
        {
            yearlyData = new List<List<Tourists.Tourists>>();
        }

        /// <summary>
        /// Betölti a város kezdeti állapotát és a várt turisták számát egy fájlból.
        /// </summary>
        /// <param name="filename">A bemeneti fájl elérési útja.</param>
        /// <exception cref="FileNotFoundException">Ha a fájl nem létezik.</exception>
        /// <exception cref="EmptySimulationFileException">Ha a beolvasott fájl üres.</exception>
        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException("A megadott bemeneti fájl nem található.", filename);

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0) throw new EmptySimulationFileException("A fájl üres.");

            city = new City(int.Parse(lines[0]));

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3) continue;

                var touristsInYear = new List<Tourists.Tourists>
                {
                    new JapaneseTourist(int.Parse(parts[0])),
                    new WesternTourist(int.Parse(parts[1])),
                    new OtherTourist(int.Parse(parts[2]))
                };
                yearlyData.Add(touristsInYear);
            }
        }

        /// <summary>
        /// Futtatja az éves szimulációkat és kiírja a kért statisztikákat a konzolra.
        /// </summary>
        /// <exception cref="InvalidOperationException">Ha nincs adat betöltve a fájlból.</exception>
        public void RunSimulation()
        {
            if (city == null) throw new InvalidOperationException("A szimuláció indítása előtt töltsön be adatokat!");

            int bestYear = 0;
            int bestStatus = city.Status;

            for (int i = 0; i < yearlyData.Count; i++)
            {
                city.ResetRevenue();
                var tourists = yearlyData[i];

                city.ExpectedTourists(tourists);

                // Javítás, ha a bevétel meghaladja a 20 milliárdot
                long excessRevenue = city.Revenue - 20_000_000_000L;
                if (excessRevenue > 0)
                {
                    int bonusPoints = (int)(excessRevenue / 50_000_000L);
                    city.Clean(bonusPoints);
                }

                city.UpdateState();

                // Eredmények kiírása a feladatnak megfelelően
                Console.WriteLine($"--- {i + 1}. Év ---");
                Console.WriteLine($"Város új állapota: {city.Status} pont (Kategória: {city.CurrentState.GetType().Name})");
                Console.WriteLine($"Éves bevétel: {city.Revenue:N0} Ft");
                Console.WriteLine("Turisták statisztikája (Várt -> Tényleges):");
                foreach (var t in tourists)
                {
                    Console.WriteLine($"- {t.GetType().Name}: {t.ExpectedCount} -> {t.ActualCount}");
                }
                Console.WriteLine();

                // Legjobb év rögzítése
                if (city.Status > bestStatus)
                {
                    bestStatus = city.Status;
                    bestYear = i + 1;
                }
            }

            Console.WriteLine($"\nEredmény: A legjobb állapot a(z) {bestYear}. évben volt, {bestStatus} ponttal.");
        }
    }
}