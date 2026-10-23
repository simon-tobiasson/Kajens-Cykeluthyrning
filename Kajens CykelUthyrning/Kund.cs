namespace Kajens_CykelUthyrning
{
    public class Kund
    {
        private string kundName { get; set; }
        private int kundÅlder { get; set; }
        private bool ärMedlem { get; set; }

        public Kund(string KundName, int KundÅlder, bool ÄrMedlem)
        {
            kundName = KundName;
            kundÅlder = KundÅlder;
            ärMedlem = ÄrMedlem;
        }

        public void RegistreraKund() //Flyttade kod blocket från val 2 hit till Kund.cs. Metoden anropas i val 2.
        {
            Console.Write("Ange kundens namn: ");
            kundName = Console.ReadLine();

            Console.Write("Ange kundens ålder: ");
            kundÅlder = int.Parse(Console.ReadLine());

            KundÅlderVillkor();

            Console.Write("Är kunden medlem? (ja/nej): ");
            ärMedlem = Console.ReadLine().ToLower() == "ja";           

        }

        public void KundÅlderVillkor() // Kollar hur gammal kunden är. 
        {
            if (kundÅlder < 15)
            {
                Console.WriteLine("Kunden får inte hyra en cykel eftersom hen är under 15 år. Programmet avslutas."); // Om kunden är 15 år anges ett fel meddelande och sen stängs programmet ner med en gång.
                Environment.Exit(0);
            }

            else if (kundÅlder >= 15 && kundÅlder <= 17)
            {
                Console.WriteLine("Kunden är mellan 15 och 17 år. Hen får hyra en cykel men inte en elcykel."); // Om kunden är mellan 15 - 17 år då går den andra in.
            }

            else
            {
                return;
            }
        }

        public int GetKundÅlderInt()
        {
            return kundÅlder;
        }

        
        public void VisaKundInfo() // Visar kund info, inte mer än det. 
        {
            string statusMedlem = ärMedlem ? "ja" : "nej"; // Om ärMedlem är true skriver "ja" ut, om den är false skriver den ut "nej". 

            Console.WriteLine($"Kundnamn: {kundName}");
            Console.WriteLine($"Kundålder: {kundÅlder}");
            Console.WriteLine($"Är medlem: {statusMedlem}");
        }


    }
}
