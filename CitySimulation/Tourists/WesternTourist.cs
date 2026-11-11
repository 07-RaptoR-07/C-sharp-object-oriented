using CitySimulation.Models;

namespace CitySimulation.Tourists
{
    /// <summary>
    /// A nyugati turisták viselkedését megvalósító osztály. 100 főnként rontanak 1 pontot.
    /// </summary>
    public class WesternTourist : Tourists
    {
        /// <summary>Konstruktor a nyugati turistacsoport létrehozásához.</summary>
        public WesternTourist(int expected) : base(expected) { }

        public override void Visit(City c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            c.Spend100k(actualCount);
            c.Litter(actualCount / 100);
        }

        public override void CityTooDirtyToVisit() => actualCount = expectedCount;

        public override void CityAverageToVisit() => actualCount = (int)(expectedCount * 1.1); // +10%

        public override void CityPerfectToVisit() => actualCount = (int)(expectedCount * 1.3); // +30%
    }
}