
namespace Kajens_CykelUthyrning
{
    public class Elcykel : Fordon
    {
        private int BatteriNivå { get; set; }

        public Elcykel(int cykelNummer, string typ, int timpris, bool uthyrd, int batteriNivå) : base(cykelNummer, typ, timpris, uthyrd)
        {
            BatteriNivå = batteriNivå;
        }

        public override bool KanSäljas()
        {
            if (!Uthyrd && BatteriNivå > 30)
            {
                Console.WriteLine($"{Typ} kan säljas.");
                return !Uthyrd;
            }
            else if (Uthyrd)
            {
                Console.WriteLine($"{Typ} kan inte säljas eftersom den är uthyrd.");
                return true;
            }
            else
            {
                Console.WriteLine($"{Typ} {CykelNummer} kan inte säljas eftersom batterinivån är för låg ({BatteriNivå}%). Ladda batteriet först.");
                return true;
            }
        }

        public override void VisaInfo()
        {
            string status = Uthyrd ? "uthyrd" : "ledig";
            Console.WriteLine($"Cykelnummer: {CykelNummer}, Namn: {Typ}, Timpris: {Timpris}, Status: {status}, Batterinivå: {BatteriNivå}%");
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
