using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AdventChallenge5b : AdventChallenge
{
    public override string ChallengeNumber => "5b";

    public AdventChallenge5b() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData5.txt") { }

    public override string PerformChallenge()
    {
        var stacksReversedValues = new List<Stack<char>>();
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
                    cargoHold = new CargoHold(stacksReversedValues);
                }
                else
                {
                    stacksReversedValues = FillStacksWithValues(stacksReversedValues, line);
                }

                continue;
            }

            var instruction = GetCraneInstructionFromLine(line);
            cargoHold.MoveBoxesTogether(instruction);
        }

        return cargoHold.TopCrateValues;
    }

    private List<Stack<char>> FillStacksWithValues(List<Stack<char>> stacks, string line)
    {
        var rowValues = GetStackValuesFromRow(line);

        if (stacks.Count == 0)
        {
            stacks = rowValues.Select(_ => new Stack<char>()).ToList();
        }

        for (int i = 0; i < rowValues.Count; i++)
        {
            if (rowValues[i] != ' ')
            {
                stacks[i].Push(rowValues[i]);
            }
        }

        return stacks;
    }

    private List<char> GetStackValuesFromRow(string line)
    {
        var values = new List<char>();

        while (line.Length != 0)
        {
            var box = line.Substring(0, 3);
            var boxChar = box[1];

            values.Add(boxChar);

            line = line.Substring(3);
            if (line.Length != 0)
            {
                line = line.Substring(1);
            }
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