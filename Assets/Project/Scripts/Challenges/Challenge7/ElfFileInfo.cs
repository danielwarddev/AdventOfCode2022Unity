public class ElfFileInfo
{
    public string Name { get; }
    public int Size { get; }

    public ElfFileInfo(string name, int size)
    {
        Name = name;
        Size = size;
    }
}