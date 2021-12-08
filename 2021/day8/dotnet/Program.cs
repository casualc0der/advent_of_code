var input = File.ReadLines("/Users/eddsansome/code/advent_of_code/2021/day8/input8.txt").ToList();

int Question1(List<string> code)
{
    return code.Select(line =>
    {
        return line.Split(" | ")[1].Split(" ")
            .Select(word => word.Trim().Length is 2 or 3 or 4 or 7 ? 1 : 0)
            .Sum();
    }).Sum();
}

int Question2(List<string> code)
{
    return code.Select(line =>
    {
        var positions = new string [10];
        var codeLine = line.Split(" | ");
        var digits = codeLine[0].Split(" ").Select(x => x.Trim()).OrderBy(o => o.Length).ToList();
        var crackMe = codeLine[1].Split(" ").Select(x => x.Trim()).ToList();

        positions[1] = digits[0];
        positions[7] = digits[1];
        positions[4] = digits[2];
        positions[8] = digits[9];

        var fiveSegments = new List<string>()
        {
            digits[3], digits[4], digits[5]
        };
        var sixSegments = new List<string>()
        {
            digits[6], digits[7], digits[8]
        };

        // lets find 6
        sixSegments.ForEach(seq => Find(positions, 6, 7, 1, seq));
        // lets find 0
        sixSegments.ForEach(seq => InverseFind(positions, 0, 4, 6, 1, seq));
        // lets find 9 
        sixSegments.ForEach(seq => DoubleInverseFind(positions, 9, 6, 0, seq));
        // lets find 3
        fiveSegments.ForEach(seq => Find(positions, 3, 7, 0, seq));
        // lets find 2
        fiveSegments.ForEach(seq => InverseFind(positions, 2, 9, 3, 2,  seq));
        // lets find 5
        fiveSegments.ForEach(seq => DoubleInverseFind(positions, 5, 3, 2, seq));

        var sortedSeq = positions.ToList()
            .Select(seq => String.Concat(seq.OrderBy(o => o))).ToList();

        var answer = "";
        crackMe.ForEach(seq =>
        {
            var ss = String.Concat(seq.OrderBy(o => o));
            answer += sortedSeq.IndexOf(ss).ToString();
        });
        
        return Int32.Parse(answer);
    }).Sum();
}

void Find(string[] pos, int targetNum, int comparer, int count,string sequence)
{
    var derp = pos[comparer].ToCharArray().Except(sequence.ToCharArray());
    if (pos[comparer].ToCharArray().Except(sequence.ToCharArray()).Count() == count)
    {
        pos[targetNum] = sequence;
    }
}

void InverseFind(string[] pos, int targetNum, int comparer, int inverser, int count, string sequence)
{
    if (pos[comparer].ToCharArray().Except(sequence.ToCharArray()).Count() == count && sequence != pos[inverser])
    {
        pos[targetNum] = sequence;
    }
}

void DoubleInverseFind(string[] pos, int targetNum, int left, int right, string sequence)
{
    if (sequence != pos[left] && sequence != pos[right])
    {
        pos[targetNum] = sequence;
    } 
}


Console.WriteLine(Question1(input));
Console.WriteLine(Question2(input));