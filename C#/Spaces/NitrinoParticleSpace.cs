using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public class NitrinoParticleSpace : ISpace
{
    private readonly int _distance;
    public NitrinoParticleSpace(int distance) => _distance = distance;
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

        IEngine impulseEngine = ship.ImpulseEngine;
        if (impulseEngine.GetMaxDistance() < _distance)
        {
            ship.SetCondition(RouteResultType.ShipLoss);
            return;
        }

        if (impulseEngine.GetEngineType() == "ImpulseEngineClassE")
        {
            Console.WriteLine("Moving in ordinary space with ImpulseEngineClassE.");
        }
        else
        {
            Console.WriteLine("Cannot move in ordinary space with this type of engine.");
        }

        foreach (IObstacle obstacle in obstacles)
        {
            if (obstacle is SpaceWhale)
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
