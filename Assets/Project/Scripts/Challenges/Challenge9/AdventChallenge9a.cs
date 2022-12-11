using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdventChallenge9a : AdventChallengeV2
{
    private ElfRope _rope;

    public override string ChallengeNumber => "9a";

    public AdventChallenge9a() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData9.txt")
    {
    }

    protected override void ProcessLine(string line)
    {
        var lineValues = line.Split(' ');
        var movementDirection = lineValues[0];
        var movementAmount = int.Parse(lineValues[1]);

        switch(movementDirection)
        {
            case "U":
                _rope.MoveUp(movementAmount);
                break;
            case "D":
                _rope.MoveDown(movementAmount);
                break;
            case "L":
                _rope.MoveLeft(movementAmount);
                break;
            case "R":
                _rope.MoveRight(movementAmount);
                break;
        }
    }

    protected override string GetSolution()
    {
        return _rope.PositionsVisitedByTail.ToString();
    }
}