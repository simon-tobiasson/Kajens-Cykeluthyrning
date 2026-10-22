namespace Kajens_CykelUthyrning
{
    public class Elcykel : Fordon
    {
        private int BatteriNivå { get; set; }

        public Elcykel(int cykelNummer, string name, int timpris, bool uthyrd, int batteriNivå) : base(cykelNummer, name, timpris, uthyrd)
        {
            BatteriNivå = BatteriNivå;
        }

        public override bool KanSäljas()
        {
            if (!Uthyrd && BatteriNivå > 30)
            {
                Console.WriteLine($"{Name} kan säljas.");
                return !Uthyrd;
            }
            else if (Uthyrd)
            {
                Console.WriteLine($"{Name} kan inte säljas eftersom den är uthyrd.");
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} {CykelNummer} kan inte säljas eftersom batterinivån är för låg ({BatteriNivå}%). Ladda batteriet först.");
                return true;
            }
        }

        public override void VisaInfo()
        {
            Console.WriteLine($"Cykelnummer: {CykelNummer}, Namn: {Name}, Timpris: {Timpris}, Uthyrd: {Uthyrd}, Batterinivå: {BatteriNivå}%");
        }   

        public void LaddaBatteri()
        {
            if (BatteriNivå  < 100)
            {
                Console.WriteLine("Batteriet laddar."); ;
            }
            else 
            { 
                Console.WriteLine($"Batteriet är redan fulladdat"); 
            }
        }
    }
}
