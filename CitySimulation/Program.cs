using CitySimulation.Core;

namespace CitySimulation;
class Program
{
    /// <summary>
    /// A főprogram, amely bekér egy fájlnevet, megjeleníti a tartalmát, elindítja a szimulációt.
    /// </summary>
    /// <param name="args">Parancssori argumentumok (nem használt).</param>
    static void Main(string[] args)
    {
        Console.WriteLine("Város Szimuláció - Turizmus");
        Console.WriteLine("===========================\n");

        Console.Write("Kérem, adja meg a bemeneti fájl nevét (pl. adat.txt): ");
        string? filename = Console.ReadLine();

        // Ellenőrizzük, hogy nem üres-e a bemenet
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Hibás adat: A fájlnév nem lehet üres.");
            return;
        }

        try
        {
            //Fájl tartalmának megjelenítése
            Console.WriteLine("\n--- A fájl tartalma ---");
            string fileContent = File.ReadAllText(filename);
            Console.WriteLine(fileContent);
            Console.WriteLine("-----------------------\n");

            //Szimuláció példányosítása és indítása
            Simulation simulation = new Simulation();

            Console.WriteLine("Szimuláció inicializálása...");
            simulation.LoadFromFile(filename);

            Console.WriteLine("Szimuláció futtatása...\n");
            simulation.RunSimulation();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"\nHiba: A megadott fájl ('{filename}') nem található!");
        }
        catch (Exception ex)
        {
            // Minden egyéb váratlan hiba elkapása
            Console.WriteLine($"\nVáratlan hiba történt a futás során:\n{ex.Message}");
        }

        Console.WriteLine("\nNyomjon meg egy gombot a kilépéshez...");
        Console.ReadKey();
    }
}