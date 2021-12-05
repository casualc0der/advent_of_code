
var Lines = new List<Line>();

var vents = new int[1000, 1000];

var input = await File.ReadAllLinesAsync("/Users/eddsansome/code/advent_of_code/day5/input5.txt");

input.ToList().ForEach(x =>
            {
                var temp = x.Replace(" -> ", ",");
                var line = temp.Split(",");
                var newLine = new Line(toInt(line[0]), toInt(line[1]), toInt(line[2]), toInt(line[3]));
                Lines.Add(newLine);
            });

Lines.ForEach(line =>
{
    if (line.Horizontal())
    {
        var derp = new List<int> { line.Y1, line.Y2 };
        derp.Sort();

        for(var i = derp[0]; i <= derp[1]; i++)
        {
            vents[line.X1, i]++;
        }

    }

    if (line.Vertical())
    {
        var derp = new List<int> { line.X1, line.X2 };
        derp.Sort();

        for (var i = derp[0]; i <= derp[1]; i++)
        {
            vents[i, line.Y1]++;
        }

    }

    if (line.Diagonal())
    {
        var derpX = new List<int> { line.X1, line.X2 };
        derpX.Sort();
        var derpY = new List<int> { line.Y1, line.Y2 };
        derpY.Sort();

        var xo = new List<int>();
        var yo = new List<int>();

        for (int i = derpX[0]; i <= derpX[1]; i++)
        {
            xo.Add(i);
        }
        for (int i = derpY[0]; i <= derpY[1]; i++)
        {
            yo.Add(i);
        }

        if(line.X1 < line.X2)
        {
            // reverse
            xo.Reverse();
        }
        if (line.Y1 < line.Y2) {

            // reverse
            yo.Reverse();
        }

        var derp = xo.Zip(yo);

        derp.ToList().ForEach(coord =>
        {
            vents[coord.First, coord.Second]++;
        });
    }
}
);

// total to give us the answer
var total = 0;

for (int i = 0; i < vents.GetLength(0); i++)
{
    for (int j = 0; j < vents.GetLength(0); j++)
    {
        if (vents[i, j] > 1)
        {

            total++;
        }
    }
}

Console.WriteLine(total);

static int toInt(string num) => Int32.Parse(num);

public record Line(int X1, int Y1, int X2, int Y2)
{
    public bool Horizontal() => X1 == X2;
    public bool Vertical() => Y1 == Y2;
    public bool Diagonal() => !Horizontal() && !Vertical();
    public override string ToString() => $"X1={X1},Y1={Y1} -> X2={X2},Y2={Y2}";
}
