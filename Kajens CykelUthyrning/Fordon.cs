namespace Kajens_CykelUthyrning
{
    public class Fordon
    {
        protected int cykelNummer;
        protected string name;
        protected int timpris;
        protected bool uthyrd;

        public Fordon(int CykelNummer, string Name, int Timpris, bool Uthyrd)
        {
            cykelNummer = CykelNummer;
            name = Name;
            timpris = Timpris;
            uthyrd = Uthyrd;
        }

        public virtual bool KanSäljas()
        {
            return !uthyrd;
        }
    }
}
