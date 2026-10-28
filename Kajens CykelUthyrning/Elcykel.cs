using System.Linq;

namespace Kajens_CykelUthyrning
{
    public class Elcykel : Fordon // Subklass
    {
        private int BatteryLevel { get; set; } // Utökar klassen med BatteryLevel då den andra subklassen inte har det. 

        public Elcykel(int bicycleNumber, string type, int hourlyPrice, bool rented, int batteryLevel) : base(bicycleNumber, type, hourlyPrice, rented)
        {
            BatteryLevel = batteryLevel;
        }

        public override bool CanBeRented() // Polymorferar metoden från basklassen till att ge felmeddelande till olika situationer.
        {
            

            if (!Rented && BatteryLevel > 30) // Om cykeln inte är uthyrd och batterinivån är över 30% kan den hyras ut.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine($"Cykelnummer {BicycleNumber} kan bli uthyrd i max {BatteryLevel / 10} timmar.");

                Console.WriteLine(); //Radbrytning

                return !Rented;
            }

            else if (Rented) // Om cykeln är uthyrd kommer detta felmeddelande att skrivas ut.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine($"Cykelnummer {BicycleNumber} är redan uthyrd.");

                Console.WriteLine(); //Radbrytning
                return false;
            }

            else // Om cykeln inte är uthyrd men batterinivån är under 30% kommer detta felmeddelande att skrivas ut.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine($"Cykelnummer {BicycleNumber} kan inte hyras ut eftersom batterinivån är för låg ({BatteryLevel}%). Ladda batteriet först.");

                Console.WriteLine(); //Radbrytning
                return false;
            }
        }

        public override void ShowInfo(int customerAge) // Polymorferar metoden från basklassen, skriver ut ett meddelande när kunden är mellan 15-17 år och allt runt omkring visar den electricBicycle informationen.
        {
            
            if (customerAge >= 15 && customerAge <= 17)
            {
                Console.WriteLine($"Cykelnummer: {BicycleNumber}, Typ: {Type} - Kom ihåg, kunder mellan 15-17 år kan inte hyra en elcykel");
            }
            else 
            {                
                string status = Rented ? "uthyrd" : "ledig";
                Console.WriteLine($"Cykelnummer: {BicycleNumber}, Typ: {Type}, Timpris: {HourlyPrice}, Status: {status}, Batterinivå: {BatteryLevel}%");
            }            
        }


        public static void ChargeElectricBicycleBattery(List<Fordon> vehiclelist)
        {
            int minNummer = vehiclelist.Min(v => v.GetBicycleNumberInt());
            int maxNummer = vehiclelist.Max(v => v.GetBicycleNumberInt());

            Console.WriteLine(); //Radbrytning

            Console.WriteLine("Cyklar att välja mellan: ");

            Console.WriteLine(); //Radbrytning

            foreach (Fordon item in vehiclelist)
            {
                if(item is Elcykel)
                {
                    item.ShowInfo(0);
                }                
            }

            Console.WriteLine(); //Radbrytning

            Console.Write("Ange cykelnummer på elcykeln som ska laddas: ");

            if(int.TryParse(Console.ReadLine(), out int bicycleNumberChoice))
            {
                Fordon? vehicle = vehiclelist.FirstOrDefault(f => f.GetBicycleNumberBool(bicycleNumberChoice));

                if(vehicle is Elcykel electricBicycle)
                {
                    electricBicycle.ChargeBattery();
                    return;
                }
                else if(vehicle == null)
                {
                    Console.WriteLine($"{bicycleNumberChoice} finns inte med i listan. Välj mellan {minNummer} och {maxNummer}.");

                    Console.WriteLine(); //Radbrytning
                    return;
                }
                else
                {
                    Console.WriteLine($"Cykelnummer: {bicycleNumberChoice} är inte elcykel. Välj en elcykel.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Du måste skriva ett nummer.");
            }
        }
        public void ChargeBattery() // Metoden används i metoden ovanför.
        {           
            if (BatteryLevel < 100)
            {
                BatteryLevel = 100;
                Console.WriteLine("Batteriet har laddats och är nu fulladdad.");

                Console.WriteLine(); //Radbrytning
            }
            else 
            { 
                Console.WriteLine($"Batteriet är redan fulladdat");

                Console.WriteLine(); //Radbrytning
            }
        }

        public int GetBatteryLevelInt() // Gör det möjligt för andra klasser att läsa in den privata egenskapen. Förtillfället läses den bara in i Uthyrning - CheckHours.
        {
            return BatteryLevel;
        }
    }
}
