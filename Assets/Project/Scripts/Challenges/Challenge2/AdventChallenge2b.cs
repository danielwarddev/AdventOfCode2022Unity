using System;
using System.IO;

public class AdventChallenge2b : AdventChallenge
{
    public override string ChallengeNumber => "2b";

    public AdventChallenge2b() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData2.txt") { }

    public override string PerformChallenge()
    {
        var totalScore = 0;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            var opponentValue = line[0];
            var opponentOption = InputToRockPaperScissorsOption(opponentValue);

            var resultValue = line[2];
            var desiredResult = InputToRockPaperScissorsResult(resultValue);

            var myPlay = opponentOption.DetermineValueForResult(desiredResult);
            var roundScore = (int)desiredResult + myPlay.OptionValue;

            totalScore += roundScore;
        }

        return totalScore.ToString();
    }

    private IRockPaperScissorsOption InputToRockPaperScissorsOption(char input)
    {
        return input switch
        {
            'A' => new RockOption(),
            'B' => new PaperOption(),
            'C' => new ScissorsOption(),
            _ => throw new ArgumentException("Unexpected RPS option")
        };
    }

    private RockPaperScissorsResult InputToRockPaperScissorsResult(char input)
    {
        return input switch
        {
            'X' => RockPaperScissorsResult.Lose,
            'Y' => RockPaperScissorsResult.Tie,
            'Z' => RockPaperScissorsResult.Win,
            _ => throw new ArgumentException("Unexpected RPS result")
        };
    }
}