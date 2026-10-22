namespace Kajens_CykelUthyrning
{
    public class Cykel : Fordon // Andra subklassen med basklassen Fordon.
    {
        public Cykel(int cykelNummer, string typ, int timpris, bool uthyrd) : base(cykelNummer, typ, timpris, uthyrd) // Har inte dubbelkollat om en konstruktor behövs här då den inte ändrar någonting, men det gör det enklare för ögat att se att den finns. Kollar det imorgon!
        {
        }

        public override bool KanHyrasUt() // Polymorferar något med att lägga till utskrift. 
        {
            if (!Uthyrd)
            {
                Console.WriteLine($"{Typ} {CykelNummer} hyrs ut.");
                return !Uthyrd;
            }

            else
            {
                Console.WriteLine($"{Typ} {CykelNummer} kan inte hyras ut eftersom den är uthyrd.");
                return true;
            }
        }        
    }
}
