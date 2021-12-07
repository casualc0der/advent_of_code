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

    ;
    Console.WriteLine(derp);
}

int FuelBasedOnKey(List<int> crabbies, int key)
{
    var total = 0;

    crabbies.ForEach(crab =>
    {
        var tmp = 0;
        if (crab < key)
        {
            var diff = key - crab;
            for (int i = 1; i <= diff; i++)
            {
                tmp += i;
            }

            total += tmp;
        }

        if (crab > key)
        {
            var tmp1 = 0;
            var diff = crab - key;
            for (int i = 1; i <= diff; i++)
            {
                tmp1 += i;
            }

            total += tmp1;
        }
    });

    return total;
}


Question1(crabs);
Question2(crabs);