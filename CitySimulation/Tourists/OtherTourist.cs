using CitySimulation.Models;

namespace CitySimulation.Tourists
{
    /// <summary>
    /// Az egyéb turisták viselkedését megvalósító osztály. 50 főnként rontanak 1 pontot.
    /// </summary>
    public class OtherTourist : Tourists
    {
        /// <summary>Konstruktor az egyéb turistacsoport létrehozásához.</summary>
        public OtherTourist(int expected) : base(expected) { }

        public override void Visit(City c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            c.Spend100k(actualCount);
            c.Litter(actualCount / 50);
        }

        public override void CityTooDirtyToVisit() => actualCount = expectedCount;

        public override void CityAverageToVisit() => actualCount = (int)(expectedCount * 1.1); // +10%

        public override void CityPerfectToVisit() => actualCount = expectedCount;
    }
}