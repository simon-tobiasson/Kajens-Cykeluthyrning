namespace Kajens_CykelUthyrning
{
    public class Fordon
    {

        protected int CykelNummer { get; set; }
        protected string Typ { get; set; }
        protected int Timpris { get; set; }
        protected bool Uthyrd { get; set; }

        public Fordon(int cykelNummer, string typ, int timpris, bool uthyrd)
        {
            CykelNummer = cykelNummer;
            Typ = typ;
            Timpris = timpris;
            Uthyrd = uthyrd;
        }

        public virtual bool KanSäljas()
        {
            return !Uthyrd;
        }

        public virtual void VisaInfo()
        {
            string status = Uthyrd ? "uthyrd" : "ledig";
            Console.WriteLine($"Cykelnummer: {CykelNummer}, Namn: {Typ}, Timpris: {Timpris}, Status: {status}");
        }

        public bool CykelNummerMatchar(int cykelNummer)
        {
            return CykelNummer == cykelNummer;
        }
    }
}
