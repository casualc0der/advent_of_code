using System.Numerics;

var input = await File.ReadAllTextAsync("/Users/eddsansome/code/advent_of_code/2021/day6/dotnet/input5.txt");

var fishies = input.Split(",")
                                    .ToList()
                                    .Select(int.Parse)
                                    .ToList();


Dictionary<int, BigInteger> FishCount(List<int> fish)
{

    var fishBurgers = new Dictionary<int, BigInteger>()
    {
        {0, 0},
        {1, 0},
        {2, 0},
        {3, 0},
        {4, 0},
        {5, 0},
        {6, 0},
        {7, 0},
        {8, 0},

    };
    
    fish.ForEach(x => fishBurgers[x]++);

    return fishBurgers;

}

BigInteger Fishies(int days, Dictionary<int,BigInteger>fish)
{
    if (days == 0)
    {
        var t = new BigInteger(0);
        fish.Values.ToList().ForEach(x =>
        {
            t = BigInteger.Add(x, t);
        });
        return t;
    }

    var newFish = new Dictionary<int, BigInteger>()
    {
        {0, 0},
        {1, 0},
        {2, 0},
        {3, 0},
        {4, 0},
        {5, 0},
        {6, 0},
        {7, 0},
        {8, 0},

    };
    var respawns = new BigInteger(0);

    for (int i = 0; i <= 8; i++)
    {
        if (i == 0)
        {
            respawns = fish[0];
            fish[0] = 0;
        }
        else
        {
            newFish[i - 1] = fish[i];
        }

    }

    newFish[6] += respawns;
    newFish[8] += respawns;

    return Fishies(days - 1, newFish);
}


Console.WriteLine(Fishies(256, FishCount(fishies)));