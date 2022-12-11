using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AdventChallenge6 : AdventChallenge
{
    public AdventChallenge6() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData6.txt") { }

    protected string PerformChallenge(int markerSize)
    {
        int markerEndIndex = 0;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            if (line == string.Empty)
            {
                continue;
            }

            markerEndIndex = FindMarkerEndIndex(line, markerSize);
        }

        return markerEndIndex.ToString();
    }

    private int FindMarkerEndIndex(string line, int markerSize)
    {
        bool markerFound = false;
        int markerStartIndex = 0;

        while (!markerFound)
        {
            var possibleMarker = line.Substring(markerStartIndex, markerSize);
            var anyDuplicates = possibleMarker
                .GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Any();

            if (anyDuplicates)
            {
                markerStartIndex++;
            }
            else
            {
                markerFound = true;
            }
        }

        return markerStartIndex + markerSize;
    }
}