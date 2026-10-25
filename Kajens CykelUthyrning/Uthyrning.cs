using System.Linq;

namespace Kajens_CykelUthyrning
{
    public class Uthyrning
    {

        private List<Fordon> fordonUthyrningLista = new List<Fordon>();  // En lista som håller reda på de fordon som blir uthyrda

        private int AntalUthyrdaTimmar { get; set; }
        private int CykelNummerVal { get; set; }

        public Uthyrning(int antalUthyrdaTimmar, int cykelNummerVal)
        {
            AntalUthyrdaTimmar = antalUthyrdaTimmar;
            CykelNummerVal = cykelNummerVal;            
        }
        
        public void VäljFordon(List<Fordon> fordonLista, int cykelNummerVal, string kundNamn, int kundÅlder)   // Metod som låter användaren välja ett fordon från listan med att skriva in cykelnumret. Om fordonet kan säljas läggs det till i uthyrningslistan.
        {
            int minNummer = fordonLista.Min(f => f.GetCykelNummerInt()); // Hämtar det minsta cykelnumret från fordon listan.
            int maxNummer = fordonLista.Max(f => f.GetCykelNummerInt()); // Hämtar det högsta cykelnumret från samma lista.

            Console.WriteLine(); //Radbrytning

            Console.WriteLine("Cyklar att välja mellan: ");
            
            foreach (Fordon item in fordonLista) 
            {
                item.VisaInfo(kundÅlder);
            }

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"Kund: {kundNamn}");

            Console.Write("Ange cykelnummer: ");

            if (!int.TryParse(Console.ReadLine(), out cykelNummerVal)) // Jag fixade det. Nu fungerar det som jag ville! Förhoppningsvis. Har inte tid att felsöka mer idag (kl 21:07). (Och det som detta kodblocket gör är att kolla om svaret är ett heltal. Om det inte är det slår fel meddelandet in.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine($"Ogiltigt nummer. Välj ett nummer mellan numrerna i listan, {minNummer} och {maxNummer}.");

                Console.WriteLine(); //Radbrytning
                return;
            }
            
            Fordon? cykelNummer = fordonLista.FirstOrDefault(f => f.GetCykelNummerBool(cykelNummerVal)); // Tar och kollar igenom fordonListan om användarens val av cykelnummer finns med

            if(cykelNummer == null) // Om svaret inte finns med i listan räknas det som null och då kommer detta fel meddelandet istället.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine($"Fordon med cykelnummer {cykelNummerVal} finns inte i listan. Välj ett nummer mellan numrerna i listan, {minNummer} och {maxNummer}.");

                Console.WriteLine(); //Radbrytning
                return;
            }

            

            if(kundÅlder >= 15 && kundÅlder <= 17 && cykelNummer is Elcykel) // Villkoret skriver ut felmeddelandet och går tillbaka om användaren försöker hyra en elcykel även om kunden är 15-17 år.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine("En kund mellan 15-17 år kan inte hyra en elcykel.");

                Console.WriteLine(); //Radbrytning
                return;
            }  
            
            if (!cykelNummer.KanHyrasUt())
            {
                return;
            }

            if (KollaTimmar(cykelNummer) == false) // Anropar KollaTimmar metoden från längre ner i Uthyrning klassen.
            {            
                return;
            }      

            fordonUthyrningLista.Add(cykelNummer);
            cykelNummer.HyrUtFordon();
            Console.WriteLine($"Cykelnummer {cykelNummerVal} hyrs ut i {AntalUthyrdaTimmar} timmar.");

            Console.WriteLine(); //Radbrytning
            return;
            
        }

        public Fordon GetUthyrdFordon() // Metod som returnerar det fordom som är uthyrt.
        {
            if (fordonUthyrningLista.Count == 0) // Om listan är tom så kommer felmeddelandet att skrivas ut och metoden returnerar null.
            {
                Console.WriteLine("Det finns inga fordon som är uthyrda ännu.");
                return null;
            }

            Console.WriteLine("Fordon som är uthyrda:");
            
            foreach(var fordon in fordonUthyrningLista) // Skriver ut alla fordon som är uthyrda.
            {
                Console.WriteLine($"Cykelnummer: {fordon.GetCykelNummerInt()}, Typ: {fordon.GetTyp()}");
            }

            Console.Write("Välj ett cykelnummer som ska lämnas in: ");

            string input = Console.ReadLine(); // Tar emot användarens input som en string.

            if (int.TryParse(input, out int cykelNummerVal)) // Kollar om användaren skriver in ett heltal. Om det är ett heltal kommer koden att köras
            {
                Fordon? fordonAttLämna = fordonUthyrningLista.FirstOrDefault(f => f.GetCykelNummerBool(cykelNummerVal)); // Kollar om heltalet som användaren skrev in finns med i listan med uthyrda fordon.

                if(fordonAttLämna != null) // Om fordonet finns med i listan så tas det bort från listan, fordonet blir ledigt och returneras.
                {
                    fordonUthyrningLista.Remove(fordonAttLämna);                    
                    fordonAttLämna.LämnaInFordon();
                    return fordonAttLämna;
                }
                else
                {
                    Console.WriteLine($"Cykelnummer {cykelNummerVal} är inte en cykel som är uthyrd."); // Om fordonet inte finns med i listan kommer detta felmeddelande att skrivas ut och sen returnerar den null.
                    return null;
                }                
            }
            else // Om användaren inte skriver in ett heltal kommer denna koden köras.
            {
                Console.WriteLine("Du måste skriva ett cykelnummer."); 
                return null;
            }            
        }

        public int GetCykelNummerVal() // Metoden gör så att ndra klasser kan hämta "private" CykelNummerVal.
        {
            return CykelNummerVal;
        }

        public bool KollaTimmar(Fordon cykelNummerVal) // Metoden kollar hur många timmar cykeln ska hyras ut. 
        {

            if (cykelNummerVal is Elcykel elcykel && cykelNummerVal.ÄrUthyrd() == false) // Om cykeln är ledig och är en elcykel ska inte användaren kunna skriva fler timmar än vad batteri nivån är. 
            {
                Console.Write("Ange timmar: ");
                AntalUthyrdaTimmar = int.Parse(Console.ReadLine());

                if (AntalUthyrdaTimmar > elcykel.GetBatteriNivåInt() / 10) 
                {
                    Console.WriteLine("Kunden kan inte hyra elcykeln längre tid än dess batteri nivå.");
                    return false;
                }               
            }

            else if (cykelNummerVal is Cykel && cykelNummerVal.ÄrUthyrd() == false) // Om cykeln är ledig och är en vanlig cykel så tar den emot antal timmar.
            {
                Console.Write("Ange timmar: ");
                AntalUthyrdaTimmar = int.Parse(Console.ReadLine());
            }
            return true;            
        }      
        
        public int GetAntalUthyrdaTimmar() // Metod som returnerar det antal timmar som cykeln är uthyrd. Används i LämnaTillbaka.cs för att skriva ut kvittot.
        {
            return AntalUthyrdaTimmar;
        }
    }
}
