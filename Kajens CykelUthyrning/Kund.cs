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

        public void VisaKundInfo() // Visar kund info, inte mer än det. 
        {
            string statusMedlem = ärMedlem ? "ja" : "nej"; // Om ärMedlem är true skriver "ja" ut, om den är false skriver den ut "nej". 

            Console.WriteLine($"Kundnamn: {kundName}");
            Console.WriteLine($"Kundålder: {kundÅlder}");
            Console.WriteLine($"Är medlem: {statusMedlem}");
        }
    }
}
