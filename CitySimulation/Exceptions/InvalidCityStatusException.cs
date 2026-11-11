namespace CitySimulation.Exceptions
{
    /// <summary>
    /// Kivétel, ha a város pontszáma nem megengedett (1-100-on kívülre) kerül.
    /// </summary>
    public class InvalidCityStatusException : Exception
    {
        /// <summary>
        /// Létrehoz egy új InvalidCityStatusExceptiont.
        /// </summary>
        /// <param name="message">A hiba leírása.</param>
        public InvalidCityStatusException(string message) : base(message) { }
    }
}