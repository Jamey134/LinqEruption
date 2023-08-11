// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Linq; 
using LinqEruption.Models;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
Console.WriteLine("EXAMPLE BELOW");
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!


//-----Use LINQ to find the first eruption that is in Chile and print the result.-----
Console.WriteLine("I)");
Eruption? ChileFirstEruption = eruptions.Where(c => c.Location == "Chile").OrderBy(c => c.Year).FirstOrDefault();

Console.WriteLine(ChileFirstEruption.ToString());

//----- Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found." -----

Console.WriteLine("II)");

Eruption? FirstHI = eruptions.Where(h => h.Location == "Hawaiian Is").OrderBy(h => h.Year).FirstOrDefault();
if(FirstHI != null)
{
    Console.WriteLine(FirstHI);
}
else 
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}

//-----Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."-----
Console.WriteLine("III)");

Eruption? FirstGL = eruptions.Where(g => g.Location == "Greenland Is").OrderBy(g => g.Year).FirstOrDefault();
if(FirstGL!= null)
{
    Console.WriteLine(FirstGL);
}
else 
{
    Console.WriteLine("No Greenland Eruption found.");
}

//-----Find the first eruption that is after the year 1900 AND in "New Zealand", then print it."-----
Console.WriteLine("IV)");

Eruption? NZ = eruptions.FirstOrDefault(n => n.Year > 1900 && n.Location == "New Zealand");

Console.WriteLine(NZ);

//-----Find all eruptions where the volcano's elevation is over 2000m and print them.-----
Console.WriteLine("V)");

IEnumerable<Eruption> Over2K = eruptions.Where(o => o.ElevationInMeters >= 2000);

PrintEach(Over2K);

//-----Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.-----
Console.WriteLine("VI)");

IEnumerable<Eruption> EL = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach( EL, $"Number of Eruptions: {EL.Count()}");

//-----Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)-----
Console.WriteLine("VII)");


int High = eruptions.Max(h => h.ElevationInMeters);

Console.WriteLine("Highest Elevaltion: " + High);

//-----Use the highest elevation variable to find and print the name of the Volcano with that elevation.-----
Console.WriteLine("VIII)");

Eruption? Highest = eruptions.First(q => q.ElevationInMeters == High);
Console.WriteLine($"The highest elevation volcano is {Highest.Volcano}");

Console.WriteLine("IX)");
// Print all Volcano names alphabetically.

IEnumerable<string> Vol = eruptions.OrderBy(q => q.Volcano).Select(q => q.Volcano).ToList(); 

foreach (string name in Vol)
{
Console.WriteLine(name);
}

Console.WriteLine("X)");
// Print the sum of all the elevations of the volcanoes combined.
int EleSum = eruptions.Sum(q => q.ElevationInMeters);
Console.WriteLine($"Total Elevation = {EleSum}");


Console.WriteLine("XI)");
//-----Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)-----
bool Year2000 = eruptions.Any(q => q.Year == 2000);
if(Year2000)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}

Console.WriteLine("XII)");
//-----Find all stratovolcanoes and print just the first three (Hint: look up Take)-----

IEnumerable<Eruption> StVolcanoes = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(StVolcanoes, "3 Stratovolcanoes:");

Console.WriteLine("XIII)");
//-----Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.-----

IEnumerable<Eruption> Eruptions1000CE = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(Eruptions1000CE, "Eruptions before the year 1000 CE:");

Console.WriteLine("XIV)");
//-----Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.-----

string[] EruptionNames1000CE = eruptions.Where(en => en.Year < 1000).OrderBy(en => en.Volcano).Select(en => en.Volcano).ToArray();
Console.WriteLine("{0}", String.Join("\n", EruptionNames1000CE)); //<--- "\n" is used to insert a new line in a string or text output. 




// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

