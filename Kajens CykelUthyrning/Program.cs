using Kajens_CykelUthyrning;

List<Fordon> fordonLista = new List<Fordon>()  // Fordon listan, försökte göra det med json-fil i början men det strulade för mycket så gick över till detta.
{
    new Cykel(1, "Cykel", 40, false),
    new Cykel(2, "Cykel", 40, false),
    new Elcykel(3, "Elcykel", 70, false, 80),
    new Elcykel(4, "Elcykel", 70, false, 20)
};

List<Kund> kundLista = new List<Kund>(); // Kund listan

var uthyrning = new Uthyrning(0, 0); // varje gång programmet körs, ny uthyrning.
var kund = new Kund("", 0, false); // varje gång programmet körs, ny kund.
var lämnaTillbaka = new LämnaTillbaka();


while (true) // While loopen
{
    Console.WriteLine("Välkommen till Kajens Cykeluthyrning!\n"); //Huvud menyn 

    Console.WriteLine("Vad vill du göra?");
    Console.WriteLine("1. Visa fordon");
    Console.WriteLine("2. Lägg till kund");
    Console.WriteLine("3. Hyr ut cykel");
    Console.WriteLine("4. Lämna tillbaka cykel");
    Console.WriteLine("5. Ladda elcykel batteri");
    Console.WriteLine("6. Avsluta");
    Console.WriteLine(); // Radbrytning

    Console.Write("Välj ett alternativ: ");

    if(!int.TryParse(Console.ReadLine(), out int val)) // Kollar om användaren matar in heltal för menyn, om inte så skrivs ett fel meddelande ut.
    {
        Console.WriteLine("Du måste skriva ett heltal mellan 1-6.");
        Console.WriteLine(); // Radbrytning

        continue; // Går tillbaka till början av loopen
    }

    if (val == 1)
    {
        Console.WriteLine(); //Radbrytning
        
        foreach (Fordon fordon in fordonLista) // Itererar igenom fordonLista och skriver ut informationen. - La till kund.GetKundÅlderInt() så att int kundÅlder sätts som det inmatade numret.
        {
            fordon.VisaInfo(kund.GetKundÅlderInt());
        }

        Console.WriteLine(); //Radbrytning
    }

    else if (val == 2) // Tar in den inmatade informationen om kunden och lagrar den i listan, sen skriver den ut informationen. Här kommer jag nog fixa iordning koden så det ser renare ut, flytta den till en metod i kund klassen och anropa den. Behöver ändå en metod som kollar åldern och avslutar programmet om kunden är under 15 år.
    {
        kund.RegistreraKund();
        kundLista.Add(kund); // Lägger till kunden i kundLista
    }

    else if (val == 3) // Anropar VäljFordon funktionen från Uthyrning.cs - La till kund.GetKundÅlderInt() så att int kundÅlder sätts som det inmatade numret.
    {
        uthyrning.VäljFordon(fordonLista, uthyrning.GetCykelNummerVal(), kund.GetKundNamn(), kund.GetKundÅlderInt()); 
    }

    else if (val == 4) // Anropar GetUthyrdFordon funktionen från Uthyrning.cs och lagrar den i en variabel, sen skickar den med den variabeln till SkrivKvitto funktionen i LämnaTillbaka.cs
    {
        Fordon? återlämnatFordon = uthyrning.GetUthyrdFordon();

        if (återlämnatFordon != null)
        {
            lämnaTillbaka.SkrivKvitto(återlämnatFordon, uthyrning, kund);
        }        
    }

    else if (val == 5)
    {
        Elcykel.LaddaElcykelBatteri(fordonLista);
    }

    else if (val == 6) // Avslutar programmet
    {
        break;
    }

    else // Om användaren matar in ett nummer som inte finns i menyn, skrivs ett fel meddelande ut.
    {
        Console.WriteLine("Ogiltigt val. Välj ett nummer mellan 1-6.");
        Console.WriteLine(); // Radbrytning
    }
}


