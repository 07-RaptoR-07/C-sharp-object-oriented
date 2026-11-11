using CitySimulation.Tourists;

namespace CitySimulation.States
{
    /// <summary>
    /// A város lepusztult (1-33 pont) állapotát reprezentáló osztály.
    /// </summary>
    public class TooDirtyState : CityState
    {
        /// <summary>
        /// Turíták aktuális számának megszámlálása (rossz állapot esetén).
        /// </summary>
        /// <param name="t">A vizsgált turistacsoport.</param>
        /// <exception cref="ArgumentNullException">Ha a turista objektum null.</exception>
        public override void CalculateActual(Tourists.Tourists t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            t.CityTooDirtyToVisit();
        }
    }
}