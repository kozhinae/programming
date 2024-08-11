using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    private IEnumerable<IObstacle> obstacles;
    private ISpace _space;
    private Ship _ship;
    public Route(ISpace space, Ship ship, IEnumerable<IObstacle> obstacle)
    {
        _space = space;
        _ship = ship;
        obstacles = obstacle;
    }

    public void PassRoute()
    {
        _space.Sail(_ship, obstacles);
    }
}
