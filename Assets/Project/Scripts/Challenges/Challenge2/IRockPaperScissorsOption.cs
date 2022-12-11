public interface IRockPaperScissorsOption
{
    public int OptionValue { get; }
    public RockPaperScissorsResult Play(IRockPaperScissorsOption opponentOption);
    public IRockPaperScissorsOption DetermineValueForResult(RockPaperScissorsResult desiredResult);
}

public class RockOption : IRockPaperScissorsOption
{
    public int OptionValue => 1;

    public RockPaperScissorsResult Play(IRockPaperScissorsOption opponentOption)
    {
        if (opponentOption is RockOption)
        {
            return RockPaperScissorsResult.Tie;
        }
        else if (opponentOption is PaperOption)
        {
            return RockPaperScissorsResult.Lose;
        }
        else
        {
            return RockPaperScissorsResult.Win;
        }
    }

    public IRockPaperScissorsOption DetermineValueForResult(RockPaperScissorsResult desiredResult)
    {
        if (desiredResult == RockPaperScissorsResult.Win)
        {
            return new PaperOption();
        }
        else if (desiredResult == RockPaperScissorsResult.Tie)
        {
            return new RockOption();
        }
        else
        {
            return new ScissorsOption();
        }
    }
}

public class PaperOption : IRockPaperScissorsOption
{
    public int OptionValue => 2;

    public RockPaperScissorsResult Play(IRockPaperScissorsOption opponentOption)
    {
        if (opponentOption is RockOption)
        {
            return RockPaperScissorsResult.Win;
        }
        else if (opponentOption is PaperOption)
        {
            return RockPaperScissorsResult.Tie;
        }
        else
        {
            return RockPaperScissorsResult.Lose;
        }
    }

    public IRockPaperScissorsOption DetermineValueForResult(RockPaperScissorsResult desiredResult)
    {
        if (desiredResult == RockPaperScissorsResult.Win)
        {
            return new ScissorsOption();
        }
        else if (desiredResult == RockPaperScissorsResult.Tie)
        {
            return new PaperOption();
        }
        else
        {
            return new RockOption();
        }
    }
}

public class ScissorsOption : IRockPaperScissorsOption
{
    public int OptionValue => 3;

    public RockPaperScissorsResult Play(IRockPaperScissorsOption opponentOption)
    {
        if (opponentOption is RockOption)
        {
            return RockPaperScissorsResult.Lose;
        }
        else if (opponentOption is PaperOption)
        {
            return RockPaperScissorsResult.Win;
        }
        else
        {
            return RockPaperScissorsResult.Tie;
        }
    }

    public IRockPaperScissorsOption DetermineValueForResult(RockPaperScissorsResult desiredResult)
    {
        if (desiredResult == RockPaperScissorsResult.Win)
        {
            return new RockOption();
        }
        else if (desiredResult == RockPaperScissorsResult.Tie)
        {
            return new ScissorsOption();
        }
        else
        {
            return new PaperOption();
        }
    }
}

public enum RockPaperScissorsResult { Lose = 0, Tie = 3, Win = 6 }