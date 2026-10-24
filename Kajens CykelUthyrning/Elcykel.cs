using System.Linq;

namespace Kajens_CykelUthyrning
{
    public class Elcykel : Fordon // Subklass
    {
        private int BatteriNivå { get; set; } // Utökar klassen med BatteriNivå då den andra subklassen inte har det. 

        public Elcykel(int cykelNummer, string typ, int timpris, bool uthyrd, int batteriNivå) : base(cykelNummer, typ, timpris, uthyrd) 
        {
            BatteriNivå = batteriNivå;
        }

        public override bool KanHyrasUt() // Polymorferar metoden från basklassen till att ge felmeddelande till olika situationer.
        {
            

            if (!Uthyrd && BatteriNivå > 30)
            {
                Console.WriteLine($"{Typ} {CykelNummer} hyrs ut.");
                return !Uthyrd;
            }
            else if (Uthyrd)
            {
                Console.WriteLine($"{Typ} {CykelNummer} kan inte hyras ut eftersom den är uthyrd.");
                return false;
            }
            else
            {
                Console.WriteLine($"{Typ} {CykelNummer} kan inte hyras ut eftersom batterinivån är för låg ({BatteriNivå}%). Ladda batteriet först.");
                return false;
            }
        }

        public override void VisaInfo(int kundÅlder) // Polymorferar metoden från basklassen, skriver ut ett meddelande när kunden är mellan 15-17 år och allt runt omkring visar den elcykel informationen.
        {   
            if(kundÅlder >= 15 && kundÅlder <= 17)
            {

                Console.WriteLine($"Cykelnummer: {CykelNummer}, Typ: {Typ} - Kom ihåg, kunder mellan 15-17 år kan inte hyra en elcykel");
            }
            else 
            {
                string status = Uthyrd ? "uthyrd" : "ledig";
                Console.WriteLine($"Cykelnummer: {CykelNummer}, Typ: {Typ}, Timpris: {Timpris}, Status: {status}, Batterinivå: {BatteriNivå}%");
            }                       
        }


        public static void LaddaElcykelBatteri(List<Fordon> fordonLista)
        {
            int minNummer = fordonLista.Min(f => f.GetCykelNummerInt());
            int maxNummer = fordonLista.Max(f => f.GetCykelNummerInt());
            Console.Write("Ange cykelnummer på elcykeln som ska laddas: ");

            if(int.TryParse(Console.ReadLine(), out int cykelNummerVal))
            {
                Fordon? fordon = fordonLista.FirstOrDefault(f => f.GetCykelNummerBool(cykelNummerVal));

                if(fordon is Elcykel elcykel)
                {
                    elcykel.LaddaBatteri();
                    return;
                }
                else if(fordon == null)
                {
                    Console.WriteLine($"{cykelNummerVal} finns inte med i listan. Välj mellan {minNummer} och {maxNummer}.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Cykelnummer: {cykelNummerVal} är inte elcykel. Välj en elcykel.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Du måste skriva ett nummer.");
            }
        }
        public void LaddaBatteri() // Metoden används inte än, kommer används den senare i alternativ 5 (ladda).
        {
            
            
            if (BatteriNivå < 100)
            {
                BatteriNivå = 100;
                Console.WriteLine("Batteriet har laddats och är nu fulladdad."); ;
            }
            else 
            { 
                Console.WriteLine($"Batteriet är redan fulladdat"); 
            }
        }

        public int GetBatteriNivåInt() // Gör det möjligt för andra klasser att läsa in den privata egenskapen. Förtillfället läses den bara in i Uthyrning - KollaTimmar.
        {
            return BatteriNivå;
        }
    }
}
