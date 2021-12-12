var sample = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

var question = @"3265255276
1537412665
7335746422
6426325658
3854434364
8717377486
4522286326
6337772845
8824387665
6351586484";

var smallSample = @"11111
19991
19191
19991
11111";

var input = question.Split('\n')
    .ToList()
    .Select(x => x.Trim().ToCharArray())
    .ToList();

var width = input.First().Length;
var height = input.Count();

var masterFlash = 0;


void Question1()
{
    var octopi = new int[height, width];

// load in the octopi here
    for (var i = 0; i < height; i++)
    for (var j = 0; j < width; j++)
        octopi[i, j] = int.Parse(input[i][j].ToString());

    // here we simply take 1 step and add 1 to each octopus
    for (var step = 0; step < 100; step++)
    {
        for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
            octopi[i, j]++;

        // function goes here
        octopi = Generate(octopi);
    }

    Console.WriteLine(masterFlash);
}

void Question2()
{
    var octopi = new int[height, width];

// load in the octopi here
    for (var i = 0; i < height; i++)
    for (var j = 0; j < width; j++)
        octopi[i, j] = int.Parse(input[i][j].ToString());

    // here we simply take 1 step and add 1 to each octopus
    var synced = false;
    var step = 0;
    while (!synced)
    {
        step++;
        for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
            octopi[i, j]++;

        // function goes here
        octopi = Generate(octopi);

        synced = CheckFlashes(octopi);
    }

    Console.WriteLine(step);
}


bool CheckFlashes(int[,] octopiGrid)
{
    var flashTotal = width * height;
    for (var i = 0; i < height; i++)
    for (var j = 0; j < width; j++)
        if (octopiGrid[i, j] == 0)
            flashTotal--;

    return flashTotal == 0;
}

int[,] Generate(int[,] octopiGrid)
{
    var flashes = 0;
    var next = octopiGrid;
    for (var i = 0; i < height; i++)
    for (var j = 0; j < width; j++)
        if (octopiGrid[i, j] == 10)
            flashes++;

    // this needs to keep looping

    while (flashes > 0)
    {
        flashes = 0;

        for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
        {
            for (var k = -1; k <= 1; k++)
            for (var l = -1; l <= 1; l++)
                if (InBounds(i, j, k, l) && octopiGrid[i, j] >= 10)
                    if (octopiGrid[i + k, j + l] != 0)
                    {
                        octopiGrid[i + k, j + l]++;
                        if (octopiGrid[i + k, j + l] >= 10) flashes++;
                    }

            if (octopiGrid[i, j] >= 10)
            {
                masterFlash++;
                octopiGrid[i, j] = 0;
            }
        }

        octopiGrid = next;
    }


    return octopiGrid;
}

bool InBounds(int x, int y, int k, int l)
{
    if (x + k < 0 || x + k > height - 1 || y + l < 0 || y + l > width - 1 || k == 0 && l == 0)
        return false;
    else
        return true;
}

Question1();
Question2();