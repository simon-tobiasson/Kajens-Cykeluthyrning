namespace Kajens_CykelUthyrning
{
    public class Kund
    {
        private string kundNamn { get; set; }
        private int kundÅlder { get; set; }
        private bool ärMedlem { get; set; }

        public Kund(string KundNamn, int KundÅlder, bool ÄrMedlem)
        {
            kundNamn = KundNamn;
            kundÅlder = KundÅlder;
            ärMedlem = ÄrMedlem;
        }

        public void RegistreraKund() //Flyttade kod blocket från val 2 hit till Kund.cs. Metoden anropas i val 2.
        {
            if(!LäsInNamn())
            {
                return; // Avslutar RegistreraKund-metoden / Returnerar tillbaka till menyn om namnet inte är korrekt inmatat
            }

            if (!LäsInÅlder())
            {
                return; // Avslutar RegistreraKund-metoden / Returnerar tillbaka till menyn om åldern inte är korrekt inmatad
            }
            
            KundÅlderVillkor(); // Anropar metoden nedanför.

            if(!LäsInMedlemskap())
            {
                return; // Avslutar RegistreraKund-metoden / Returnerar tillbaka till menyn om medlemskapet inte är korrekt inmatat
            }
            
            VisaKundInfo(); // Anropar metoden nedanför.

        }

        private bool LäsInNamn()
        {
            Console.Write("Ange kundens namn: ");
            kundNamn = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(kundNamn))
            {
                Console.WriteLine("Kan inte lämna fältet tomt. Du måste skriva någonting.");
                return false;
            }
            return true;
        }

        private bool LäsInÅlder() // Kollar om användaren matar in rätt datatyp för ålder, om inte så skrivs ett fel meddelande ut.
        {
            Console.Write("Ange kundens ålder: ");
            string input = Console.ReadLine();
                        
            if (int.TryParse(input, out int ålder))
            {
                kundÅlder = ålder;
                return true;
            }
            else
            {
                Console.WriteLine("Du måste skriva ett heltal för ålder.");
                return false;
            }
        }

        private void KundÅlderVillkor() // Kollar hur gammal kunden är. 
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

        private bool LäsInMedlemskap() // Kollar om användaren har matat in rätt information för medlemskap.
        {
            Console.Write("Är kunden medlem? (ja/nej): ");

            string input = Console.ReadLine().ToLower();

            if (input == "ja")
            {
                ärMedlem = true;
                return true;
            }
            else if (input == "nej")
            {
                ärMedlem = false;
                return true;
            }
            else
            {
                Console.WriteLine("Ogiltigt svar. Måste skriva 'ja' eller 'nej'.");
                return false;
            }
        }

        private void VisaKundInfo() // Visar kund info, inte mer än det. 
        {
            string statusMedlem = ärMedlem ? "ja" : "nej"; // Om ärMedlem är true skriver "ja" ut, om den är false skriver den ut "nej". 

            Console.WriteLine($"Kundnamn: {kundNamn}");
            Console.WriteLine($"Kundålder: {kundÅlder}");
            Console.WriteLine($"Är medlem: {statusMedlem}");
        }

        public string GetKundNamn()
        {
            return kundNamn;
        }

        public int GetKundÅlderInt()
        {
            return kundÅlder;
        }

        public bool GetÄrMedlem()
        {
            return ärMedlem;
        }  
    }
}
