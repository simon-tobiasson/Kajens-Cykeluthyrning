using System.Collections.Generic;
using System.Linq;

namespace Kajens_CykelUthyrning
{
    public class Uthyrning
    {

        private List<Fordon> fordonUthyrningLista = new List<Fordon>();  // En lista som håller reda på de fordon som blir uthyrda

        private int antalUthyrdaTimmar { get; set; } 
        
        public void VäljFordon(List<Fordon> fordonLista)   // Metod som låter användaren välja ett fordon från listan med att skriva in cykelnumret. Om fordonet kan säljas läggs det till i uthyrningslistan.
        {
            Console.Write("Ange cykelnummer: ");

            if(!int.TryParse(Console.ReadLine(), out int nummer)) // Finns ett fel här. Koden kollar bara om det är ett giltigt nummer, men den kollar inte om numret finns i listan. Om numret inte finns i listan kommer fordon att vara null och programmet kraschar. Jag kommer fixa detta imorgon eller senare idag.
            {
                Console.WriteLine($"Ogiltigt nummer. Välj ett nummer mellan {fordonLista.First().CykelNummerMatchar} och {fordonLista.Last().CykelNummerMatchar}");
                return;
            }

            Fordon? fordon = fordonLista.FirstOrDefault(f => f.CykelNummerMatchar(nummer));

            if(KollaTimmar(fordonLista) == false)
            {
                return;
            }
            

            if (fordon.KanSäljas())
            {
                fordonUthyrningLista.Add(fordon);
                return;
            }
            return;

        }

        public bool KollaTimmar(List<Fordon> fordonLista)
        {
            Console.Write("Ange timmar: ");
            int antalUthyrdaTimmar = int.Parse(Console.ReadLine());

            var elcykel = fordonLista.OfType<Elcykel>().FirstOrDefault();

            if (antalUthyrdaTimmar > elcykel.GetBatteriNivå() / 10)
            {
                Console.WriteLine("Kunden kan inte hyra elcykeln längre tid än dess batteri nivå.");
                return false;
            }
            return true;
        }

        //public void LäggTillFordon(List<Fordon> fordonLista)
        //{

        //    if (fordon.KanSäljas())
        //    {
        //        fordonUthyrningLista.Add(fordon);
        //        return;
        //    }
        //    return;
        //}
    }
}
