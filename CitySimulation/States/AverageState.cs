using CitySimulation.Tourists;

namespace CitySimulation.States
{
    /// <summary>
    /// A város átlagos (34-67 pont) állapotát reprezentáló osztály.
    /// </summary>
    public class AverageState : CityState
    {
        /// <summary>
        /// Turíták aktuális számának megszámlálása
        /// </summary>
        /// <param name="t">A vizsgált turistacsoport.</param>
        /// <exception cref="ArgumentNullException">Ha a turista objektum null.</exception>
        public override void CalculateActual(Tourists.Tourists t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            t.CityAverageToVisit();
        }
    }
}