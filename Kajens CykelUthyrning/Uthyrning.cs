using System.Linq;

namespace Kajens_CykelUthyrning
{
    public class Uthyrning
    {

        private List<Fordon> rentedVehicleList = new List<Fordon>();  // En lista som håller reda på de vehicle som blir uthyrda
        private int RentedHoursAmount { get; set; }
        private int BicycleNumberChoice { get; set; }

        public Uthyrning(int rentedHoursAmount, int bicycleNumberChoice)
        {
            RentedHoursAmount = rentedHoursAmount;
            BicycleNumberChoice = bicycleNumberChoice;            
        }
        
        public void ChooseVehicle(List<Fordon> vehicleList, int bicycleNumberChoice, string customerName, int customerAge)   // Metod som låter användaren välja ett vehicle från listan med att skriva in cykelnumret. Om fordonet kan säljas läggs det till i uthyrningslistan.
        {
            int minNummer = vehicleList.Min(v => v.GetBicycleNumberInt()); // Hämtar det minsta cykelnumret från vehicle listan.
            int maxNummer = vehicleList.Max(v => v.GetBicycleNumberInt()); // Hämtar det högsta cykelnumret från samma lista.

            Console.WriteLine(); //Radbrytning

            Console.WriteLine("Cyklar att välja mellan: ");
            
            foreach (Fordon item in vehicleList) 
            {
                item.ShowInfo(customerAge);
            }

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"Kund: {customerName}");

            Console.Write("Ange cykelnummer: ");

            if (!int.TryParse(Console.ReadLine(), out bicycleNumberChoice)) // Jag fixade det. Nu fungerar det som jag ville! Förhoppningsvis. Har inte tid att felsöka mer idag (kl 21:07). (Och det som detta kodblocket gör är att kolla om svaret är ett heltal. Om det inte är det slår fel meddelandet in.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine($"Ogiltigt nummer. Välj ett nummer mellan numren i listan, {minNummer} och {maxNummer}.");

                Console.WriteLine(); //Radbrytning
                return;
            }
            
            Fordon? bicycleNumber = vehicleList.FirstOrDefault(v => v.GetBicycleNumberBool(bicycleNumberChoice)); // Tar och kollar igenom vehicleList om användarens val av cykelnummer finns med

            if(bicycleNumber == null) // Om svaret inte finns med i listan räknas det som null och då kommer detta fel meddelandet istället.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine($"Fordon med cykelnummer {bicycleNumberChoice} finns inte i listan. Välj ett nummer mellan numren i listan, {minNummer} och {maxNummer}.");

                Console.WriteLine(); //Radbrytning
                return;
            }

            

            if(customerAge >= 15 && customerAge <= 17 && bicycleNumber is Elcykel) // Villkoret skriver ut felmeddelandet och går tillbaka om användaren försöker hyra en electricbike även om kunden är 15-17 år.
            {
                Console.WriteLine(); //Radbrytning

                Console.WriteLine("En kund mellan 15-17 år kan inte hyra en elcykel.");

                Console.WriteLine(); //Radbrytning
                return;
            }  
            
            if (!bicycleNumber.CanBeRented())
            {
                return;
            }

            if (CheckHours(bicycleNumber) == false) // Anropar CheckHours metoden från längre ner i Uthyrning klassen.
            {            
                return;
            }      

            rentedVehicleList.Add(bicycleNumber);
            bicycleNumber.RentVehicle();
            Console.WriteLine($"Cykelnummer {bicycleNumberChoice} hyrs ut i {RentedHoursAmount} timmar.");

            Console.WriteLine(); //Radbrytning
            return;
            
        }

        public Fordon GetRentedVehicles() // Metod som returnerar det fordom som är uthyrt.
        {
            if (rentedVehicleList.Count == 0) // Om listan är tom så kommer felmeddelandet att skrivas ut och metoden returnerar null.
            {
                Console.WriteLine("Det finns inga fordon som är uthyrda ännu.");
                return null;
            }

            Console.WriteLine(); //Radbrytning

            Console.WriteLine("Fordon som är uthyrda:");
            
            foreach(var vehicle in rentedVehicleList) // Skriver ut alla fordon som är uthyrda.
            {
                Console.WriteLine($"Cykelnummer: {vehicle.GetBicycleNumberInt()}, Typ: {vehicle.GetType()}");
            }

            Console.WriteLine(); //Radbrytning

            Console.Write("Välj ett cykelnummer som ska lämnas in: ");

            string input = Console.ReadLine(); // Tar emot användarens input som en string.

            if (int.TryParse(input, out int bicycleNumberChoice)) // Kollar om användaren skriver in ett heltal. Om det är ett heltal kommer koden att köras
            {
                Fordon? vehiclesToReturn = rentedVehicleList.FirstOrDefault(v => v.GetBicycleNumberBool(bicycleNumberChoice)); // Kollar om heltalet som användaren skrev in finns med i listan med uthyrda vehicle.

                if(vehiclesToReturn != null) // Om fordonet finns med i listan så tas det bort från listan, fordonet blir ledigt och returneras.
                {
                    rentedVehicleList.Remove(vehiclesToReturn);                    
                    vehiclesToReturn.ReturnVehicle();
                    return vehiclesToReturn;
                }
                else
                {
                    Console.WriteLine($"Cykelnummer {bicycleNumberChoice} är inte en cykel som är uthyrd."); // Om fordonet inte finns med i listan kommer detta felmeddelande att skrivas ut och sen returnerar den null.

                    Console.WriteLine(); //Radbrytning
                    return null;
                }                
            }
            else // Om användaren inte skriver in ett heltal kommer denna koden köras.
            {
                Console.WriteLine("Du måste skriva ett cykelnummer.");

                Console.WriteLine(); //Radbrytning
                return null;
            }            
        }        

        public bool CheckHours(Fordon bicycleNumberChoice) // Metoden kollar hur många timmar cykeln ska hyras ut. 
        {

            if (bicycleNumberChoice is Elcykel electricbike && bicycleNumberChoice.GetRented() == false) // Om cykeln är ledig och är en elcykel ska inte användaren kunna skriva fler timmar än vad batteri nivån är. 
            {
                Console.Write("Ange timmar: ");
                RentedHoursAmount = int.Parse(Console.ReadLine());

                if (RentedHoursAmount > electricbike.GetBatteryLevelInt() / 10) 
                {
                    Console.WriteLine("Kunden kan inte hyra en elcykeln längre tid än dess batteri nivå.");

                    Console.WriteLine(); //Radbrytning
                    return false;
                }               
            }

            else if (bicycleNumberChoice is Cykel && bicycleNumberChoice.GetRented() == false) // Om cykeln är ledig och är en vanlig cykel så tar den emot antal timmar.
            {
                Console.Write("Ange timmar: ");
                RentedHoursAmount = int.Parse(Console.ReadLine());
            }
            return true;            
        }      
        
        public int GetRentedHoursAmount() // Metod som returnerar det antal timmar som cykeln är uthyrd. Används i LämnaTillbaka.cs för att skriva ut kvittot.
        {
            return RentedHoursAmount;
        }
        
        public int GetBicycleNumberChoice() // Metoden gör så att ndra klasser kan hämta "private" BicycleNumberChoice.
        {
            return BicycleNumberChoice;
        }
    }
}
