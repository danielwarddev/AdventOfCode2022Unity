using System.Collections.Generic;
using System.Linq;

public class ElfDirectoryInfo
{
    private string _name;
    private ElfDirectoryInfo _parentDirectory;
    private List<ElfDirectoryInfo> _directories;
    private List<ElfFileInfo> _files;

    public string Name { get => _name; }
    public ElfDirectoryInfo ParentDirectory { get => _parentDirectory; }
    public List<ElfDirectoryInfo> Directories { get => _directories.ToList(); }
    public int TotalSize
    {
        get
        {
            int totalSize = 0;

            foreach (var directory in _directories)
            {
                totalSize += directory.TotalSize;
            }

            totalSize += _files.Select(x => x.Size).Sum();

            return totalSize;
        }
    }


    public ElfDirectoryInfo(string name) : this(name, null) { }

    private ElfDirectoryInfo(string name, ElfDirectoryInfo parentDirectory)
    {
        _name = name;
        _parentDirectory = parentDirectory;
        _directories = new();
        _files = new();
    }

    public ElfDirectoryInfo GetChildDirectoryAndAddIfNotExists(string directoryName)
    {
        var childDirectory = _directories.SingleOrDefault(x => x.Name == directoryName);

        if (childDirectory == null)
        {
            childDirectory = new ElfDirectoryInfo(directoryName, this);
            _directories.Add(childDirectory);
        }

        return childDirectory;
    }

    public void AddFile(ElfFileInfo file)
    {
        _files.Add(file);
    }

    public int GetTotalSizeWithinThreshold(int threshold)
    {
        int totalSize = 0;

        foreach(var directory in _directories)
        {
            var directorySize = directory.TotalSize;
            if (directorySize <= threshold)
            {
                totalSize += directorySize;
            }

            totalSize += directory.GetTotalSizeWithinThreshold(threshold);
        }

        return totalSize;
    }

    public List<ElfDirectoryInfo> GetAllDirectoriesWithinSizeThreshold(int threshold)
    {
        var directories = new List<ElfDirectoryInfo>();

        foreach (var directory in _directories)
        {
            var directorySize = directory.TotalSize;
            if (directorySize >= threshold)
            {
                directories.Add(directory);
            }

            directories.AddRange(directory.GetAllDirectoriesWithinSizeThreshold(threshold));
        }

        return directories;
    }

    public List<ElfDirectoryInfo> GetAllDirectories()
    {
        var allDirectories = new List<ElfDirectoryInfo>() { this };
        return GetAllDirectories(allDirectories);
    }

    private List<ElfDirectoryInfo> GetAllDirectories(List<ElfDirectoryInfo> allDirectories)
    {
        foreach(var childDirectory in Directories)
        {
            var allChildDirectories = childDirectory.GetAllDirectories();
            allDirectories.AddRange(allChildDirectories);
        }

        return allDirectories;
    }

    public static ElfDirectoryInfo GetRootDirectory(ElfDirectoryInfo directory)
    {
        var currentRootDirectory = directory;
        var parentDirectory = currentRootDirectory.ParentDirectory;

        while (parentDirectory != null)
        {
            currentRootDirectory = parentDirectory;
            parentDirectory = parentDirectory.ParentDirectory;
        }

        return currentRootDirectory;
    }
}