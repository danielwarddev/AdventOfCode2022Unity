public class ElfTree
{
    private int _height;
    private int _x;
    private int _y;

    public int Height { get => _height; }
    public int X { get => _x; }
    public int Y { get => _y; }

    public ElfTree(int x, int y, int height)
    {
        _x = x;
        _y = y;
        _height = height;
    }
}