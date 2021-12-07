// var input = "16,1,2,0,4,2,7,1,2,14";

var input = await File.ReadAllTextAsync("/Users/eddsansome/code/advent_of_code/2021/day7/input7.txt");

var crabs = input.Split(",").ToList().Select(int.Parse).ToList();

void Question1(List<int> ints)
{
    ints.Sort();

    var mid = ints[ints.Count() / 2];

    var total = 0;

    ints.ForEach(crab =>
    {
        if (crab < mid)
        {
            total += (mid - crab);
        }

        if (crab > mid)
        {
            total += (crab - mid);
        }
    });

    Console.WriteLine(total);
}

void Question2(List<int> ints)
{
    ints.Sort();

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

    Console.WriteLine(derp);
}

int FuelBasedOnKey(List<int> crabbies, int key)
{
    var total = 0;
    var crabCache = new Dictionary<int, int>();

    crabbies.ForEach(crab =>
    {
        if (crabCache.ContainsKey(crab))
        {
            total += crabCache[crab];
        }
        else
        {
            var tmp = 0;
            var diff = crab < key ? key - crab : crab - key;

            for (int i = 1; i <= diff; i++)
            {
                tmp += i;
            }

            total += tmp;
            crabCache.Add(crab, tmp);
            
        }

    });

    return total;
}


Question1(crabs);
Question2(crabs);