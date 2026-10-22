namespace Kajens_CykelUthyrning
{
    public class Elcykel : Fordon
    {
        private int batteriNivå;

        public Elcykel(int CykelNummer, string Name, int Timpris, bool Uthyrd, int BatteriNivå) : base(CykelNummer, Name, Timpris, Uthyrd)
        {
            batteriNivå = BatteriNivå;
        }

        public override bool KanSäljas()
        {
            if (!uthyrd && batteriNivå > 30)
            {
                Console.WriteLine($"{name} kan säljas.");
                return !uthyrd;
            }
            else if (uthyrd)
            {
                Console.WriteLine($"{name} kan inte säljas eftersom den är uthyrd.");
                return true;
            }
            else
            {
                Console.WriteLine($"{name} kan inte säljas eftersom batterinivån är för låg.");
                return true;
            }
        }
    }
}
