using System.Collections.Generic;
using System.Linq;

public class CargoHold
{
    private List<Stack<char>> _crateStacks;
    public string TopCrateValues => new string(_crateStacks.Select(x => x.Peek()).ToArray());

    public CargoHold(IEnumerable<IEnumerable<char>> crateStacks)
    {
        _crateStacks = new List<Stack<char>>();
        foreach(var stackValues in crateStacks)
        {
            _crateStacks.Add(new Stack<char>(stackValues));
        }
    }

    public void MoveBoxesOneAtATime(CraneInstruction instruction)
    {
        int movesLeft = instruction.MoveAmount;

        while (movesLeft > 0)
        {
            var crate = _crateStacks[instruction.SourceStack - 1].Pop();
            _crateStacks[instruction.DestinationStack - 1].Push(crate);
            movesLeft--;
        }
    }

    public void MoveBoxesTogether(CraneInstruction instruction)
    {
        int movesLeft = instruction.MoveAmount;
        var cratesToMove = new List<char>();

        while (movesLeft > 0)
        {
            var crate = _crateStacks[instruction.SourceStack - 1].Pop();
            cratesToMove.Add(crate);
            movesLeft--;
        }

        foreach(var crate in cratesToMove.Reverse<char>())
        {
            _crateStacks[instruction.DestinationStack - 1].Push(crate);
        }
    }
}