public class RpsRoundFinishedEventData
{
    public RockPaperScissorsResult Result { get; set; }
    public int MyOptionValue { get; set; }
    public int RoundScore { get; set; }
    public int TotalScore { get; set; }

    public RpsRoundFinishedEventData(RockPaperScissorsResult result, int myOptionValue, int roundScore, int totalScore)
    {
        Result = result;
        MyOptionValue = myOptionValue;
        RoundScore = roundScore;
        TotalScore = totalScore;
    }
}