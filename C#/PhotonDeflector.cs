using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class PhotonDeflector : IDeflector
{
    private const int RemainingFlashes = 3;
    private const int NonDeflectedObstacles = 0;
    private bool isActivated = true;
    private int remainingFlashes = RemainingFlashes;
    private int nonDeflectedObstacles = NonDeflectedObstacles;

    public void DeflectObstacles(IObstacle obstacle, int quantity)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle), "The parameter cannot be null.");
        }

        if (remainingFlashes - quantity >= 0 && obstacle is AntimatterFlashes && isActivated)
        {
            Console.WriteLine($"Deflected antimatter flash. Remaining flashes: {remainingFlashes = remainingFlashes - quantity}");
        }
        else if (remainingFlashes - quantity < 0 && obstacle is AntimatterFlashes)
        {
            isActivated = false;
            nonDeflectedObstacles = quantity - remainingFlashes;
            Console.WriteLine($"Cannot Deflect antimatter flash. Remaining obstacles: {0}");
        }
    }

    public int GetNonDeflectedObstacles() => nonDeflectedObstacles;

    public bool GetIsActivated() => isActivated;
}
