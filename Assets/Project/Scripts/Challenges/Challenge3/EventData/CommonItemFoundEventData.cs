public class CommonItemFoundEventData
{
    public char CommonItem { get; set; }
    public int Priority { get; set; }

    public CommonItemFoundEventData(char commonItem, int priority)
    {
        CommonItem = commonItem;
        Priority = priority;
    }
}