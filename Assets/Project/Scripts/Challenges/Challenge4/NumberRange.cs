public class NumberRange
{
    private int _lowerNumber;
    private int _upperNumber;

    public int LowerNumber { get => _lowerNumber; }
    public int UpperNumber { get => _upperNumber; }

    public NumberRange(int lowerNumber, int upperNumber)
    {
        _lowerNumber = lowerNumber;
        _upperNumber = upperNumber;
    }

    public bool FullyContains(NumberRange otherRange)
    {
        return _lowerNumber <= otherRange.LowerNumber &&
               _upperNumber >= otherRange.UpperNumber;
    }

    public bool PartiallyContains(NumberRange otherRange)
    {
        return !(_lowerNumber > otherRange.UpperNumber ||
                 _upperNumber < otherRange.LowerNumber);
    }
}