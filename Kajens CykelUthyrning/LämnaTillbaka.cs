using System;
using System.Collections.Generic;
using System.Text;

namespace Kajens_CykelUthyrning
{
    public class LämnaTillbaka
    {

        public decimal DelSumma(Fordon fordon, Uthyrning uthyrning) // DelSumma metoden beräknar summan utan rabatt
        {
            decimal sum = 0;

            sum = fordon.GetTimPris() * uthyrning.GetAntalUthyrdaTimmar(); // Hämtar timpris från fordon och multiplicerar med antal uthyrda timmar från uthyrning
            return sum;
        }

        public decimal Rabatt(Fordon fordon, Uthyrning uthyrning, Kund kund) // Rabatt metoden beräknar rabatten om kunden är medlem
        {
            decimal sum = DelSumma(fordon, uthyrning);
            decimal medlemRabatt = 0;

            if(kund.GetÄrMedlem() == true)
            {
                medlemRabatt = sum / 10;
            }

            return medlemRabatt;
        }

        public decimal TotalSumma(Fordon fordon, Uthyrning uthyrning, Kund kund) // TotalSumma metoden beräknar summan med rabatt
        {
            return DelSumma(fordon, uthyrning) - Rabatt(fordon, uthyrning, kund);
        }

        
        public void SkrivKvitto(Fordon fordon, Uthyrning uthyrning, Kund kund) // SkrivKvitto metoden skriver ut kvittot med information om cykelnummer, typ, antal uthyrda timmar, timpris, delsumma, rabatt och totalsumma
        {
            decimal delSumma = DelSumma(fordon, uthyrning);
            decimal rabatt = Rabatt(fordon, uthyrning, kund);
            decimal totalSumma = TotalSumma(fordon, uthyrning, kund);

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"Cykelnummer: {fordon.GetCykelNummerInt()}");

            Console.WriteLine(); //Radbrytning

            Console.WriteLine("KVITTO");

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"{fordon.GetTyp()}, {uthyrning.GetAntalUthyrdaTimmar()} timmar * {fordon.GetTimPris()} kr  :  {delSumma} kr");                      

            if (kund.GetÄrMedlem())
            {
                Console.WriteLine($"Medlemsrabatt (10%)  {rabatt} kr");                
            }

            Console.WriteLine(); //Radbrytning

            Console.WriteLine($"Att betala: {totalSumma} kr");
        }
    }
}
