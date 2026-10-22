namespace Kajens_CykelUthyrning
{
    public class Cykel : Fordon
    {
        public Cykel(int cykelNummer, string name, int timpris, bool uthyrd) : base(cykelNummer, name, timpris, uthyrd)
        {
        }

        public override bool KanSäljas()
        {
            if (!Uthyrd)
            {
                Console.WriteLine($"{Name} kan säljas.");
                return !Uthyrd;
            }

            else
            {
                Console.WriteLine($"{Name} kan inte säljas eftersom den är uthyrd.");
                return true;
            }
        }
    }
}
