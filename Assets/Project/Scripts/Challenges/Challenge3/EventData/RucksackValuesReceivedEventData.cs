public class RucksackValuesReceivedEventData
{
    public string Rucksack1Values { get; set; }
    public string Rucksack2Values { get; set; }

    public RucksackValuesReceivedEventData(string rucksack1Values, string rucksack2Values)
    {
        Rucksack1Values = rucksack1Values;
        Rucksack2Values = rucksack2Values;
    }
}