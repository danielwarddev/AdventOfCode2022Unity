using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AdventChallenge1b : AdventChallenge
{
    public override string ChallengeNumber => "1b";

    public AdventChallenge1b() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData1.txt") { }

    public override string PerformChallenge()
    {
        var elfCalories = new List<int>();
        var currentElfCalories = 0;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            if (line == string.Empty)
            {
                elfCalories.Add(currentElfCalories);
                currentElfCalories = 0;
                continue;
            }

            var calories = int.Parse(line);
            currentElfCalories += calories;
        }

        var orderedCalories = elfCalories.OrderByDescending(x => x).ToList();
        return $"{orderedCalories[0] + orderedCalories[1] + orderedCalories[2]}";
    }
}