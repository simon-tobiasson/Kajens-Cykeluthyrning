using Kajens_CykelUthyrning;
using System.Text.Json;
using System.Xml.Linq;

string jsonFile = File.ReadAllText("Cyklar.json");
Console.WriteLine("JSON content:");
Console.WriteLine(jsonFile);

List<Fordon> fordonLista = JsonSerializer.Deserialize<List<Fordon>>(jsonFile);

var cykelLista = fordonLista.Where(x => x.Name == "Cykel").Cast<Cykel>();
var elcykelLista = fordonLista.Where(x => x.Name == "Elcykel").Cast<Elcykel>();

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
        foreach (var cykel in cykelLista)
        {
            cykel.VisaInfo();
        }

        foreach (var elcykel in elcykelLista)
        {
           elcykel.VisaInfo();
        }
    }

    else if (val == 6)
    {
        break;
    }
}


