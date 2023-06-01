using System.Security.Cryptography;
using ultrabalaton;

var competitors = File.ReadAllLines("ub2017egyeni.txt")
                      .Skip(1)
                      .Select(row => new Competitor(row));

Console.WriteLine("3. feladat: Egyéni indulók: {0} fő", competitors.Count());

Console.WriteLine(
                    "4. feladat: Célba érkező női sportolók: {0} fő",
                    competitors.Count(c => c.Category=="Noi" && c.Percent == 100)
                 );

Console.Write("5. feladat: Kérem a sportoló nevét: ");
var name = Console.ReadLine();
var competitor = competitors.FirstOrDefault(c => c.Name==name);
Console.Write("\tIndult egyéniben a sportoló ?");
if (competitor != null)
{
    Console.WriteLine("Igen");
    Console.WriteLine(
                        "\tTeljesítette a teljes távot? {0}", 
                        competitor.Percent == 100 ? "Igen": "Nem"
                     );
}
else
{
    Console.WriteLine("Nem");
}

Console.WriteLine(
                    "7. feladat: Átlagos idő: {0:f2} óra",
                    competitors.Where(c => c.Category == "Ferfi" && c.Percent == 100)
                               .Average(c => c.IdőÓrában)
                 );
Console.WriteLine("8. feladat: A verseny győztesei");
var femaleWinner = competitors.Where(c => c.Category == "Noi" && c.Percent == 100)
                              .MinBy(c => c.TimeInSeconds);
var maleWinner = competitors.Where(c => c.Category == "Ferfi" && c.Percent == 100)
                            .MinBy(c => c.TimeInSeconds);
Console.WriteLine("\tNők: {0} ({1}.) - {2}", 
                   femaleWinner.Name,
                   femaleWinner.Number,
                   femaleWinner.Time);
Console.WriteLine("\tFérfiak: {0} ({1}.) - {2}",
                   maleWinner.Name,
                   maleWinner.Number,
                   maleWinner.Time);