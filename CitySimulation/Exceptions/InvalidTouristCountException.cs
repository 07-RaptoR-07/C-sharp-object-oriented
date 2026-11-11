namespace CitySimulation.Exceptions
{
    /// <summary>
    /// Kivétel, ha a turisták száma nem lehetséges (pl negatív).
    /// </summary>
    public class InvalidTouristCountException : Exception
    {
        /// <summary>
        /// Létrehoz egy új InvalidTouristCountExceptiont
        /// </summary>
        /// <param name="message">A hiba leírása.</param>
        public InvalidTouristCountException(string message) : base(message) { }
    }
}