using System;
using System.IO;
using System.Linq;

public class AdventChallenge3a : AdventChallenge
{
    public override string ChallengeNumber => "3a";

    public event EventHandler<RucksackValuesReceivedEventData> RucksackValuesReceived;
    public event EventHandler<CommonItemFoundEventData> CommonItemFound;
    public event EventHandler<int> TotalPriorityUpdated;

    public AdventChallenge3a() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData3.txt") { }

    public override string PerformChallenge()
    {
        var totalPriority = 0;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            var rucksack1 = line.Substring(0, line.Length / 2);
            var rucksack2 = line.Substring(line.Length / 2);
            RucksackValuesReceived.Invoke(this, new RucksackValuesReceivedEventData(rucksack1, rucksack2));

            var commonItem = rucksack1.Intersect(rucksack2).Single();
            var priority = GetPriorityValue(commonItem);
            CommonItemFound.Invoke(this, new CommonItemFoundEventData(commonItem, priority));

            totalPriority += priority;
            TotalPriorityUpdated.Invoke(this, totalPriority);
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