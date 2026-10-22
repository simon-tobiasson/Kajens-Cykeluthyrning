namespace Kajens_CykelUthyrning
{
    public class Fordon
    {
        protected int cykelNummer;
        protected int timpris;
        protected bool uthyrd;

        public Fordon(int CykelNummer, int Timpris, bool Uthyrd)
        {
            cykelNummer = CykelNummer;
            timpris = Timpris;
            uthyrd = Uthyrd;
        }

        public virtual bool KanSäljas()
        {
            return !uthyrd;
        }
    }
}
