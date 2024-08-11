using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.CorpusStrength;

public interface ICorpusStrength
{
    void ReceiveDamage(IObstacle obstacle, int damage);
    bool GetIsActivated();
}

public class CorpusStrengthClass1 : ICorpusStrength
{
    private bool isActivated = true;
    private int remainingAsteroids = 1;
    public void ReceiveDamage(IObstacle obstacle, int damage)
    {
        if (obstacle is Asteroids && isActivated)
        {
            if (remainingAsteroids > 0)
            {
                remainingAsteroids -= damage;
                if (remainingAsteroids < 0)
                {
                    isActivated = false;
                    Console.WriteLine("Ship destroyed due to damage to Class 1 corpus.");
                }
                else
                {
                    Console.WriteLine(
                        $"Class 1 corpus received damage: {damage}. Remaining health: {remainingAsteroids}");
                }
            }
        }
        else
        {
            isActivated = false;
            Console.WriteLine("Ship destroyed due to damage to Class 1 corpus.");
        }
    }

    public bool GetIsActivated() => isActivated;
}
