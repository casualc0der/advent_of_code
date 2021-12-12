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

    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            octopi[i, j] = int.Parse((input[i][j]).ToString());
        }
    }

    for (int step = 0; step < 100; step++)
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                octopi[i, j]++;
            }
        }

        octopi = Generate(octopi);
    }

    Console.WriteLine(masterFlash);
}

void Question2()
{
    var octopi = new int[height, width];

    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            octopi[i, j] = int.Parse((input[i][j]).ToString());
        }
    }

    var synced = false;
    var step = 0;
    while (!synced)
    {
        step++;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                octopi[i, j]++;
            }
        }

        octopi = Generate(octopi);
        synced = CheckFlashes(octopi);
    }

    Console.WriteLine(step);
}


bool CheckFlashes(int[,] octopiGrid)
{
    var flashTotal = width * height;
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (octopiGrid[i, j] == 0)
            {
                flashTotal--;
            }
        }
    }

    return flashTotal == 0;
}

int[,] Generate(int[,] octopiGrid)
{
    var flashes = 0;

    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (octopiGrid[i, j] == 10)
            {
                flashes++;
            }
        }
    }

    while (flashes > 0)
    {
        flashes = 0;


        for (int i = 0; i < height; i++) // find the target cell
        {
            for (int j = 0; j < width; j++) // find the target cell
            {
                for (int k = -1; k <= 1; k++) // loop around the target
                {
                    for (int l = -1; l <= 1; l++) // loop around the target
                    {
                        if (InBounds(i, j, k, l) && octopiGrid[i, j] >= 10)
                        {
                            if (octopiGrid[i + k, j + l] != 0)
                            {
                                octopiGrid[i + k, j + l]++;
                                if (octopiGrid[i + k, j + l] >= 10)
                                {
                                    flashes++;
                                }
                            }
                        }
                    }
                }

                if (octopiGrid[i, j] >= 10)
                {
                    masterFlash++;
                    octopiGrid[i, j] = 0;
                }
            }
        }
    }

    return octopiGrid;
}

bool InBounds(int x, int y, int k, int l) => !(x + k < 0 || x + k > height - 1 || y + l < 0 || y + l > width - 1 ||
                                               k == 0 && l == 0);

Question1();
Question2();