using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class HighDensitySpace : ISpace
{
    private readonly int _distance;
    public HighDensitySpace(int distance) => _distance = distance;
    public void Sail(Ship ship, IEnumerable<IObstacle> obstacles)
    {
        if (obstacles == null)
        {
            throw new ArgumentNullException(nameof(obstacles), "The parameter 'obstacles' cannot be null.");
        }

        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "The parameter 'ship' cannot be null.");
        }

        IJumpEngineType? jumpEngine = ship.JumpEngine;
        if (jumpEngine?.GetEngineType() == "JumpEngine")
        {
            if (jumpEngine.GetMaxDistance() < _distance)
            {
                ship.SetCondition(RouteResultType.ShipLoss);
            }

            Console.WriteLine("Moving in high density space with JumpEngineClassB.");
        }
        else
        {
            ship.SetCondition(RouteResultType.ShipDestruction);
            Console.WriteLine("Cannot move in high density space with this type of engine.");
        }

        foreach (IObstacle obstacle in obstacles)
        {
            if (obstacle is AntimatterFlashes)
            {
                obstacle.InteractWithShip(ship);
                Console.WriteLine($"Detected obstacle: {obstacle.GetType().Name}");
            }
            else
            {
                throw new ArgumentException($"The obstacle of type {obstacle.GetType().Name} is not allowed in normal space.");
            }
        }
    }

    public int GetDistance() => _distance;
}
