public class RpsInputReceivedEventData
{
    public int OpponentValue { get; set; }
    public IRockPaperScissorsOption OpponentOption { get; set; }
    public int MyValue { get; set; }
    public IRockPaperScissorsOption MyOption { get; set; }

    public RpsInputReceivedEventData(int opponentValue, IRockPaperScissorsOption opponentOption, int myValue, IRockPaperScissorsOption myOption)
    {
        OpponentValue = opponentValue;
        OpponentOption = opponentOption;
        MyValue = myValue;
        MyOption = myOption;
    }
}