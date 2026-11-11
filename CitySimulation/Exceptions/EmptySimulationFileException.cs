namespace CitySimulation.Exceptions
{
    /// <summary>
    /// Kivétel, ha a beolvasott szimulációs bemeneti fájl üres.
    /// </summary>
    public class EmptySimulationFileException : Exception
    {
        /// <summary>
        /// Létrehoz egy új EmptySimulationFileExceptiont.
        /// </summary>
        /// <param name="message">A hiba leírása.</param>
        public EmptySimulationFileException(string message) : base(message) { }
    }
}