using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class AntinitrineEmitter
{
    public static void DeflectObstacles(IObstacle obstacle, int quantity)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle), "The parameter cannot be null.");
        }

        if (obstacle is SpaceWhale)
        {
            Console.WriteLine($"Deflected spaceWhale. Remaining SpaceWhales: {0}");
        }
    }
}
