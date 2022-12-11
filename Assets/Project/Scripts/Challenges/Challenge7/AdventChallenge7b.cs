using System.Linq;

public class AdventChallenge7b : AdventChallengeV2
{
    private ElfDirectoryInfo _currentDirectory = null;
    private bool _isListingDirectoryContents = false;

    public override string ChallengeNumber => "7b";

    public AdventChallenge7b() : base("C:/WS/Unity/AdventOfCode2022/Assets/Project/ChallengeData/ChallengeData7.txt") { }

    protected override void ProcessLine(string line)
    {
        if (line == string.Empty)
        {
            return;
        }

        if (line.StartsWith("$ cd"))
        {
            _isListingDirectoryContents = false;
            ProcessChangeDirectoryCommand(line);
        }
        else if (line.StartsWith("$ ls"))
        {
            _isListingDirectoryContents = true;
        }
        else if (_isListingDirectoryContents)
        {
            ProcessDirectoryContents(line);
        }
    }

    protected override string GetSolution()
    {
        var totalDiskSpace = 70000000;
        var requiredDiskSpace = 30000000;

        var rootDirectory = ElfDirectoryInfo.GetRootDirectory(_currentDirectory);
        var totalDirectorySize = rootDirectory.TotalSize;

        var currentlyFreeSpace = totalDiskSpace - totalDirectorySize;
        var spaceToFreeUp = requiredDiskSpace - currentlyFreeSpace;

        var eligibleDirectories = rootDirectory.GetAllDirectoriesWithinSizeThreshold(spaceToFreeUp);
        return eligibleDirectories
            .OrderBy(x => x.TotalSize)
            .First()
            .TotalSize
            .ToString();
    }

    private void ProcessChangeDirectoryCommand(string line)
    {
        var directoryName = line.Replace("$ cd ", "");

        if (_currentDirectory == null)
        {
            _currentDirectory = new ElfDirectoryInfo(directoryName);
        }
        else if (directoryName == "..")
        {
            _currentDirectory = _currentDirectory.ParentDirectory;
        }
        else if (directoryName == "/")
        {
            _currentDirectory = ElfDirectoryInfo.GetRootDirectory(_currentDirectory);
        }
        else
        {
            var childDirectory = _currentDirectory.GetChildDirectoryAndAddIfNotExists(directoryName);
            _currentDirectory = childDirectory;
        }
    }

    private void ProcessDirectoryContents(string line)
    {
        if (!line.StartsWith("dir"))
        {
            var fileInfo = line.Split(' ');
            var file = new ElfFileInfo(fileInfo[1], int.Parse(fileInfo[0]));
            _currentDirectory.AddFile(file);
        }
    }
}