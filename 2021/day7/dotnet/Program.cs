// var input = "16,1,2,0,4,2,7,1,2,14";

var input = await File.ReadAllTextAsync("/Users/eddsansome/code/advent_of_code/2021/day7/input7.txt");

var crabs = input.Split(",").ToList().Select(int.Parse).ToList();

int Question1(List<int> ints)
{
    var mid = ints[ints.Count() / 2];

    return ints.Select(crab => Math.Abs(crab - mid)).Sum();
}

int Question2(IReadOnlyCollection<int> crabbies) =>
    Enumerable.Range(crabbies.First(), crabbies.Last())
        .ToList()
        .Select(fuel => FuelConsumed(crabbies, fuel))
        .Min();

int FuelConsumed(IEnumerable<int> crabbies, int fuel) =>
    crabbies.Select(c => FuelConsumptionByDelta(c, fuel)).Sum();


int FuelConsumptionByDelta(int crab, int fuel)
{
    var delta = Math.Abs(crab - fuel);
    return delta * (delta + 1) / 2;
}

crabs.Sort();
Console.WriteLine(Question1(crabs));
Console.WriteLine(Question2(crabs));