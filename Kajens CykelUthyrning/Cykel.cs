namespace Kajens_CykelUthyrning
{
    public class Cykel : Fordon // Andra subklassen med basklassen Fordon.
    {
        public Cykel(int bicycleNumber, string type, int hourlyPrice, bool rented) : base(bicycleNumber, type, hourlyPrice, rented)
        {
        }

        public override bool CanBeRented() // Polymorferar något med att lägga till utskrift. 
        {
            if (!Rented)
            {
                Console.WriteLine($"Cykelnummer {BicycleNumber} kan hyras ut.");
                return !Rented;
            }

            else
            {
                Console.WriteLine($"Cykelnummer {BicycleNumber} kan inte hyras ut eftersom den är uthyrd.");
                return false;
            }
        }        
    }
}
