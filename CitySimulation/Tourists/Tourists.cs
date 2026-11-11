using CitySimulation.Exceptions;
using CitySimulation.Models;

namespace CitySimulation.Tourists
{
    /// <summary>
    /// A turistacsoportokat reprezentáló absztrakt ősosztály (Visitor minta).
    /// </summary>
    public abstract class Tourists
    {
        /// <summary>Az eredetileg várt turisták száma.</summary>
        protected int expectedCount;

        /// <summary>A ténylegesen megérkező turisták száma az állapot függvényében.</summary>
        protected int actualCount;

        /// <summary>Lekérdezi a várt turisták számát.</summary>
        public int ExpectedCount => expectedCount;

        /// <summary>Lekérdezi a ténylegesen érkező turisták számát.</summary>
        public int ActualCount => actualCount;

        /// <summary>
        /// új turistacsoportot a megadott várt létszámmal.
        /// </summary>
        /// <param name="expected">A várt turisták száma.</param>
        /// <exception cref="InvalidTouristCountException">Ha a létszám negatív.</exception>
        public Tourists(int expected)
        {
            if (expected < 0) throw new InvalidTouristCountException("A várt turisták száma nem lehet negatív.");
            expectedCount = expected;
        }

        /// <summary>A turista meglátogatja a várost, költ és szemetel.</summary>
        /// <param name="c">A meglátogatott város.</param>
        public abstract void Visit(City c);

        /// <summary>Kiszámolja a tényleges létszámarányt, ha a város lepusztult.</summary>
        public abstract void CityTooDirtyToVisit();

        /// <summary>Kiszámolja a tényleges létszámarányt, ha a város átlagos.</summary>
        public abstract void CityAverageToVisit();

        /// <summary>Kiszámolja a tényleges létszámarányt, ha a város jó állapotú.</summary>
        public abstract void CityPerfectToVisit();
    }
}