using Kektura;
//Klasszikus megoldás, mint 12-ben.


List<Trail> trails = new List<Trail>(); 

var sr = new StreamReader("kektura.csv");
int startHeight = int.Parse(sr.ReadLine());
int height = startHeight;
while (!sr.EndOfStream)
{
    var t = new Trail(sr.ReadLine(), height);
    trails.Add(t);
    height = t.FinishHeight;
}
sr.Close();

Console.WriteLine($"3. feladat: Szakaszok száma: {trails.Count}");

double sum = 0;
foreach (var t in trails)
    sum += t.Distance;

Console.WriteLine($"4. feladat: A túra teljes hossza: {sum} km");

var shortestTrail = trails[0];
foreach (var t in trails)
    if (shortestTrail.Distance > t.Distance)
        shortestTrail = t;

Console.WriteLine("5. feladat: A legrövidebb szakasz adatai:");
Console.WriteLine($"\tKezdete: {shortestTrail.StartPlace}");
Console.WriteLine($"\tVége: {shortestTrail.FinishPlace}");
Console.WriteLine($"\tTávolság: {shortestTrail.Distance}");

Console.WriteLine("7. feladat: hiányos állomásnevek");
foreach (var t in trails)   
    if (t.HianyosNev)
        Console.WriteLine($"\t{t.FinishPlace}");

Trail trailWithHighestPlace = trails[0];
foreach (var t in trails)
    if (trailWithHighestPlace.FinishHeight < t.FinishHeight)
        trailWithHighestPlace = t;
Console.WriteLine($"8. feladat: Legmagasabb végpont: {trailWithHighestPlace.FinishPlace}: " +
                  $"{trailWithHighestPlace.FinishHeight} m");

var sw = new StreamWriter("kektura2.csv");
sw.WriteLine(startHeight);
foreach (var t in trails)
    sw.WriteLine("{0};{1};{2};{3};{4};{5}",
                 t.StartPlace,
                 t.FinishPlace + (t.HianyosNev ? " pecsetelohely": ""),
                 t.Distance,
                 t.Increase,
                 t.Decrease,
                 t.isStamp ? "i" : "n");

sw.Close();