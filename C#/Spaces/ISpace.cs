using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaces;

public interface ISpace
{
    void Sail(Ship ship, IEnumerable<IObstacle> obstacles);
    int GetDistance();
}

public class NormalSpace : ISpace
{
    private readonly int _distance;
    public NormalSpace(int distance) => _distance = distance;
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
        if (impulseEngine == null)
        {
            throw new ArgumentException("The 'ship' object must have a non-null ImpulseEngine.", nameof(ship));
        }

        if (impulseEngine.GetEngineType() == "ImpulseEngineClassC")
        {
            Console.WriteLine("Moving in ordinary space with ImpulseEngineClassC.");
        }
        else
        {
            Console.WriteLine("Cannot move in ordinary space with this type of engine.");
        }

        foreach (IObstacle obstacle in obstacles)
        {
            if (obstacle is Asteroids || obstacle is Meteorites)
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
