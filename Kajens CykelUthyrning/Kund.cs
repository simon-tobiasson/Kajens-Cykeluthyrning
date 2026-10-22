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

        public void VisaKundInfo()
        {
            string statusMedlem = ärMedlem ? "nej" : "ja";

            Console.WriteLine($"Kundnamn: {kundName}");
            Console.WriteLine($"Kundålder: {kundÅlder}");
            Console.WriteLine($"Är medlem: {statusMedlem}");
        }
    }
}
