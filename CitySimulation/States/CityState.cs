using CitySimulation.Tourists;

namespace CitySimulation.States
{
    /// <summary>
    /// A város lehetséges állapotainak absztrakt ősosztálya (State minta).
    /// </summary>
    public abstract class CityState
    {
        /// <summary>
        /// Kiszámítja a turisták tényleges számát az aktuális állapot alapján, 
        /// </summary>
        /// <param name="t">A vizsgált turistacsoport.</param>
        public abstract void CalculateActual(Tourists.Tourists t);
    }
}