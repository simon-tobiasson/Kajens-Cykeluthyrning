using Kajens_CykelUthyrning;

List<Fordon> fordonLista = new List<Fordon>()
{
    new Cykel(1, "Cykel", 40, false),
    new Cykel(2, "Cykel", 40, true),
    new Elcykel(3, "Elcykel", 70, false, 80),
    new Elcykel(4, "Elcykel", 70, false, 20)
};




while (true)
{
    Console.WriteLine("Välkommen till Kajens Cykeluthyrning!\n");
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
        foreach (Fordon fordon in fordonLista)
        {
            fordon.VisaInfo();
        }
    }

    else if (val == 6)
    {
        break;
    }
}


