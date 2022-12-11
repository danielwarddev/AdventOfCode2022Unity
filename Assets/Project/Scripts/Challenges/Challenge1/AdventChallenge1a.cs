using System;
using System.IO;

public class AdventChallenge1a : AdventChallenge
{
    public override string ChallengeNumber => "1a";

    public event EventHandler<int> NewCalorieValueReceived;
    public event EventHandler<int> ElfTotalCaloriesUpdated;
    public event EventHandler<int> ElfCaloriesCompleted;

    public AdventChallenge1a() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData1.txt") { }

    public override string PerformChallenge()
    {
        var largestElfCalories = 0;
        var currentElfCalories = 0;

        foreach(var line in File.ReadLines(ChallengeDataFilePath))
        {
            if (line == string.Empty)
            {
                ElfCaloriesCompleted.Invoke(this, currentElfCalories);

                largestElfCalories = currentElfCalories > largestElfCalories ? currentElfCalories : largestElfCalories;
                currentElfCalories = 0;
                continue;
            }

            var calories = int.Parse(line);
            NewCalorieValueReceived.Invoke(this, calories);

            currentElfCalories += calories;
            ElfTotalCaloriesUpdated.Invoke(this, currentElfCalories);
        }

        return largestElfCalories.ToString();
    }
}