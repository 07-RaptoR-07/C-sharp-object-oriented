using CitySimulation.Exceptions;
using CitySimulation.States;

namespace CitySimulation.Models
{
    /// <summary>
    /// A város osztály, amely kezeli a pontszámot, bevételt és a turistákat.
    /// </summary>
    public class City
    {
        private int status;
        private long revenue;
        private CityState currentState;

        /// <summary>A város állapota pontban kifejezve (1-100).</summary>
        public int Status => status;

        /// <summary>A város éves bevétele.</summary>
        public long Revenue => revenue;

        /// <summary>A város aktuális állapot objektuma.</summary>
        public CityState CurrentState => currentState;

        /// <summary>
        /// Létrehoz egy új várost a megadott kezdeti állapottal.
        /// </summary>
        /// <param name="initialCondition">Kezdeti pontszám.</param>
        /// <exception cref="InvalidCityStatusException">Ha a pontszám 1 alatt vagy 100 felett van.</exception>
        public City(int initialCondition)
        {
            if (initialCondition < 1 || initialCondition > 100)
                throw new InvalidCityStatusException("A város állapota 1 és 100 között kell legyen.");

            status = initialCondition;
            revenue = 0;
            currentState = null!;
            UpdateState();
        }

        /// <summary>Frissíti az objektum belső állapotát (CityState) a pontszám alapján.</summary>
        public void UpdateState()
        {
            if (status <= 33) currentState = new TooDirtyState();
            else if (status <= 67) currentState = new AverageState();
            else currentState = new PerfectState();
        }

        /// <summary>
        /// Fogadja és feldolgozza az adott év turistáit.
        /// </summary>
        /// <param name="tourists">A turistacsoportok listája.</param>
        /// <exception cref="ArgumentNullException">Ha a lista null.</exception>
        public void ExpectedTourists(List<Tourists.Tourists> tourists)
        {
            if (tourists == null) throw new ArgumentNullException(nameof(tourists));

            foreach (var t in tourists)
            {
                currentState.CalculateActual(t);
                Accept(t);
            }
        }

        /// <summary>Elfogad egy látogató turistát (Visitor DP).</summary>
        /// <param name="t">A turista objektum.</param>
        public void Accept(Tourists.Tourists t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            t.Visit(this);
        }

        /// <summary>Javítja a város állapotát a megadott pontszámmal, maximum 100-ig.</summary>
        /// <param name="amount">A javulás mértéke.</param>
        public void Clean(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "A javítás mértéke nem lehet negatív.");
            status = Math.Min(100, status + amount);
        }

        /// <summary>Rontja a város állapotát a megadott pontszámmal, minimum 1-ig.</summary>
        /// <param name="amount">A romlás mértéke.</param>
        public void Litter(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "A szemetelés mértéke nem lehet negatív.");
            status = Math.Max(1, status - amount);
        }

        /// <summary>Növeli a bevételt a tényleges turisták száma alapján (100 000  / fő).</summary>
        /// <param name="count">Tényleges létszám.</param>
        public void Spend100k(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "A létszám nem lehet negatív.");
            revenue += (long)count * 100_000;
        }

        /// <summary>Lenullázza a város éves bevételt az új év kezdete előtt.</summary>
        public void ResetRevenue()
        {
            revenue = 0;
        }
    }
}