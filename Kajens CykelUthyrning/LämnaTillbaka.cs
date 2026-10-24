using System;
using System.Collections.Generic;
using System.Text;

namespace Kajens_CykelUthyrning
{
    public class LämnaTillbaka
    {

        public decimal DelSumma(Fordon fordon, Uthyrning uthyrning)
        {
            decimal sum = 0;

            sum = fordon.GetTimPris() * uthyrning.GetAntalUthyrdaTimmar();
            return sum;
        }

        public decimal Rabatt(Fordon fordon, Uthyrning uthyrning, Kund kund)
        {
            decimal sum = DelSumma(fordon, uthyrning);
            decimal medlemRabatt = 0;

            if(kund.GetÄrMedlem() == true)
            {
                medlemRabatt = sum / 10;
            }

            return medlemRabatt;
        }

        public decimal TotalSumma(Fordon fordon, Uthyrning uthyrning, Kund kund)
        {
            return DelSumma(fordon, uthyrning) - Rabatt(fordon, uthyrning, kund);
        }

        
        public void SkrivKvitto(Fordon fordon, Uthyrning uthyrning, Kund kund)
        {
            decimal delSumma = DelSumma(fordon, uthyrning);
            decimal rabatt = Rabatt(fordon, uthyrning, kund);
            decimal totalSumma = TotalSumma(fordon, uthyrning, kund);


            Console.WriteLine($"Cykelnummer: {uthyrning.GetCykelNummerVal()}");

            Console.WriteLine("KVITTO");
            Console.WriteLine($"{fordon.GetTyp()}, {uthyrning.GetAntalUthyrdaTimmar()} timmar * {fordon.GetTimPris()} kr  :  {delSumma} kr");

            if (kund.GetÄrMedlem())
            {
                Console.WriteLine($"Medlemsrabatt (10%)  {rabatt} kr");
            }

            Console.WriteLine($"Att betala: {totalSumma} kr");
        }
    }
}
