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

        public virtual void VisaInfo(int kundÅlder) // Bas metoden för alla fordon infon. La till int kundÅlder i parametern så funktion kan läsa den informationen.
        {
            string status = Uthyrd ? "uthyrd" : "ledig";
            Console.WriteLine($"Cykelnummer: {CykelNummer}, Typ: {Typ}, Timpris: {Timpris}, Status: {status}");            
        }

        public void HyrUtFordon() // Metod så att andra klasser kan ändra "protected" Uthyrd till true.
        {
            Uthyrd = true;
        }

        public void LämnaInFordon() // Metod så att andra klasser kan ändra "protected" Uthyrd till false.
        {
            Uthyrd = false;
        }

        public int GetCykelNummerInt() // Metod så att andra klasser kan hämta "protected" CykelNummer i datatypen int.
        {
            return CykelNummer;
        }

        public bool GetCykelNummerBool(int cykelNummer) // Metod så att andra klasser kan hämta "protected" CykelNummer i datatypen bool.
        {
            return CykelNummer == cykelNummer;
        }
        public string GetTyp() // Metod så att andra klasser kan hämta "protected" Typ i datatypen string. 
        {
            return Typ;
        }

        public int GetTimPris() // Metod så att andra klasser kan hämta "protected" Timpris i datatypen int.
        {
            return Timpris;
        }

        
        public bool GetUrhyrd() // Metod så att andra klasser kan hämta "protected" Uthyrd i datatypen bool.
        {
            return Uthyrd;
        }
    }
}
