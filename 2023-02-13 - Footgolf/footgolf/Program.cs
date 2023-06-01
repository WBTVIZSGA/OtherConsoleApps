using footgolf;

IEnumerable<Competitor> competitors = File.ReadAllLines("fob2016.txt")
                                          .Select(row => new Competitor(row));

Console.WriteLine($"3. feladat: Versenyzők száma: {competitors.Count()}");

var femaleCount = competitors.Count(c => c.Category == "Noi");
Console.WriteLine($"4. feladat: A női versenyzők aránya { 100.0 * femaleCount / competitors.Count():f2} %");

var femaleWinner = competitors.Where(c => c.Category == "Noi").MaxBy(c => c.SumOfPoints);

/*
Competitor fw = null;
foreach (var item in competitors)
{
    if (item.Category == "Noi")
        if (fw == null || fw.SumOfPoints < item.SumOfPoints)
            fw = item;
}
*/

Console.WriteLine("6. feladat: A bajnok női versenyző:");
Console.WriteLine($"\tNeve: {femaleWinner.Name}");
Console.WriteLine($"\tEgyesület: {femaleWinner.Team}");
Console.WriteLine($"\tÖsszont: {femaleWinner.SumOfPoints}");

File.WriteAllLines(
    "osszpontFF.txt",
    competitors.Where(c => c.Category == "Felnott ferfi").Select(c => $"{c.Name};{c.SumOfPoints}")
);

var teams = competitors.GroupBy(c => c.Team)
                       .Select(g => new
                       {
                           Team = g.Key,
                           Count = g.Count(),
                           AvgPoints = g.Average(c => c.SumOfPoints),   //nem a feladat része, csak példa
                           BestCompetitor = g.MaxBy(c => c.SumOfPoints) //nem a feladat része, csak példa
                       })
                       .Where(x => x.Team != "n.a." && x.Count > 2)
                       .ToList();
Console.WriteLine("8. feladat: Egyesület statisztika:");
teams.ForEach(s =>
{
    Console.WriteLine($"\t{s.Team} - {s.Count} fő");
});
