// var input = "16,1,2,0,4,2,7,1,2,14";

using System.Xml.Schema;

var input = await File.ReadAllTextAsync("/Users/eddsansome/code/advent_of_code/2021/day7/input7.txt");

var crabs = input.Split(",").ToList().Select(int.Parse).ToList();

int Question1(List<int> ints)
{
    var mid = ints[ints.Count() / 2];

    return ints.Select(crab => crab < mid ? mid - crab : crab - mid).Sum();
}

int Question2(List<int> ints)
{
    var first = ints.First();
    var last = ints.Last();

    var derp = Int32.MaxValue;

    for (int i = first; i <= last; i++)
    {
        var fuelDiff = FuelBasedOnKey(ints, i);

        if (fuelDiff < derp)
        {
            derp = fuelDiff;
        }
    }

    return derp;
}


int FuelBasedOnKey(List<int> crabbies, int key)
{
    var crabCache = new Dictionary<int, int>();

    return crabbies.Select(crab =>
        crabCache.ContainsKey(crab) ? crabCache[crab] : CountAndCacheCrabs(crabCache, crab, key)).Sum();
}

int CountAndCacheCrabs(Dictionary<int, int> crabCache, int crab, int key)
{
    var total = 0;
    var diff = crab < key ? key - crab : crab - key;

    for (int i = 1; i <= diff; i++)
    {
        total += i;
    }

    crabCache.Add(crab, total);
    return total;
}

crabs.Sort();
Console.WriteLine(Question1(crabs));
Console.WriteLine(Question2(crabs));