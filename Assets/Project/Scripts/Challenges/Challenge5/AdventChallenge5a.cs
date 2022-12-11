using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AdventChallenge5a : AdventChallenge
{
    public override string ChallengeNumber => "5a";

    public AdventChallenge5a() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData5.txt") { }

    public override string PerformChallenge()
    {
        var stacksWithValuesReversed = new List<Stack<char>>();
        bool stacksFilled = false;
        CargoHold cargoHold = null;

        foreach (var line in File.ReadLines(ChallengeDataFilePath))
        {
            if (line == string.Empty)
            {
                continue;
            }

            if (!stacksFilled)
            {
                if (line.StartsWith(' '))
                {
                    stacksFilled = true;
                    cargoHold = new CargoHold(stacksWithValuesReversed);
                }
                else
                {
                    stacksWithValuesReversed = FillStacksWithValues(stacksWithValuesReversed, line);
                }

                continue;
            }

            var instruction = GetCraneInstructionFromLine(line);
            cargoHold.MoveBoxesOneAtATime(instruction);
        }

        return cargoHold.TopCrateValues;
    }

    private List<Stack<char>> FillStacksWithValues(List<Stack<char>> currentStacks, string line)
    {
        var rowValues = GetStackValuesFromRow(line);

        if (currentStacks.Count == 0)
        {
            currentStacks = rowValues.Select(_ => new Stack<char>()).ToList();
        }

        for (int i = 0; i < rowValues.Count; i++)
        {
            if (rowValues[i] != ' ')
            {
                currentStacks[i].Push(rowValues[i]);
            }
        }

        return currentStacks;
    }

    private List<char> GetStackValuesFromRow(string line)
    {
        var values = new List<char>();

        while (line.Length != 0)
        {
            var box = line.Substring(0, 3);
            var boxChar = box[1];

            values.Add(boxChar);

            line = line.Length == 3 ? line.Substring(3) : line.Substring(4);

        }

        return values;
    }

    private CraneInstruction GetCraneInstructionFromLine(string line)
    {
        var statements = line.Split(' ');

        var moveAmount = int.Parse(statements[1]);
        var sourceStack = int.Parse(statements[3]);
        var destinationStack = int.Parse(statements[5]);

        return new CraneInstruction(moveAmount, sourceStack, destinationStack);
    }
}