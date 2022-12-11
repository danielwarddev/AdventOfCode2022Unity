using System;
using System.IO;

// TODO: convert all challenges to this
// TODO: add ChallengeName to each one
public abstract class AdventChallengeV2
{
    protected string ChallengeDataFilePath;
    public bool IsComplete { get; protected set; }
    public event EventHandler<string> LineReceived;

    public AdventChallengeV2(string challengeDataFilePath)
    {
        ChallengeDataFilePath = challengeDataFilePath;
        IsComplete = false;
    }

    public abstract string ChallengeNumber { get; }

    public string PerformChallenge()
    {
        IsComplete = false;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            LineReceived?.Invoke(this, line);
            ProcessLine(line);
        }

        IsComplete = true;
        return GetSolution();
    }

    protected abstract void ProcessLine(string line);
    protected abstract string GetSolution();
}