using System.IO;

public class AdventChallenge4a : AdventChallenge
{
    public override string ChallengeNumber => "4a";

    public AdventChallenge4a() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData4.txt") { }

    public override string PerformChallenge()
    {
        var totalFullOverlaps = 0;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            var elfPair = line.Split(',');
            var elf1RangeString = elfPair[0];
            var elf2RangeString = elfPair[1];

            var elf1Range = GetElfNumberRange(elf1RangeString);
            var elf2Range = GetElfNumberRange(elf2RangeString);

            if (elf1Range.FullyContains(elf2Range) || elf2Range.FullyContains(elf1Range))
            {
                totalFullOverlaps++;
            }
        }

        return totalFullOverlaps.ToString();
    }

    private NumberRange GetElfNumberRange(string rangeString)
    {
        var rangeValues = rangeString.Split('-');

        var lower = int.Parse(rangeValues[0]);
        var upper = int.Parse(rangeValues[1]);

        return new NumberRange(lower, upper);
    }
}