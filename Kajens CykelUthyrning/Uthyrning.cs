using System.Linq;

namespace Kajens_CykelUthyrning
{
    public class Uthyrning
    {

        private List<Fordon> fordonUthyrningLista = new List<Fordon>();  // En lista som håller reda på de fordon som blir uthyrda

        private int AntalUthyrdaTimmar { get; set; }

        public Uthyrning(int antalUthyrdaTimmar)
        {
            AntalUthyrdaTimmar = antalUthyrdaTimmar;
        }
        
        public void VäljFordon(List<Fordon> fordonLista, int kundÅlder)   // Metod som låter användaren välja ett fordon från listan med att skriva in cykelnumret. Om fordonet kan säljas läggs det till i uthyrningslistan.
        {
            int minNummer = fordonLista.Min(f => f.GetCykelNummerInt()); // Hämtar det minsta cykelnumret från fordon listan.
            int maxNummer = fordonLista.Max(f => f.GetCykelNummerInt()); // Hämtar det högsta cykelnumret från samma lista.

            Console.WriteLine("Cyklar att välja mellan: ");
            
            foreach (Fordon item in fordonLista) 
            {
                item.VisaInfo(kundÅlder);
            }

            Console.Write("Ange cykelnummer: ");            
            

            if (!int.TryParse(Console.ReadLine(), out int cykelNummerVal)) // Jag fixade det. Nu fungerar det som jag ville! Förhoppningsvis. Har inte tid att felsöka mer idag (kl 21:07). (Och det som detta kodblocket gör är att kolla om svaret är ett heltal. Om det inte är det slår fel meddelandet in.
            {
                Console.WriteLine($"Ogiltigt nummer. Välj ett nummer mellan numrerna i listan, {minNummer} och {maxNummer}.");
                return;
            }
            
            Fordon? cykelNummer = fordonLista.FirstOrDefault(f => f.GetCykelNummerBool(cykelNummerVal)); // Tar och kollar igenom fordonListan om användarens val av cykelnummer finns med

            if(cykelNummer == null) // Om svaret inte finns med i listan räknas det som null och då kommer detta fel meddelandet istället.
            {
                Console.WriteLine($"Fordon med cykelnummer {cykelNummerVal} finns inte i listan. Välj ett nummer mellan numrerna i listan, {minNummer} och {maxNummer}.");
                return;
            }


            if(kundÅlder >= 15 && kundÅlder <= 17 && cykelNummer is Elcykel) // Villkoret skriver ut felmeddelandet och går tillbaka om användaren försöker hyra en elcykel även om kunden är 15-17 år.
            {
                Console.WriteLine("En kund mellan 15-17 år kan inte hyra en elcykel.");
                return;
            }  
            
            
            if (KollaTimmar(cykelNummer) == false) // Anropar KollaTimmar metoden från längre ner i Uthyrning klassen.
            {            
                return;
            }
   

            if (cykelNummer.KanHyrasUt()) // Anropar metoden från bas klassen Fordon och borde lägga till valet i uthyrnings listan om villkoren möts. Jag har inte testat varje svar ännu så kan inte säga exakt.
            {                
                fordonUthyrningLista.Add(cykelNummer);             
                return;
            }      
                        
            return;
        }

        public bool KollaTimmar(Fordon cykelNummerVal) // Metoden kollar hur många timmar cykeln ska hyras ut. 
        {

            if (cykelNummerVal is Elcykel elcykel && cykelNummerVal.ÄrUthyrd() == false) // Om cykeln är ledig och är en elcykel ska inte användaren kunna skriva fler timmar än vad batteri nivån är. 
            {
                Console.Write("Ange timmar: ");
                int antalUthyrdaTimmar = int.Parse(Console.ReadLine());

                if (antalUthyrdaTimmar > elcykel.GetBatteriNivåInt() / 10) 
                {
                    Console.WriteLine("Kunden kan inte hyra elcykeln längre tid än dess batteri nivå.");
                    return false;
                }               
            }

            else if (cykelNummerVal is Cykel && cykelNummerVal.ÄrUthyrd() == false) // Om cykeln är ledig och är en vanlig cykel så tar den emot antal timmar.
            {
                Console.Write("Ange timmar: ");
                int antalUthyrdaTimmar = int.Parse(Console.ReadLine());
            }
            return true;            
        }
    }
}
