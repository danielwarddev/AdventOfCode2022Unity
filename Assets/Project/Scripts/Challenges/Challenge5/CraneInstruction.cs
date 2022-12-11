public class CraneInstruction
{
    public int MoveAmount { get; set; }
    public int SourceStack { get; set; }
    public int DestinationStack { get; set; }

    public CraneInstruction(int moveAmount, int sourceStack, int destinationStack)
    {
        MoveAmount = moveAmount;
        SourceStack = sourceStack;
        DestinationStack = destinationStack;
    }
}