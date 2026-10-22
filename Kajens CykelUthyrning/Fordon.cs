namespace Kajens_CykelUthyrning
{
    public class Fordon
    {
        protected int CykelNummer { get; set; }
        protected string Name { get; set; }
        protected int Timpris { get; set; }
        protected bool Uthyrd { get; set; }

        public Fordon(int cykelNummer, string name, int timpris, bool uthyrd)
        {
            CykelNummer = cykelNummer;
            Name = name;
            Timpris = timpris;
            Uthyrd = uthyrd;
        }

        public virtual bool KanSäljas()
        {
            return !Uthyrd;
        }

        public virtual void VisaInfo()
        {
            Console.WriteLine($"Cykelnummer: {CykelNummer}, Namn: {Name}, Timpris: {Timpris}, Uthyrd: {Uthyrd}");
        }
    }
}
