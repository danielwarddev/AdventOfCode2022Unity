using System;
using System.Collections.Generic;
using System.Linq;

public class ElfRope
{
    private Point _head;
    private Point _tail;
    private List<Point> _visitedByTail;

    public int PositionsVisitedByTail { get => _visitedByTail.Count; }

    public ElfRope()
    {
        _head = new Point(0, 0);
        _tail = new Point(0, 0);
        _visitedByTail = new() { _tail };
    }

    public void MoveLeft(int amount)
    {
        Move(amount, () => _head.x--);
    }

    public void MoveRight(int amount)
    {
        Move(amount, () => _head.x++);
    }

    public void MoveUp(int amount)
    {
        Move(amount, () => _head.y--);
    }

    public void MoveDown(int amount)
    {
        Move(amount, () => _head.y++);
    }

    private void Move(int amount, Func<int> movementFunc)
    {
        while (amount > 0)
        {
            movementFunc();
            MoveTailTowardsHead();
            amount--;
        }
    }

    private void MoveTailTowardsHead()
    {
        if (_head.Equals(_tail))
        {
            return;
        }

        // move logic

        if (!_visitedByTail.Any(point => point.Equals(_tail)))
        {
            _visitedByTail.Add(_tail);
        }
    }
}