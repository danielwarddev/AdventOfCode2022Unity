using System;
using System.IO;

public class AdventChallenge2a : AdventChallenge
{
    public override string ChallengeNumber => "2a";

    public event EventHandler<RpsInputReceivedEventData> RpsInputReceived;
    public event EventHandler<RpsRoundFinishedEventData> RpsRoundFinished;

    public AdventChallenge2a() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData2.txt") { }

    public override string PerformChallenge()
    {
        var totalScore = 0;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            var opponentValue = line[0];
            var opponentOption = InputToRockPaperScissorsOption(opponentValue);

            var myValue = line[2];
            var myOption = InputToRockPaperScissorsOption(myValue);

            RpsInputReceived.Invoke(this, new RpsInputReceivedEventData(opponentValue, opponentOption, myValue, myOption));

            var result = myOption.Play(opponentOption);
            var roundScore = (int)result + myOption.OptionValue;

            totalScore += roundScore;

            RpsRoundFinished.Invoke(this, new RpsRoundFinishedEventData(result, myOption.OptionValue, roundScore, totalScore));
        }

        return totalScore.ToString();
    }

    private IRockPaperScissorsOption InputToRockPaperScissorsOption(char input)
    {
        return input switch
        {
            'A' or 'X' => new RockOption(),
            'B' or 'Y' => new PaperOption(),
            'C' or 'Z' => new ScissorsOption(),
            _ => throw new ArgumentException("Unexpected RPS option")
        };
    }
}