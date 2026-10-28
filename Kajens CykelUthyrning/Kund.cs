namespace Kajens_CykelUthyrning
{
    public class Kund
    {
        private string CustomerName { get; set; }
        private int CustomerAge { get; set; }
        private bool IsMember { get; set; }

        public Kund(string customerName, int customerAge, bool isMember)
        {
            CustomerName = customerName;
            CustomerAge = customerAge;
            IsMember = isMember;
        }

        public void RegisterCustomer() //Flyttade kod blocket från val 2 hit till Kund.cs. Metoden anropas i val 2.
        {
            Console.WriteLine(); //Radbrytning

            if(!ReadCustomerName())
            {
                return; // Avslutar RegisterCustomer-metoden / Returnerar tillbaka till menyn om namnet inte är korrekt inmatat
            }

            if (!ReadCustomerAge())
            {
                return; // Avslutar RegisterCustomer-metoden / Returnerar tillbaka till menyn om åldern inte är korrekt inmatad
            }
            
            CustomerAgeTerms(); // Anropar metoden nedanför.

            if(!ReadCustomerMembership())
            {
                return; // Avslutar RegisterCustomer-metoden / Returnerar tillbaka till menyn om medlemskapet inte är korrekt inmatat
            }

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"Kunden {CustomerName} är registrerad.");
            ShowCustomerInfo(); // Anropar metoden nedanför.

            Console.WriteLine(); //Radbrytning

             
        }

        private bool ReadCustomerName()
        {
            Console.Write("Ange kundens namn: ");
            CustomerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(CustomerName))
            {
                Console.WriteLine("Kan inte lämna fältet tomt. Du måste skriva någonting.");
                return false;
            }
            return true;
        }

        private bool ReadCustomerAge() // Kollar om användaren matar in rätt datatyp för age, om inte så skrivs ett fel meddelande ut.
        {
            Console.Write("Ange kundens ålder: ");
            string input = Console.ReadLine();
                        
            if (int.TryParse(input, out int age))
            {
                CustomerAge = age;
                return true;
            }
            else
            {
                Console.WriteLine("Du måste skriva ett heltal för ålder.");
                return false;
            }
        }

        private void CustomerAgeTerms() // Kollar hur gammal kunden är. 
        {
            if (CustomerAge < 15)
            {
                Console.WriteLine("Kunden får inte hyra en cykel eftersom hen är under 15 år. Programmet avslutas."); // Om kunden är 15 år anges ett fel meddelande och sen stängs programmet ner med en gång.
                Environment.Exit(0);
            }

            else if (CustomerAge >= 15 && CustomerAge <= 17)
            {
                Console.WriteLine("Kunden är mellan 15 och 17 år. Hen får hyra en cykel men inte en elcykel."); // Om kunden är mellan 15 - 17 år då går den andra in.
            }

            else
            {
                return;
            }
        }

        private bool ReadCustomerMembership() // Kollar om användaren har matat in rätt information för medlemskap.
        {
            Console.Write("Är kunden medlem? (ja/nej): ");

            string input = Console.ReadLine().ToLower();

            if (input == "ja")
            {
                IsMember = true;
                return true;
            }
            else if (input == "nej")
            {
                IsMember = false;
                return true;
            }
            else
            {
                Console.WriteLine("Ogiltigt svar. Måste skriva 'ja' eller 'nej'.");
                return false;
            }
        }

        private void ShowCustomerInfo() // Visar kund info, inte mer än det. 
        {
            string statusMember = IsMember ? "ja" : "nej"; // Om IsMember är true skriver "ja" ut, om den är false skriver den ut "nej". 

            Console.WriteLine($"Kundnamn: {CustomerName}");
            Console.WriteLine($"Kundålder: {CustomerAge}");
            Console.WriteLine($"Är medlem: {statusMember}");
        }

        public string GetCustomerName()
        {
            return CustomerName;
        }

        public int GetCustomerAgeInt()
        {
            return CustomerAge;
        }

        public bool GetIsMember()
        {
            return IsMember;
        }  
    }
}
