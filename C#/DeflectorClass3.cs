using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass3 : IDeflector
{
    private const int RemainingAsteroids = 40;
    private const int RemainingMeteorites = 10;
    private const int RemainingSpaceWhale = 1;
    private const int NonDeflectedObstacles = 0;
    private int remainingAsteroids = RemainingAsteroids;
    private int remainingMeteorites = RemainingMeteorites;
    private int nonDeflectedObstacles = NonDeflectedObstacles;
    private int remainingSpaceWhale = RemainingSpaceWhale;
    private bool isActivated = true;
    public void DeflectObstacles(IObstacle obstacle, int quantity)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle), "The parameter cannot be null.");
        }

        if (obstacle is Asteroids && isActivated)
        {
            if (remainingAsteroids - quantity >= 0)
            {
                Console.WriteLine(
                    $"Deflected asteroid. Remaining asteroids: {remainingAsteroids = remainingAsteroids - quantity}");
            }
            else
            {
                isActivated = false;
                nonDeflectedObstacles = quantity - remainingAsteroids;
                Console.WriteLine($"Cannot Deflect asteroids.Remaining obstacles: {0}");
            }
        }
        else if (obstacle is Meteorites && isActivated)
        {
            if (remainingMeteorites - quantity >= 0)
            {
                Console.WriteLine(
                    $"Deflected meteorite. Remaining meteorites: {remainingMeteorites = remainingMeteorites - quantity}");
            }
            else
            {
                isActivated = false;
                nonDeflectedObstacles = quantity - remainingMeteorites;
                Console.WriteLine($"Cannot Deflect meteorites.Remaining obstacles: {0}");
            }
        }
        else if (obstacle is SpaceWhale && isActivated)
        {
            if (remainingSpaceWhale - quantity >= 0)
            {
                Console.WriteLine(
                    $"Deflected space whale. Remaining space whales: {remainingSpaceWhale = remainingSpaceWhale - quantity}");
            }
            else
            {
                isActivated = false;
                nonDeflectedObstacles = quantity - remainingSpaceWhale;
                Console.WriteLine($"Cannot Deflect space whales. Remaining obstacles: {0}");
            }
        }
    }

    public int GetNonDeflectedObstacles() => nonDeflectedObstacles;
    public bool GetIsActivated() => isActivated;
}
