namespace Kajens_CykelUthyrning
{
    public class Cykel : Fordon
    {
        public Cykel(int cykelNummer, string typ, int timpris, bool uthyrd) : base(cykelNummer, typ, timpris, uthyrd)
        {
        }

        public override bool KanSäljas()
        {
            if (!Uthyrd)
            {
                Console.WriteLine($"{Typ} {CykelNummer} hyrs ut.");
                return !Uthyrd;
            }

            else
            {
                Console.WriteLine($"{Typ} {CykelNummer} kan inte säljas eftersom den är uthyrd.");
                return true;
            }
        }        
    }
}
