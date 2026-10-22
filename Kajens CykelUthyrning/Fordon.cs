namespace Kajens_CykelUthyrning
{
    public class Fordon
    {

        public int CykelNummer { get; set; }
        public string Typ { get; set; }
        public int Timpris { get; set; }
        public bool Uthyrd { get; set; }   

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
    }
}
