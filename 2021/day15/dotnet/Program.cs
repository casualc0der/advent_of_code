var sample = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";


var input = sample.Split("\n")
    .Select(x => x.Trim().ToCharArray()).ToList();

var yy = input.Count();
var xx = input.First().Count();

var caves = new int[yy, xx];


for (int y = 0; y < yy; y++)
{
    for (int x = 0; x < xx; x++)
    {
        caves[y, x] = Int32.Parse(input[y][x].ToString());
    }
}

for (int y = 0; y < yy; y++)
{
    for (int x = 0; x < xx; x++)
    {
        Console.Write(caves[y, x]);
    }

    Console.WriteLine();
}

BFS(caves, yy, xx);

bool IsValid(int col, int row, int maxCol, int maxRow, bool[,] visited) 
{
    // If cell lies out of bounds
    if (row < 0 || col < 0 ||
        row >= maxRow || col >= maxCol)
        return false;
 
    // If cell is already visited
    if (visited[row,col])
        return false;
 
    // Otherwise
    return true;
}

void BFS(int[,] caves, int y, int x)
{
    var goal = (caves.GetUpperBound(0), caves.GetUpperBound(0));
    var explored = new bool[y, x];
    var queue = new Queue<(int, int)>();

    var dRow = new[] {-1, 0, 1, 0};
    var dCol = new[] {0, 1, 0, -1};

    // enqueue root
    queue.Enqueue((0, 0));
    while (queue.Count > 0)
    {
         
       
        var cell = queue.Peek();

        Console.WriteLine(cell);

        int yi = cell.Item1;
        int xi = cell.Item2;

        var v = queue.Dequeue();
        
        Console.WriteLine(caves[yi, xi]);

        if (v == goal)
        {
            Console.WriteLine("yaaay");
        }
        // get adjacent cells
        
        for (int i = 0; i < 4; i++)
        {
            int adjy = yi + dRow[i];
            int adjx = xi + dCol[i];

            if (IsValid(adjx, adjy, xx, yy, explored))
            {
                
                queue.Enqueue((adjy, adjx));
                explored[adjy, adjx] = true;
            }
            
        }
    }
}