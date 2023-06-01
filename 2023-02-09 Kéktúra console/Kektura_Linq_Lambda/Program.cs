using Kektura;
using System.Diagnostics;

int startHeight = int.Parse(File.ReadAllLines("kektura.csv")[0]);

List<Trail> trails = File.ReadAllLines("kektura.csv")
                         .Skip(1)
                         .Select(row => new Trail(row))
                         .ToList();

Console.WriteLine($"3. feladat: Szakaszok száma: {trails.Count}");

var sum = trails.Sum(t => t.Distance);

Console.WriteLine($"4. feladat: A túra teljes hossza: {sum} km");

var shortestTrail = trails.MinBy(t => t.Distance);

Console.WriteLine("5. feladat: A legrövidebb szakasz adatai:");
Console.WriteLine($"\tKezdete: {shortestTrail.StartPlace}");
Console.WriteLine($"\tVége: {shortestTrail.FinishPlace}");
Console.WriteLine($"\tTávolság: {shortestTrail.Distance}");

Console.WriteLine("7. feladat: hiányos állomásnevek");
trails.Where(t => t.HianyosNev)
      .ToList()
      .ForEach(t => Console.WriteLine($"\t{t.FinishPlace}"));

trails[0].FinishHeight = startHeight + trails[0].Increase - trails[0].Decrease;
for (int i = 1; i < trails.Count; i++)
    trails[i].FinishHeight = trails[i-1].FinishHeight + trails[i].Increase - trails[i].Decrease;

var trailWithHighestPlace = trails.MaxBy(t => t.FinishHeight);
Console.WriteLine($"8. feladat: Legmagasabb végpont: {trailWithHighestPlace.FinishPlace}: " +
                  $"{trailWithHighestPlace.FinishHeight} m");

var rows = trails.Select(t => string.Format("{0};{1};{2};{3};{4};{5}",
                             t.StartPlace,
                             t.FinishPlace + (t.HianyosNev ? " pecsetelohely" : ""),
                             t.Distance,
                             t.Increase,
                             t.Decrease,
                             t.isStamp ? "i" : "n")
                        )
                 .ToList();
rows.Insert(0, startHeight.ToString());

File.WriteAllLines("kektura2.csv", rows);