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
                Console.WriteLine($"{Typ} kan säljas.");
                return !Uthyrd;
            }

            else
            {
                Console.WriteLine($"{Typ} kan inte säljas eftersom den är uthyrd.");
                return true;
            }
        }

        public override void VisaInfo()
        {
            Console.WriteLine($"Cykelnummer: {CykelNummer}, Namn: {Typ}, Timpris: {Timpris}, Uthyrd: {Uthyrd}");
        }
    }
}
