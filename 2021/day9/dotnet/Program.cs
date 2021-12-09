

// var sample = @"2199943210
// 3987894921
// 9856789892
// 8767896789
// 9899965678";

var input = File.ReadAllLines("/Users/eddsansome/code/advent_of_code/2021/day9/input9.txt").ToList();

// ok so this is basically minesweeper
// sample
// var caves = sample.Split("\n").ToList().Select(s => s.Trim()).ToList();
//
var caves = input.Select(s => s.Trim()).ToList();

// find the width
var width = caves.First().ToCharArray().Length; 
// find the height
var height = caves.Count();
// lets load up the map
var heatMap = new int[height, width];

for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        heatMap[i, j] = Int32.Parse(caves[i].ToCharArray()[j].ToString());
    }
}

var lowPoints = new List<(int, int)>();
// lets check this sucker
// Looking back this should probably also be recursive
// Will refactor when I have the chance (never hehe :D)
var total = 0;
for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        var target = heatMap[i, j];
           
            if (i == 0 && j == 0) // top left
            {
                var number1 = heatMap[i, j + 1];
                var number2 = heatMap[i + 1, j];
                if (target < number1 && target < number2)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            } 
            else if (i == 0 && j == width - 1) // top right
            {
                var number1 = heatMap[i, j - 1];
                var number2 = heatMap[i + 1, j];
                if (target < number1 && target < number2)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
                
            } 
            else if (i == height - 1 && j == 0) // bottom left
            {
                var number1 = heatMap[i -1, j];
                var number2 = heatMap[i, j + 1];
                if (target < number1 && target < number2)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            }
            else if (i == height - 1 && j == width - 1) // bottom right
            {
                var number1 = heatMap[i -1 , j ];
                var number2 = heatMap[i, j - 1 ];
                if (target < number1 && target < number2)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            }
            else if (j == 0) // left side
            {
                var number1 = heatMap[i - 1, j];
                var number2 = heatMap[i, j + 1];
                var number3 = heatMap[i + 1, j];
                if (target < number1 && target < number2 && target < number3)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            }
            else if (j == width - 1) // right side
            {
                var number1 = heatMap[i - 1, j];
                var number2 = heatMap[i, j - 1];
                var number3 = heatMap[i + 1, j];
                if (target < number1 && target < number2 && target < number3)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            }
            else if (i == 0) // top side
            {
                var number1 = heatMap[i, j + 1];
                var number2 = heatMap[i, j - 1];
                var number3 = heatMap[i + 1, j];
                if (target < number1 && target < number2 && target < number3)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            }
            else if (i == height -1) // bottom
            {
                var number1 = heatMap[i - 1, j];
                var number2 = heatMap[i, j - 1];
                var number3 = heatMap[i, j + 1];
                if (target < number1 && target < number2 && target < number3)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            }
            
            else
            {
                var number1 = heatMap[i - 1, j];
                var number2 = heatMap[i, j - 1];
                var number3 = heatMap[i, j + 1];
                var number4 = heatMap[i + 1, j];
                if (target < number1 && target < number2 && target < number3 && target < number4)
                {
                    lowPoints.Add((i, j));
                    total += (target + 1);
                }
            }
    }
}



// Console.WriteLine(heatMap[0,0]);
// Console.WriteLine(heatMap[0, width - 1]);
// Console.WriteLine(heatMap[height - 1, 0]);
// Console.WriteLine(heatMap[height -1, width - 1]);
Console.WriteLine(total);

var derp = 0;

// Part 2
// Knew we had to use a recursive function
// used this video of maze solving to help
// https://www.youtube.com/watch?v=ht9QAfQpCnQ

bool BasinSize(int[,] cave, bool[,] seen, int x , int y, ref int count)
{
    if (x < 0 || x > height - 1 || y < 0 || y > width - 1)
    {
        // base case
        return false;
    }

    if (cave[x, y] == 9)
    {
        return false;
    }

    if (seen[x, y])
    {
        return false;
    }

    seen[x, y] = true;
    count += 1;
    return BasinSize(cave, seen, x, y - 1, ref count) ||
    BasinSize(cave, seen, x, y + 1, ref count) ||
    BasinSize(cave, seen, x - 1, y, ref count) ||
    BasinSize(cave, seen, x + 1, y, ref count);
   

}

var basins = new List<int>();
lowPoints.ForEach(t =>
{
    derp = 0;
    var size = BasinSize(heatMap, new bool[height, width], t.Item1, t.Item2, ref derp);
    Console.WriteLine(derp);
    basins.Add(derp);
    Console.WriteLine($"LOW POINT X: {t.Item1} Y:{t.Item2}");
});

var answer = basins.ToList();
answer.Sort();
var hello = answer.TakeLast(3);
var defAnswer = hello.Aggregate((x, y) => x * y);
Console.WriteLine(defAnswer);

