using System.Collections.Generic;
using System.Linq;

public class ElfForest
{
    private List<ElfTree> _trees = new();

    public void AddTree(ElfTree tree)
    {
        _trees.Add(tree);
    }

    public int GetVisibleTreeCount()
    {
        var visibleTreeCount = 0;

        foreach(var tree in _trees)
        {
            if (IsTreeVisible(tree))
            {
                visibleTreeCount++;
            }
        }

        return visibleTreeCount;
    }

    public int GetHighestScenicScore()
    {
        var highestScenicScore = 0;

        foreach (var tree in _trees)
        {
            var scenicScore = GetScenicScore(tree);
            if (scenicScore > highestScenicScore)
            {
                highestScenicScore = scenicScore;
            }
        }

        return highestScenicScore;
    }

    private bool IsTreeVisible(ElfTree tree)
    {
        if (tree.X == 0 || tree.Y == 0)
        {
            return true;
        }

        var leftNeighbors = GetLeftNeighborsOf(tree);
        if (!AnyNeighborsCovering(tree, leftNeighbors))
        {
            return true;
        }

        var rightNeighbors = GetRightNeighborsOf(tree);
        if (!AnyNeighborsCovering(tree, rightNeighbors))
        {
            return true;
        }

        var topNeighbors = GetTopNeighborsOf(tree);
        if (!AnyNeighborsCovering(tree, topNeighbors))
        {
            return true;
        }

        var bottomNeighbors = GetBottomNeighborsOf(tree);
        if (!AnyNeighborsCovering(tree, bottomNeighbors))
        {
            return true;
        }

        return false;
    }

    private IEnumerable<ElfTree> GetLeftNeighborsOf(ElfTree tree) => _trees.Where(neighbor => neighbor.Y == tree.Y && neighbor.X < tree.X);
    private IEnumerable<ElfTree> GetRightNeighborsOf(ElfTree tree) => _trees.Where(neighbor => neighbor.Y == tree.Y && neighbor.X > tree.X);
    private IEnumerable<ElfTree> GetTopNeighborsOf(ElfTree tree) => _trees.Where(neighbor => neighbor.X == tree.X && neighbor.Y < tree.Y);
    private IEnumerable<ElfTree> GetBottomNeighborsOf(ElfTree tree) => _trees.Where(neighbor => neighbor.X == tree.X && neighbor.Y > tree.Y);
    private bool AnyNeighborsCovering(ElfTree tree, IEnumerable<ElfTree> neighbors) => neighbors.Where(neighbor => neighbor.Height >= tree.Height).Any();

    private int GetScenicScore(ElfTree tree)
    {
        var leftNeighbors = GetLeftNeighborsOf(tree).OrderByDescending(neighbor => neighbor.X);
        var leftViewingDistance = GetViewingDistance(tree, leftNeighbors);

        var rightNeighbors = GetRightNeighborsOf(tree).OrderBy(neighbor => neighbor.X);
        var rightViewingDistance = GetViewingDistance(tree, rightNeighbors);

        var topNeighbors = GetTopNeighborsOf(tree).OrderByDescending(neighbor => neighbor.Y);
        var topViewingDistance = GetViewingDistance(tree, topNeighbors);

        var bottomNeighbors = GetBottomNeighborsOf(tree).OrderBy(neighbor => neighbor.Y);
        var bottomViewingDistance = GetViewingDistance(tree, bottomNeighbors);

        return leftViewingDistance * rightViewingDistance * topViewingDistance * bottomViewingDistance;
    }

    private int GetViewingDistance(ElfTree tree, IEnumerable<ElfTree> neighbors)
    {
        var viewingDistance = 0;

        foreach (var neighbor in neighbors)
        {
            viewingDistance++;
            if (neighbor.Height >= tree.Height)
            {
                break;
            }
        }

        return viewingDistance;
    }
}