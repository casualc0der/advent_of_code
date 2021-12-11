//var sample = @"[({(<(())[]>[[{[]{<()<>>
//[(()[<>])]({[<{<<[]>>(
//{([(<{}[<>[]}>{[]{[(<()>
//(((({<>}<{<{<>}{[]{[]{}
//[[<[([]))<([[{}[[()]]]
//[{[{({}]{}}([{[{{{}}([]
//{<[[]]>}<{[{[{[]{()[[[]
//[<(<(<(<{}))><([]([]()
//<{([([[(<>()){}]>(<<{{
//<{([{{}}[<[[[<>{}]]]>[]]";

//var chunks = sample.Split("\n").Select(x => x.Trim()).ToList();

var input = await File.ReadAllTextAsync("/Users/eddsansome/code/advent_of_code/2021/day10/input10.txt");

var chunks = input.Split("\n").Select(x => x.Trim()).ToList();

var incomplete = new List<string>();

var matchingBrackets = new Dictionary<char, char>()
{
    {'{', '}'},
    {'[', ']'},
    {'<', '>'},
    {'(', ')'}
};

var corruptedPoints = new Dictionary<char, int>()
{
    {')', 3 },
    {']', 57 },
    {'}', 1197 },
    {'>', 25137 }
};

var corrupted = new List<char>();

foreach (var chunk in chunks)
{
    var chunkStack = new Stack<char>();
    bool corruptedLine = false;

    // simply - when the top of the stack is not an opening brace
    // or does not match: this is corrupted and we should save the char in
    // our list
    var parse = chunk.ToCharArray();

    foreach (char c in parse)
    {
        if (chunkStack.Count == 0)
        {
            chunkStack.Push(c);
        }
        else if (matchingBrackets[chunkStack.Peek()] == c)
        {
            chunkStack.Pop();
        }
        else if (matchingBrackets.ContainsKey(c))
        {
            chunkStack.Push(c);
        }
        else
        {
            // corrupt
            corrupted.Add(c);
            corruptedLine = true;
            break;
        }

    }

    if (!corruptedLine)
    {
        incomplete.Add(chunk);
    }
}

var total = corrupted.Select(x => corruptedPoints[x]).Sum();

// part 2

var incompletePoints = new Dictionary<char, int>()
{
    {')', 1 },
    {']', 2 },
    {'}', 3 },
    {'>', 4 }
};

var leftOvers = new List<string>();

foreach (var chunk in incomplete)
{
    var chunkStack = new Stack<char>();

    // simply - when the top of the stack is not an opening brace
    // or does not match: this is corrupted and we should save the char in
    // our list
    var parse = chunk.ToCharArray();

    foreach (char c in parse)
    {
        if (chunkStack.Count == 0)
        {
            chunkStack.Push(c);
        }
        else if (matchingBrackets[chunkStack.Peek()] == c)
        {
            chunkStack.Pop();
        }
        else if (matchingBrackets.ContainsKey(c))
        {
            chunkStack.Push(c);
        }

    }

    var tmp = "";

    chunkStack.ToList().ForEach(x => tmp += x);

    leftOvers.Add(tmp);

}

var totalizer = leftOvers.Select(leftOver =>
{
    long total = 0;

    var noice = leftOver.ToCharArray().Select(l => matchingBrackets[l]).ToList();

    foreach (var n in noice)
    {
        total *= 5;
        total += incompletePoints[n];
    }

    return total;



}).ToList();

totalizer.Sort();
Console.WriteLine(totalizer[totalizer.Count / 2]);
