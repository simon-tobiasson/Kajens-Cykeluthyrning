namespace Kajens_CykelUthyrning
{
    public class Cykel : Fordon
    {
        public Cykel(int CykelNummer, string Name, int Timpris, bool Uthyrd) : base(CykelNummer, Name, Timpris, Uthyrd)
        {
        }

        public override bool KanSäljas()
        {
            if (!uthyrd)
            {
                Console.WriteLine($"{name} kan säljas.");
                return !uthyrd;
            }

            else
            {
                Console.WriteLine($"{name} kan inte säljas eftersom den är uthyrd.");
                return true;
            }
        }
    }
}
