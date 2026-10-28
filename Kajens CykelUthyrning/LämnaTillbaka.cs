using System;
using System.Collections.Generic;
using System.Text;

namespace Kajens_CykelUthyrning
{
    public class LämnaTillbaka
    {

        public decimal SubTotal(Fordon vehicle, Uthyrning rental) // SubTotal metoden beräknar summan utan discount
        {
            decimal sum = 0;

            sum = vehicle.GetHourlyPrice() * rental.GetRentedHoursAmount(); // Hämtar timpris från vehicle och multiplicerar med antal uthyrda timmar från rental
            return sum;
        }

        public decimal Discount(Fordon vehicle, Uthyrning rental, Kund customer) // Discount metoden beräknar rabatten om kunden är medlem
        {
            decimal sum = SubTotal(vehicle, rental);
            decimal memberDiscount = 0;

            if(customer.GetIsMember() == true)
            {
                memberDiscount = sum / 10;
            }

            return memberDiscount;
        }

        public decimal TotalSum(Fordon vehicle, Uthyrning rental, Kund customer) // TotalSum metoden beräknar summan med discount
        {
            return SubTotal(vehicle, rental) - Discount(vehicle, rental, customer);
        }

        
        public void PrintReceipt(Fordon vehicle, Uthyrning rental, Kund customer) // PrintReceipt metoden skriver ut kvittot med information om cykelnummer, typ, antal uthyrda timmar, timpris, delsumma, discount och totalsumma
        {
            decimal subTotal = SubTotal(vehicle, rental);
            decimal discount = Discount(vehicle, rental, customer);
            decimal totalSum = TotalSum(vehicle, rental, customer);

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"Cykelnummer: {vehicle.GetBicycleNumberInt()}");

            Console.WriteLine(); //Radbrytning

            Console.WriteLine("KVITTO");

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"{vehicle.GetType()}, {rental.GetRentedHoursAmount()} timmar * {vehicle.GetHourlyPrice()} kr  :  {subTotal} kr");                      

            if (customer.GetIsMember())
            {
                Console.WriteLine($"Medlemsrabatt (10%)  {discount} kr");                
            }

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"Att betala: {totalSum} kr");
        }
    }
}
