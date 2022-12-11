using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AdventChallenge3b : AdventChallenge
{
    public override string ChallengeNumber => "3b";

    public AdventChallenge3b() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData3.txt") { }

    public override string PerformChallenge()
    {
        var totalPriority = 0;
        var rucksacksInGroup = new List<string>();

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            rucksacksInGroup.Add(line);
            if (rucksacksInGroup.Count < 3)
            {
                continue;
            }

            var commonItemsBetween1And2 = rucksacksInGroup[0].Intersect(rucksacksInGroup[1]);
            var commonItemBetweenAll3 = commonItemsBetween1And2.Intersect(rucksacksInGroup[2]).Single();

            var priority = GetPriorityValue(commonItemBetweenAll3);
            totalPriority += priority;

            rucksacksInGroup.Clear();
        }

        return totalPriority.ToString();
    }

    private int GetPriorityValue(char c)
    {
        var priority = c % 32;

        if (char.IsUpper(c))
        {
            priority += 26;
        }

        return priority;
    }
}