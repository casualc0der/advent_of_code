// test input

using System.Numerics;

var input = "3,4,3,1,2";

// var input = await File.ReadAllTextAsync("/Users/eddsansome/code/advent_of_code/2021/day6/dotnet/input5.txt");

// lets tidy this up

var fishies = input.Split(",")
                                    .ToList()
                                    .Select(int.Parse)
                                    .ToList();


Dictionary<int, int> FishCount(List<int> fish)
{

    var fishBurgers = new Dictionary<int, int>()
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

// base case is days
// will try recursion but might crash?
// this is very slooooow
// can we change this to use a hash?

long Fishies(int days, Dictionary<int,int>fish)
{
    if (days == 0)
    {
        long total = 0;
        fish.Values.ToList().ForEach(x =>
        {
            total += Convert.ToInt64(x);
        });
        return total;
    }

    var newFish = new Dictionary<int, int>()
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
    var respawns = 0;

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

    var t = new BigInteger();
    fish.Values.ToList().ForEach(x => t += x);
    // solution is correct, but this overflows REEEEEEE
    Console.WriteLine(t);

    return Fishies(days - 1, newFish);
}


Console.WriteLine(Fishies(256, FishCount(fishies)));