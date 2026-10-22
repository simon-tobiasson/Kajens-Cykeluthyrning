using System.Linq;

namespace Kajens_CykelUthyrning
{
    public class Uthyrning
    {

        private List<Fordon> fordonUthyrningLista = new List<Fordon>();  // En lista som håller reda på de fordon som blir uthyrda

        private int antalUthyrdaTimmar { get; set; }

        
        
        public void VäljFordon(List<Fordon> fordonLista)   // Metod som låter användaren välja ett fordon från listan med att skriva in cykelnumret. Om fordonet kan säljas läggs det till i uthyrningslistan.
        {
            int minNummer = fordonLista.Min(f => f.CykelNummerInt()); // Hämtar det minsta cykelnumret från fordon listan.
            int maxNummer = fordonLista.Max(f => f.CykelNummerInt()); // Hämtar det högsta cykelnumret från samma lista.

            Console.Write("Ange cykelnummer: ");            
            

            if (!int.TryParse(Console.ReadLine(), out int cykelNummerVal)) // Jag fixade det. Nu fungerar det som jag ville! Förhoppningsvis. Har inte tid att felsöka mer idag (kl 21:07). (Och det som detta kodblocket gör är att kolla om svaret är ett heltal. Om det inte är det slår fel meddelandet in.
            {
                Console.WriteLine($"Ogiltigt nummer. Välj ett nummer mellan numrerna i listan, {minNummer} och {maxNummer}.");
                return;
            }
            
            Fordon? fordon = fordonLista.FirstOrDefault(f => f.CykelNummerBool(cykelNummerVal)); // Tar och kollar igenom fordonListan om användarens val av cykelnummer finns med

            if(fordon == null) // Om svaret inte finns med i listan räknas det som null och då kommer detta fel meddelandet istället.
            {
                Console.WriteLine($"Fordon med cykelnummer {cykelNummerVal} finns inte i listan. Välj ett nummer mellan numrerna i listan, {minNummer} och {maxNummer}.");
                return;
            }            

            if(KollaTimmar(fordonLista) == false) // Anropar KollaTimmar metoden från längre ner i Uthyrning klassen.
            {
                return;
            }
            

            if (fordon.KanHyrasUt()) // Anropar metoden från bas klassen Fordon och borde lägga till valet i uthyrnings listan om villkoren möts. Jag har inte testat varje svar ännu så kan inte säga exakt.
            {
                fordonUthyrningLista.Add(fordon);
                return;
            }
            return;

        }

        public bool KollaTimmar(List<Fordon> fordonLista) // Metod för att kolla timmar och ger ett fel meddelande om svaret på hur många timmar kunden ska hyra ut en cykel överskrider elcykelarnas batterikapacitet.
        {
            Console.Write("Ange timmar: ");
            int antalUthyrdaTimmar = int.Parse(Console.ReadLine());

            var elcykel = fordonLista.OfType<Elcykel>().FirstOrDefault(); // Denna kodlinjen kommer jag att ändra på imorgon. Just nu kollar den FirstOrDefault, det vill jag inte, jag vill att den ska kolla vilket cykelNummer som personalen/användaren har valt, och om det numret matchar ska resten av koden köras.

            if (antalUthyrdaTimmar > elcykel.GetBatteriNivå() / 10) // Kollar hur många timmar kunden vill hyra ut en cykel och om hen vill hyra ut elcykeln längre tid än dess batterinivå, då skickas felmeddelandet.
            {
                Console.WriteLine("Kunden kan inte hyra elcykeln längre tid än dess batteri nivå.");
                return false;
            }
            return true;
        }
    }
}
