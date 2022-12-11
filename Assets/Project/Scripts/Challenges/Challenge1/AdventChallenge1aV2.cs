using System;

public class AdventChallenge1aV2 : AdventChallengeV2
{
    public override string ChallengeNumber => "1a";

    public event EventHandler<int> NewCalorieValueReceived;
    public event EventHandler<int> ElfTotalCaloriesUpdated;
    public event EventHandler<int> ElfCaloriesCompleted;

    private int _largestElfCalories = 0;
    private int _currentElfCalories = 0;

    public AdventChallenge1aV2() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData1.txt") { }

    protected override void ProcessLine(string line)
    {
        if (line == string.Empty)
        {
            ElfCaloriesCompleted.Invoke(this, _currentElfCalories);

            _largestElfCalories = _currentElfCalories > _largestElfCalories ? _currentElfCalories : _largestElfCalories;
            _currentElfCalories = 0;
            return;
        }

        var calories = int.Parse(line);
        NewCalorieValueReceived.Invoke(this, calories);

        _currentElfCalories += calories;
        ElfTotalCaloriesUpdated.Invoke(this, _currentElfCalories);
    }

    protected override string GetSolution()
    {
        return _largestElfCalories.ToString();
    }
}