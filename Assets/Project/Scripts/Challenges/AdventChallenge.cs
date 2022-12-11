public abstract class AdventChallenge
{
    protected string ChallengeDataFilePath;
    public bool IsComplete { get; protected set; }

    public AdventChallenge(string challengeDataFilePath)
    {
        ChallengeDataFilePath = challengeDataFilePath;
        IsComplete = false;
    }

    public abstract string ChallengeNumber { get; }
    public abstract string PerformChallenge();
}