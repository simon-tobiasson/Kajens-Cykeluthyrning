namespace Kajens_CykelUthyrning
{
    public class Fordon
    {

        protected int BicycleNumber { get; set; }
        protected string Type { get; set; }
        protected int HourlyPrice { get; set; }
        protected bool Rented { get; set; }

        public Fordon(int bicycleNumber, string type, int hourlyPrice, bool rented) // Konstruktorn för basklassen
        {
            BicycleNumber = bicycleNumber;
            Type = type;
            HourlyPrice = hourlyPrice;
            Rented = rented;
        }

        public virtual bool CanBeRented() // Bas metoden för om ett fordon kan hyras ut. (Ändrar namnet från KanSäljas till CanBeRented.)
        {
            return !Rented;
        }        

        public virtual void ShowInfo(int kundÅlder) // Bas metoden för alla fordon infon. La till int CustomerAge i parametern så funktion kan läsa den informationen.
        {
            string status = Rented ? "uthyrd" : "ledig";
            Console.WriteLine($"Cykelnummer: {BicycleNumber}, Typ: {Type}, Timpris: {HourlyPrice}, Status: {status}");            
        }

        public void RentVehicle() // Metod så att andra klasser kan ändra "protected" Rented till true.
        {
            Rented = true;
        }

        public void ReturnVehicle() // Metod så att andra klasser kan ändra "protected" Rented till false.
        {
            Rented = false;
        }

        public int GetBicycleNumberInt() // Metod så att andra klasser kan hämta "protected" BicycleNumber i datatypen int.
        {
            return BicycleNumber;
        }

        public bool GetBicycleNumberBool(int bicycleNumber) // Metod så att andra klasser kan hämta "protected" BicycleNumber i datatypen bool.
        {
            return BicycleNumber == bicycleNumber;
        }
        public string GetType() // Metod så att andra klasser kan hämta "protected" Type i datatypen string. 
        {
            return Type;
        }

        public int GetHourlyPrice() // Metod så att andra klasser kan hämta "protected" HourlyPrice i datatypen int.
        {
            return HourlyPrice;
        }

        
        public bool GetRented() // Metod så att andra klasser kan hämta "protected" Rented i datatypen bool.
        {
            return Rented;
        }
    }
}
