using CitySimulation.Models;

namespace CitySimulation.Tourists
{
    /// <summary>
    /// A japán turistákat megvalósító osztály. Nem szemetelnek.
    /// </summary>
    public class JapaneseTourist : Tourists
    {
        /// <summary>Konstruktor a japán turistacsoport létrehozásához.</summary>
        public JapaneseTourist(int expected) : base(expected) { }

        public override void Visit(City c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            c.Spend100k(actualCount);
            c.Litter(0);
        }

        public override void CityTooDirtyToVisit() => actualCount = 0; // Nem jönnek lepusztultba

        public override void CityAverageToVisit() => actualCount = expectedCount; // Nincs változás

        public override void CityPerfectToVisit() => actualCount = (int)(expectedCount * 1.2); // +20%
    }
}