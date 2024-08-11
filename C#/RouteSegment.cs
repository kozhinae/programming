using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class RouteSegment
{
    public RouteSegment(PathSegment path, IEnumerable<IObstacle> obstacles)
    {
        Path = path;
        Obstacles = obstacles;
    }

    public PathSegment Path { get; private set; }
    public IEnumerable<IObstacle> Obstacles { get; private set; }
    public RouteSegmentResult Sail(Ship ship)
    {
        Path.Space.Sail(ship, Obstacles);
        return new RouteSegmentResult
        {
            ResultType = RouteResultType.Success,
            Duration = TimeSpan.FromHours(Path.Distance / ship.Speed),
            FuelConsumed = ship.CalculateFuelConsumption(Path.Distance)
        };
    }
}