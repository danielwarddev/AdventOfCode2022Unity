using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdventChallenge8b : AdventChallengeV2
{
    public override string ChallengeNumber => "8b";
    private ElfForest _forest = new();
    private int _currentRowNumber = 0;

    public AdventChallenge8b() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData8.txt") { }

    protected override void ProcessLine(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            var treeHeight = int.Parse(line[i].ToString());
            _forest.AddTree(new ElfTree(i, _currentRowNumber, treeHeight));
        }

        _currentRowNumber++;
    }

    protected override string GetSolution()
    {
        return _forest.GetHighestScenicScore().ToString();
    }
}