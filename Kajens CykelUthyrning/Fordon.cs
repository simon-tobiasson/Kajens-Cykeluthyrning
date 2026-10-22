namespace Kajens_CykelUthyrning
{
    public class Fordon
    {

        protected int CykelNummer { get; set; }
        protected string Typ { get; set; }
        protected int Timpris { get; set; }
        protected bool Uthyrd { get; set; }

        public Fordon(int cykelNummer, string typ, int timpris, bool uthyrd) // Konstruktorn för basklassen
        {
            CykelNummer = cykelNummer;
            Typ = typ;
            Timpris = timpris;
            Uthyrd = uthyrd;
        }

        public virtual bool KanHyrasUt() // Bas metoden för om ett fordon kan hyras ut. (Ändrar namnet från KanSäljas till KanHyrasUt.)
        {
            return !Uthyrd;
        }

        public virtual void VisaInfo() // Bas metoden för alla fordon infon.
        {
            string status = Uthyrd ? "uthyrd" : "ledig";
            Console.WriteLine($"Cykelnummer: {CykelNummer}, Namn: {Typ}, Timpris: {Timpris}, Status: {status}");
        }

        public int CykelNummerInt() // Metod så att andra klasser kan hämta "protected" CykelNummer i datatypen int. Används i Uthyrning - VäljFordon
        {
            return CykelNummer;
        }

        public bool CykelNummerBool(int cykelNummer) // Samma som metoden ovan falls med datatypen bool. Används också i Uthyrning - VäljFordon (Ändrar namnet så det är CykelNummerBool istället för att göra det enklare att förstå.)
        {
            return CykelNummer == cykelNummer;
        }
    }
}
