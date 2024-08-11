using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.CorpusStrength;

public class CorpusStrengthClass2 : ICorpusStrength
{
    private bool isActivated = true;
    private int remainingAsteroids = 5;
    private int remainingMeteorites = 2;

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
                    Console.WriteLine("Ship destroyed due to damage to Class 2 corpus.");
                }
                else
                {
                    Console.WriteLine(
                        $"Class 2 corpus received damage: {damage}. Remaining health: {remainingAsteroids}");
                }
            }
        }
        else if (obstacle is Meteorites && isActivated)
        {
            if (remainingMeteorites > 0)
            {
                remainingMeteorites -= damage;
                if (remainingMeteorites < 0)
                {
                    isActivated = false;
                    Console.WriteLine("Ship destroyed due to damage to Class 2 corpus.");
                }
                else
                {
                    Console.WriteLine(
                        $"Class 2 corpus received damage: {damage}. Remaining health: {remainingMeteorites}");
                }
            }
        }
        else
        {
            isActivated = false;
            Console.WriteLine("Ship destroyed due to damage to Class 2 corpus.");
        }
    }

    public bool GetIsActivated() => isActivated;
}
