using Kajens_CykelUthyrning;

List<Fordon> fordonLista = new List<Fordon>()  // Fordon listan, försökte göra det med json-fil i början men det strulade för mycket så gick över till detta.
{
    new Cykel(1, "Cykel", 40, false),
    new Cykel(2, "Cykel", 40, true),
    new Elcykel(3, "Elcykel", 70, false, 80),
    new Elcykel(4, "Elcykel", 70, false, 20)
};

List<Kund> kundLista = new List<Kund>(); // Kund listan

var uthyrning = new Uthyrning(); // varje gång programmet körs, ny uthyrning.

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

    Console.Write("Välj ett alternativ: ");
    int val = int.Parse(Console.ReadLine());

    if (val == 1)
    {
        foreach (Fordon fordon in fordonLista) // Itererar igenom fordonLista och skriver ut informationen.
        {
            fordon.VisaInfo();
        }
    }

    else if (val == 2) // Tar in den inmatade informationen om kunden och lagrar den i listan, sen skriver den ut informationen. Här kommer jag nog fixa iordning koden så det ser renare ut, flytta den till en metod i kund klassen och anropa den. Behöver ändå en metod som kollar åldern och avslutar programmet om kunden är under 15 år.
    {
        Console.Write("Ange kundens namn: ");
        string kundNamn = Console.ReadLine();

        Console.Write("Ange kundens ålder: ");
        int kundÅlder = int.Parse(Console.ReadLine());

        Console.Write("Är kunden medlem? (ja/nej): ");
        bool ärMedlem = Console.ReadLine().ToLower() == "ja";

        Kund nyKund = new Kund(kundNamn, kundÅlder, ärMedlem);

        nyKund.VisaKundInfo();
    }

    else if (val == 3) // Anropar VäljFordon funktionen från Uthyrning.cs
    {
        uthyrning.VäljFordon(fordonLista);         
    }

    else if (val == 6) // Avslutar programmet
    {
        break;
    }
}


