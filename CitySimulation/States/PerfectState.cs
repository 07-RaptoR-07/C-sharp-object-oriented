using CitySimulation.Tourists;

namespace CitySimulation.States
{
    /// <summary>
    /// A város jó (68-100 pont) állapotát reprezentáló osztály.
    /// </summary>
    public class PerfectState : CityState
    {
        /// <summary>
        /// Turíták aktuális számának megszámlálása (jó állapot esetén).
        /// </summary>
        /// <param name="t">A vizsgált turistacsoport.</param>
        /// <exception cref="ArgumentNullException">Ha a turista objektum null.</exception>
        public override void CalculateActual(Tourists.Tourists t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            t.CityPerfectToVisit();
        }
    }
}